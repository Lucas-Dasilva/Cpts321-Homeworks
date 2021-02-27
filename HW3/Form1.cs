

namespace HW3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Security;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Load file into text box
        /// </summary>
        /// <param name="sender">Contains a reference to the control/object that raised the event.</param>
        /// <param name="e">Contains event data</param>
        private void OpenFileButton_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Read all the text from the text reader object and put it in the text box in interface
        /// </summary>
        /// <param name="sr">Object to read text</param>
        private void LoadText(System.IO.TextReader sr)
        {
            this.textBox.Text = sr.ReadToEnd();
        }

        /// <summary>
        /// On click select a file to load from
        /// </summary>
        /// <param name="sender">Contains a reference to the control/object that raised the event.</param>
        /// <param name="e">Contains event data</param>
        private void LoadFile_Click(object sender, EventArgs e)
        {
            if (openFileButton.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(openFileButton.FileName);
                    textBox.Text = sr.ReadToEnd().ToString();
                    sr.Close();
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }

            }
        }

        /// <summary>
        /// Load fibonacci sequence with max lines set to 50
        /// </summary>
        /// <param name="sender">Contains a reference to the control/object that raised the event.</param>
        /// <param name="e">Contains event data</param>
        private void LoadFibonacciNumbersfirst50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FibonacciTextReader fibonacci = new FibonacciTextReader(50);
            this.textBox.Text = fibonacci.ReadToEnd();
        }

        /// <summary>
        /// Load fibonacci sequence with max lines set to 100
        /// </summary>
        /// <param name="sender">Contains a reference to the control/object that raised the event.</param>
        /// <param name="e">Contains event data</param>
        private void LoadFib100_Click(object sender, EventArgs e)
        {
            FibonacciTextReader fibonacci = new FibonacciTextReader(100);
            this.textBox.Text = fibonacci.ReadToEnd();
        }

        /// <summary>
        /// Save the fibonacci sequence to a file
        /// </summary>
        /// <param name="sender">Contains a reference to the control/object that raised the event.</param>
        /// <param name="e">Contains event data</param>
        private void SaveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // code taken from stream writer documentation
            SaveFileDialog save = new SaveFileDialog();
            StreamWriter myStream = new StreamWriter(save.FileName);

            save.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            
            // If dialog is shown
            if (save.ShowDialog() == DialogResult.OK)
            {
                myStream.WriteLine(this.textBox.Text);
                myStream.Close();
            }
        }
    }
}

