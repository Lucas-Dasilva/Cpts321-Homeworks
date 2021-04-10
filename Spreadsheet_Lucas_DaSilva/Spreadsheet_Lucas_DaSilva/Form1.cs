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
            this.dataGridView1.AutoResizeColumns();
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
        }

        /// <summary>
        /// On click, we undo last change
        /// </summary>
        /// <param name="sender">Click object</param>
        /// <param name="e">Event arguments</param>
        private void UndoChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.spreadsheet.Undo(this.spreadsheet);

            if (spreadsheet.GetUndoStackCount() == 0)
            {
                this.undoChangeToolStripMenuItem.Enabled = false;
            }
            else
            {
                this.undoChangeToolStripMenuItem.Enabled = true;
            }
        }

        /// <summary>
        /// On click, we redo last change
        /// </summary>
        /// <param name="sender">Click object</param>
        /// <param name="e">Event arguments</param>
        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.spreadsheet.Redo(this.spreadsheet);
            if (this.spreadsheet.GetRedoStackCount() == 0)
            {
                this.redoToolStripMenuItem.Enabled = false;
            }
            else
            {
                this.redoToolStripMenuItem.Enabled = true;
            }

        }

        /// <summary>
        /// Opens color change dialog box
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
                        Cell tempCell = this.spreadsheet.GetCell(cell.RowIndex, cell.ColumnIndex);
                        this.spreadsheet.SheetArray[cell.RowIndex, cell.ColumnIndex].BGColor = this.ColorToUInt(myDialog.Color);
                        
                        undoList.Add(new UndoBgColor(this.ColorToUInt(myDialog.Color), tempCell.BGColor, cell.RowIndex, cell.ColumnIndex));
                    }

                    this.spreadsheet.AddUndo(new UndoRedoCollection("BgColor", undoList.ToArray()));
                    this.undoChangeToolStripMenuItem.Enabled = true;
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
            string temp = string.Empty;
            List<ICommand> undoList = new List<ICommand>();
            Cell cell = this.spreadsheet.GetCell(e.RowIndex, e.ColumnIndex);
            string oldText = cell.Text;

            // Checking if user is deleting the cell value
            if (this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                temp = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                // Setting the cell text value
                this.spreadsheet.SheetArray[e.RowIndex, e.ColumnIndex].Text = temp;

                // Setting the data grid value
                this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = this.spreadsheet.SheetArray[e.RowIndex, e.ColumnIndex].Value;
            }
            else
            {
                this.spreadsheet.SheetArray[e.RowIndex, e.ColumnIndex].Text = string.Empty;
                this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Empty;
            }
            cell.Text = temp;

            undoList.Add(new UndoText(cell.Text, oldText, cell.RowIndex, cell.ColumnIndex));
            spreadsheet.AddUndo(new UndoRedoCollection("Text", undoList.ToArray()));
            this.undoChangeToolStripMenuItem.Enabled = true;

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

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
