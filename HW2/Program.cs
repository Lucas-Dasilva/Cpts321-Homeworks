//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace HW2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// Where we start by creating form
    /// </summary>
    static partial class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Form1 f1 = new Form1
            {
                Text = "Lucas Da Silva - 11631988"
            };
            // Show the instance of the form modally.
            f1.ShowDialog();
        }
    }
}
