//-----------------------------------------------------------------------
// <copyright file="Form1.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CptS321
{
    using System;
    using System.ComponentModel;
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
            if (cell != null && e.PropertyName == "Cell Changed!")
            {
                this.dataGridView1.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Value = cell.Value;
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
            string temp;

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
        }
    }
}
