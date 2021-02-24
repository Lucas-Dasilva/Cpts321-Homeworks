//-----------------------------------------------------------------------
// <copyright file="Form1.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace HW2
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    /// <summary>
    /// Class for generating form, also where we call all the functions
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This is called from main and loads the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Create List:
            Random rnd = new Random();
            GenerateHash hashClass = new GenerateHash();
            List<int> mainList = hashClass.CreateList(rnd);
 
            //// Implementation 1:
            int hashCount = hashClass.ConstructHash(mainList);
            this.textBox1.AppendText ("1. HashSet method: " + hashCount + " unique numbers\n");
            this.textBox1.AppendText("\tThe time complexity for this method is O(n). " +
                "The first part is a 'for each' statement which goes " +
                "through the entire unsorted list, so it's obviously O(n), " +
                "the second\t\tpart is a '.Contains' if statement for the hashset, which " +
                "is documented as O(1) and the last part is a '.Add' function for a " +
                "hashset, which is also O(1). So O(n) + \t\tO(1) + O(1) <= O(n)\n");

            // Implementation 2:
            GenerateConstant constantClass = new GenerateConstant();
            int constantCount = constantClass.ConstructHash(mainList);
            this.textBox1.AppendText ("\r\n2. O(1) Storage method: " + constantCount + " unique numbers\n");
            

            // Implementation 3:
            GenerateSort sortClass = new GenerateSort();
            List<int> sortedList = sortClass.SortList(mainList);
            int sortCount = sortClass.NonDynamicLinearParse(sortedList);
            this.textBox1.AppendText("\r\n3. Sorted method: " + 
                sortCount + " unique numbers\n"); 
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
