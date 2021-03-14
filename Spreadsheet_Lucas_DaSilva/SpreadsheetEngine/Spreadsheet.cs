//-----------------------------------------------------------------------
// <copyright file="Spreadsheet.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CptS321
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// This class will hold the 2d array of cells
    /// </summary>
    class Spreadsheet 
    {
        private Cell[,] Sheet;

        /// <summary>
        /// Represents event changed for the cells
        /// </summary>
        public event PropertyChangedEventHandler CellPropertyChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="Spreadsheet"/> class.
        /// </summary>
        /// <param name="numRows">Represents number of rows</param>
        /// <param name="numColumns">Represents number of columns</param>
        public Spreadsheet(int numRows, int numColumns)
        {
            // Creating a spreadsheet with 2d array
            this.Sheet = new Cell[numRows, numColumns];

            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numColumns; col++)
                {
                    this.Sheet[row, col] = new InstantiateCell(row, col);
                    // I don't understand how to subscribe to cell changed 
                }
            }
        }
        public class InstantiateCell : Cell
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="InstantiateCell"/> class
            /// </summary>
            /// <param name="newRow"> new column being added </param>
            /// <param name="newCol"> new row being addded </param>
            public InstantiateCell(int newRow, int newCol) : base(newCol, newRow)
            {
                // I think everything should handle itself inside the Cell constructor
            }

        }

        /// <summary>
        /// Get the cell at given index
        /// </summary>
        /// <param name="rowIndex">index of row</param>
        /// <param name="colIndex">index of column.</param>
        /// <returns>Int.</returns>
        public Cell GetCell(int rowIndex, int colIndex)
        {
            // return null if the cell does not exist
            if ((Cell)this.Sheet[rowIndex, colIndex] == null)
            {
                return null;
            }

            return (Cell)this.Sheet[rowIndex, colIndex];
        }


        /// <summary>
        /// Create the OnPropertyChanged method to raise the event
        /// The calling member's name will be used as the parameter.
        /// </summary>
        /// <param name="name">The text that will be changed</param>
        protected void OnCellPropertyChanged(string name)
        {
            this.CellPropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        /// <summary>
        /// Getter for row count
        /// </summary>
        /// <returns>the row count</returns>
        public int GetRowCount()
        {
            return this.rowCount;
        }
        /// <summary>
        /// Getter for column count
        /// </summary>
        /// <returns>the column count</returns>
        public int GetColumnCount()
        {
            return this.columnCount;
        }

        private int columnCount;
        private int rowCount;

    }
}
