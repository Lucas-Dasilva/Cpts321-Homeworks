//-----------------------------------------------------------------------
// <copyright file="Cell.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CptS321
{
    using System.ComponentModel;

    /// <summary>
    /// This class represents one cell in the worksheet
    /// </summary>
    public abstract class Cell : INotifyPropertyChanged
    {
        /// <summary>
        /// private readonly integers initialized
        /// </summary>
        private readonly int rowIndex, columnIndex;

        /// <summary>
        /// String of cell
        /// </summary>
        private string text;

        /// <summary>
        /// Evaluated value of the cell
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
        /// Getter for text property
        /// </summary>
        /// <returns>The text</returns>
        public string GetText()
        {
            return this.text;
        }

        /// <summary>
        /// Getter for value
        /// </summary>
        /// <returns>the value</returns>
        public string GetValue()
        {
            return this.value;
        }

        /// <summary>
        /// Set the test property
        /// </summary>
        /// <param name="newText">New text coming in</param>
        public void SetText(string newText)
        {
            // dont change text if they're equal
            // else, change text
            if (newText == this.text)
            {
                return;
            }
            else
            {
                this.text = newText;
                this.OnPropertyChanged("Text");
            }
        }

        /// <summary>
        /// Sets the value property, protected internal means the member can only
        /// be accessed by a derived class in another assembly
        /// </summary>
        /// <param name="newValue">New value that's getting passed in</param>
        protected internal void SetValue(string newValue)
        {
            this.value = newValue;
            this.OnPropertyChanged("Value");
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
