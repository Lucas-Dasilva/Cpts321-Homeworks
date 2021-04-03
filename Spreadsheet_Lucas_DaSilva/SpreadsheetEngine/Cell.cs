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
        /// private readonly integers initialized
        /// </summary>
        private readonly int rowIndex, columnIndex;

        /// <summary>
        /// the cell text
        /// </summary>
        private string text;

        /// <summary>
        /// The actual value of the cell
        /// </summary>
        private string value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class
        /// </summary>
        /// <param name="rowIndex"> new row index </param>
        /// <param name="colIndex"> new column index </param>
        public Cell(int rowIndex, int colIndex)
        {
            this.rowIndex = rowIndex;
            this.columnIndex = colIndex;
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
                    if (value != this.text)
                    {
                        this.text = value;
                        this.OnPropertyChanged("Text");
                    }
                }
                catch
                {
                    throw new MemberAccessException("You need to be a Spreadsheet member to access this Object");
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
                // return this.value;
                if (this.text != null)
                {
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
                try
                {
                    this.value = value;
                    this.OnPropertyChanged("Value");
                }
                catch
                {
                    throw new MemberAccessException("You need to be a Spreadsheet member to access this Object");
                }
            }
        }

        /// <summary>
        /// getter for row index
        /// </summary>
        /// <returns>Returns row index</returns>
        public int GetRowIndex()
        {
            return this.rowIndex;
        }

        /// <summary>
        /// getter for column index
        /// </summary>
        /// <returns>Returns Column index</returns>
        public int GetColumnIndex()
        {
            return this.columnIndex;
        }

        /// <summary>
        /// Create the OnPropertyChanged method to raise the event
        /// The calling member's name will be used as the parameter.
        /// </summary>
        /// <param name="name">The text that will be changed</param>
        protected void OnPropertyChanged(string name)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
