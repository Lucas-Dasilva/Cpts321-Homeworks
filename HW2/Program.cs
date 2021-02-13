//Ok so there's a small bug, where sometimes the amount of unique 
//memebers differ by 1 for my constant storage function that's 
//because I didn't realize we were using the same random seed
//for all implementationsuntil the very end so I didn't have time
//to go back and analyse little bugs, the same goes for my test
//cases. I was testing everything with the idea in mind that all
//seeds would be different. Sorry about that..
namespace HW2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;

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
