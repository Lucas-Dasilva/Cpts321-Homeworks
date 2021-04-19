//-----------------------------------------------------------------------
// <copyright file="Cell.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CptS321
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// This class represents one cell in the worksheet
    /// </summary>
    internal abstract class Cell : INotifyPropertyChanged
    {
        /// <summary>
        /// the cell text
        /// </summary>
        private string text;

        /// <summary>
        /// The actual value of the cell
        /// </summary>
        private string value;

        /// <summary>
        /// The color of each cell
        /// </summary>
        private uint backgroundColor;

        /// <summary>
        /// The string representation of column index and row index coordinates of cell
        /// </summary>
        private string stringIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class
        /// </summary>
        public Cell()
        {
            this.text = string.Empty;
            this.value = string.Empty;
            this.stringIndex = string.Empty;
            this.ColumnIndex = 0;
            this.RowIndex = 0;
            this.backgroundColor = 0xFFFFFFFF;
        }

        /// <summary>
        /// Represents cell even changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets text
        /// </summary>
        public string Text
        {
            // getter for the cell text
            get
            {
                return this.text;
            }

            // Setter for the cell text
            set
            {
                try
                {
                    // Checks if its an empty string and if it's the same
                    // else, Don't raise event
                    if (value != this.text)
                    {
                        this.text = value;
                        this.OnPropertyChanged("Text");
                    }
                }
                catch
                {
                    throw new Exception("You need to be a Spreadsheet member to access this Object");
                }
            }
        }

        /// <summary>
        /// Gets or sets the value of the cell
        /// </summary>
        public string Value
        {
            // getter for the cell value
            get
            {
                // Set the value of cell
                // else, Don't raise event
                if (this.text != null && this.text != string.Empty)
                {
                    // Check if text is an expression
                    // Else, it's not an expression
                    if (this.text[0] == '=')
                    {
                        return this.value;
                    }
                    else
                    {
                        return this.text;
                    }
                }
                else
                {
                    return this.text;
                }
            }

            // Setter for the cell value
            set
            {
                // Raise event handler
                try
                {
                    this.value = value;
                    this.OnPropertyChanged("Value");
                }
                catch
                {
                    throw new Exception("Error setting value in Cell class");
                }
            }
        }

        /// <summary>
        /// Gets or sets the value of the cell
        /// </summary>
        public uint BGColor
        {
            // getter for the background color
            // setter for the background color
            get
            {
                return this.backgroundColor;
            }

            set
            {
                // Invoke property changed event if we change color
                if (value != this.backgroundColor)
                {
                    this.backgroundColor = value;
                    this.OnPropertyChanged("bgColor");
                }
            }
        }

        /// <summary>
        /// Gets or sets the string representation of the coordinates of the cell
        /// </summary>
        public string StringIndex { get; set; }

        /// <summary>
        /// Gets or sets row index
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// Gets or sets Column index
        /// </summary>
        public int ColumnIndex { get; set; }

        /// <summary>
        /// Gets or sets each expression for a cell
        /// </summary>
        public ExpressionTree MyExpressionTree { get; set; }

        /// <summary>
        /// Event Handler anytime a cell's text is changed.
        /// </summary>
        /// <param name="sender">Object sender</param>
        /// <param name="e">Event argument</param>
        public void CellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(e.PropertyName));
        }

        /// <summary>
        /// Create the OnPropertyChanged method to raise the event
        /// </summary>
        /// <param name="name">The text that will be changed</param>
        protected void OnPropertyChanged(string name)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
