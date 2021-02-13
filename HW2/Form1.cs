using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Instantiate random number generator using system-supplied value as seed.
            var rand = new Random();

            // Generate and display 5 random integers between 0 and 100.
            Console.WriteLine("Five random integers between 0 and 100:");
            // for (int ctr = 0; ctr <= 4; ctr++)
            //    this.textBox1.Text("{0,8:N0}", rand.Next(101));
            // Console.WriteLine();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
