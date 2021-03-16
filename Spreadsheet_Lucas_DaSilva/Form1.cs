//-----------------------------------------------------------------------
// <copyright file="Form1.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CptS321
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Class for creating form
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
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
    }
}
