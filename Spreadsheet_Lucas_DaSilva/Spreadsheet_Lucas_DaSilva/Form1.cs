//-----------------------------------------------------------------------
// <copyright file="Form1.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    /// <summary>
    /// Class for creating form
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Declare spreadsheet so that we can initialize it in this class' constructor
        /// </summary>
        private Spreadsheet spreadsheet;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            this.spreadsheet = new Spreadsheet(50, 26);

            // Subscribe to the event
            this.spreadsheet.PropertyChanged += this.CellPropertyChanged;
            this.undoChangeToolStripMenuItem.Enabled = false;
            this.redoToolStripMenuItem.Enabled = false;

            // Disable save button initially, since nothing is changed
            this.saveToolStripMenuItem.Enabled = false;
        }

        /// <summary>
        /// Loads the form
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">Event trigger</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Adding columns from A-Z using ascii code and loop
            for (int i = 65; i < 91; i++)
            {
                char colName = (char)i;
                this.dataGridView1.Columns.Add(colName.ToString(), colName.ToString());
            }

            // Creating 50 rows automatically
            this.dataGridView1.Rows.Add(50);
            int k = 1;
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                row.HeaderCell.Value = k.ToString();
                k++;
            }

            // Resize columns
            foreach (DataGridViewColumn col in this.dataGridView1.Columns)
            {
                col.Width = 80;
            }
        }

        /// <summary>
        /// Handles the drawing to the grid on property changed
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event argument</param>
        private void CellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Cell cell = sender as Cell;
            if (cell != null && e.PropertyName == "Text")
            {
                this.dataGridView1.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Value = cell.Value;
            }
            else if (e.PropertyName == "bgColor")
            {
                this.dataGridView1.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Style.BackColor = this.UIntToColor(cell.BGColor);
            }
            else if (e.PropertyName == "Value")
            {
                this.dataGridView1.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Value = cell.Value;
            }
        }

        /// <summary>
        /// Upon activating the trigger, load the file that the user wants
        /// </summary>
        /// <param name="sender">Click object</param>
        /// <param name="e">Click event trigger</param>
        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            var fileContent = string.Empty;
            var filePath = string.Empty;

            openFileDialog.InitialDirectory = AppContext.BaseDirectory;

            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the path of specified file
                filePath = openFileDialog.FileName;

                // Read the contents of the file into a stream
                var fileStream = openFileDialog.OpenFile();

                // Start loading
                this.spreadsheet.LoadXml(fileStream);
            }
        }

        /// <summary>
        /// Save spreadsheet data to XML file
        /// </summary>
        /// <param name="sender">Click object</param>
        /// <param name="e">Click event trigger</param>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream fileStream;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = AppContext.BaseDirectory;

            // Pop up the save file dialog box
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((fileStream = saveFileDialog.OpenFile()) != null)
                {
                    // Start saving
                    this.spreadsheet.SaveToXml(fileStream);
                    fileStream.Close();
                }
            }
        }

        /// <summary>
        /// On click, we undo last change
        /// </summary>
        /// <param name="sender">Click object</param>
        /// <param name="e">Event arguments</param>
        private void UndoChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.spreadsheet.Undo(this.spreadsheet);

            // If no more undos to do, disable it
            // else, enable it
            if (this.spreadsheet.GetUndoStackCount() == 0)
            {
                this.undoChangeToolStripMenuItem.Enabled = false;
            }
            else
            {
                this.undoChangeToolStripMenuItem.Enabled = true;

                // Change text of undo message
                this.undoChangeToolStripMenuItem.Text = "Undo " + this.spreadsheet.PeekUndoStack();
            }

            // Since we just undid something, we will enable the redo and save button
            this.redoToolStripMenuItem.Enabled = true;
            this.saveToolStripMenuItem.Enabled = true;
           
            // Change text of undo message
            this.redoToolStripMenuItem.Text = "Redo " + this.spreadsheet.PeekRedoStack();
        }

        /// <summary>
        /// On click, we redo last change
        /// </summary>
        /// <param name="sender">Click object</param>
        /// <param name="e">Event arguments</param>
        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Perform redo
            this.spreadsheet.Redo(this.spreadsheet);

            // Disable undo button if the stack is empty
            // else, enable it
            if (this.spreadsheet.GetRedoStackCount() == 0)
            {
                this.redoToolStripMenuItem.Enabled = false;
            }
            else
            {
                this.redoToolStripMenuItem.Enabled = true;

                // Change text of Redo message
                this.redoToolStripMenuItem.Text = "Redo " + this.spreadsheet.PeekRedoStack();
            }

            // Since we just pressed redo, we will enable the undo button
            this.undoChangeToolStripMenuItem.Enabled = true;
            this.saveToolStripMenuItem.Enabled = true;

            // Change text of undo message
            this.undoChangeToolStripMenuItem.Text = "Undo " + this.spreadsheet.PeekUndoStack();
        }

        /// <summary>
        /// Allow user to change color of each individual cell
        /// </summary>
        /// <param name="sender">The click</param>
        /// <param name="e">Event arguments e</param>
        private void ChangeBackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<ICommand> undoList = new List<ICommand>();

            // Check if the user has selected atleast one cell before opening bgColor box
            if (this.dataGridView1.SelectedCells.Count >= 1)
            {
                ColorDialog myDialog = new ColorDialog();

                // Update the text box color if the user clicks OK 
                if (myDialog.ShowDialog() == DialogResult.OK)
                {
                    Color color = myDialog.Color;

                    // For each cell celeted, set the spreadsheet array BG color to it
                    foreach (DataGridViewCell cell in this.dataGridView1.SelectedCells)
                    {
                        // Reference back the old color of the cell to send to Undo Command
                        Cell tempCell = this.spreadsheet.GetCell(cell.RowIndex, cell.ColumnIndex);
                        uint oldColor = tempCell.BGColor;
                        
                        // Set the spreadsheet BgColor property
                        this.spreadsheet.SheetArray[cell.RowIndex, cell.ColumnIndex].BGColor = this.ColorToUInt(myDialog.Color);
                        
                        // Add undo command to the list. We have to use list because lots of cell colors can be changed
                        undoList.Add(new UndoBgColor(this.ColorToUInt(myDialog.Color), oldColor, cell.RowIndex, cell.ColumnIndex));
                    }

                    // Add undo command to the stack
                    this.spreadsheet.AddUndo(new UndoRedoCollection("BgColor", undoList.ToArray()));

                    // Allow users to clicck undo and save button
                    this.undoChangeToolStripMenuItem.Enabled = true;
                    this.saveToolStripMenuItem.Enabled = true;

                    // Change text of undo message
                    this.undoChangeToolStripMenuItem.Text = "Undo " + this.spreadsheet.PeekUndoStack();
                }
            }
        }

        /// <summary>
        /// Represents a cell being edited
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event argument</param>
        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            string msg = string.Format("Editing Cell at ({0}, {1})", e.ColumnIndex, e.RowIndex);
            this.Text = msg;

            // Setting the datagrid value
            this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = this.spreadsheet.SheetArray[e.RowIndex, e.ColumnIndex].Text;
        }

        /// <summary>
        /// Represents finishing the editing of a cell
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event argument</param>
        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string msg = string.Format("Finished Editing Cell at ({0}, {1})", e.ColumnIndex, e.RowIndex);
            this.Text = msg;
            string newText = string.Empty;
    
            List<ICommand> undoList = new List<ICommand>();
            Cell cell = this.spreadsheet.GetCell(e.RowIndex, e.ColumnIndex);

            string oldText = cell.Text;
            
            // Checking if user is deleting the cell value
            if (this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                newText = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                // Create initial circular reference check
                this.spreadsheet.IsFirstIteration();
                
                // Setting the cell text value
                this.spreadsheet.SheetArray[e.RowIndex, e.ColumnIndex].Text = newText;

                // Setting the data grid value
                this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = this.spreadsheet.SheetArray[e.RowIndex, e.ColumnIndex].Value;

                // Add command to the command list
                undoList.Add(new UndoText(newText, oldText, cell.RowIndex, cell.ColumnIndex));
                
                // Allow users to undo by adding the commands to the undo stack
                this.spreadsheet.AddUndo(new UndoRedoCollection("Text", undoList.ToArray()));
                
                // We enable the undo button since an action was just performed
                this.undoChangeToolStripMenuItem.Enabled = true;
                this.saveToolStripMenuItem.Enabled = true;

                // Change text of undo message
                this.undoChangeToolStripMenuItem.Text = "Undo " + this.spreadsheet.PeekUndoStack();
            }
            else
            {
                this.spreadsheet.SheetArray[e.RowIndex, e.ColumnIndex].Text = string.Empty;
                this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Empty;
            }
        }

        /// <summary>
        /// Converts unsigned integer to color 
        /// </summary>
        /// <param name="color">the representation of the color in unsigned form</param>
        /// <returns>The color from the integer</returns>
        private Color UIntToColor(uint color)
        {
            byte a = (byte)(color >> 24);
            byte r = (byte)(color >> 16);
            byte g = (byte)(color >> 8);
            byte b = (byte)(color >> 0);
            return Color.FromArgb(a, r, g, b);
        }

        /// <summary>
        /// Convert from Color to unsigned integer
        /// </summary>
        /// <param name="color">The color from dialog box</param>
        /// <returns>The "unsigned integer" representation of the color</returns>
        private uint ColorToUInt(Color color)
        {
            return (uint)((color.A << 24) | (color.R << 16) |
                          (color.G << 8) | (color.B << 0));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
