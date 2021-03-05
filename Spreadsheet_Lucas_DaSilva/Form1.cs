//-----------------------------------------------------------------------
// <copyright file="Form1.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Cpts321
{
    using System;
    using System.Windows.Forms;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

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
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.HeaderCell.Value = k.ToString();
                k++;
            }

            // Resize columns
            this.dataGridView1.AutoResizeColumns();
        }
    }
}
