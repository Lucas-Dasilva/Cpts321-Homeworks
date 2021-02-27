
namespace HW3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox = new System.Windows.Forms.TextBox();
            this.openFileButton = new System.Windows.Forms.OpenFileDialog();
            this.saveFileButton = new System.Windows.Forms.SaveFileDialog();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFile = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFibonacciNumbersfirst50ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFib100 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(0, 27);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox.Size = new System.Drawing.Size(269, 630);
            this.textBox.TabIndex = 0;
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // openFileButton
            // 
            this.openFileButton.FileName = "openFileDialog1";
            this.openFileButton.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileButton_FileOk);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFile,
            this.loadFibonacciNumbersfirst50ToolStripMenuItem,
            this.loadFib100,
            this.toolStripSeparator1,
            this.saveToFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // loadFile
            // 
            this.loadFile.Name = "loadFile";
            this.loadFile.Size = new System.Drawing.Size(256, 22);
            this.loadFile.Text = "Load from file...";
            this.loadFile.Click += new System.EventHandler(this.loadFile_Click);
            // 
            // loadFibonacciNumbersfirst50ToolStripMenuItem
            // 
            this.loadFibonacciNumbersfirst50ToolStripMenuItem.AccessibleDescription = "loadFib50";
            this.loadFibonacciNumbersfirst50ToolStripMenuItem.Name = "loadFibonacciNumbersfirst50ToolStripMenuItem";
            this.loadFibonacciNumbersfirst50ToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.loadFibonacciNumbersfirst50ToolStripMenuItem.Text = "Load Fibonacci numbers (first 50)";
            this.loadFibonacciNumbersfirst50ToolStripMenuItem.Click += new System.EventHandler(this.loadFibonacciNumbersfirst50ToolStripMenuItem_Click);
            // 
            // loadFib100
            // 
            this.loadFib100.Name = "loadFib100";
            this.loadFib100.Size = new System.Drawing.Size(256, 22);
            this.loadFib100.Text = "Load Fibonacci numbers (first 100)";
            this.loadFib100.Click += new System.EventHandler(this.loadFib100_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(253, 6);
            // 
            // saveToFileToolStripMenuItem
            // 
            this.saveToFileToolStripMenuItem.Name = "saveToFileToolStripMenuItem";
            this.saveToFileToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.saveToFileToolStripMenuItem.Text = "Save to file...";
            this.saveToFileToolStripMenuItem.Click += new System.EventHandler(this.saveToFileToolStripMenuItem_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(269, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 657);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.OpenFileDialog openFileButton;
        private System.Windows.Forms.SaveFileDialog saveFileButton;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFile;
        private System.Windows.Forms.ToolStripMenuItem loadFibonacciNumbersfirst50ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFib100;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveToFileToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip;

    }
}

