//-----------------------------------------------------------------------
// <copyright file="Spreadsheet.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    /// <summary>
    /// This class will hold the 2d array of cells
    /// </summary>
    internal class Spreadsheet 
    {
        /// <summary>
        /// Represents amount of columns
        /// </summary>
        private int columnCount;

        /// <summary>
        /// Represents amount of rows
        /// </summary>
        private int rowCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="Spreadsheet"/> class.
        /// </summary>
        /// <param name="numRows">Represents number of rows</param>
        /// <param name="numColumns">Represents number of columns</param>
        public Spreadsheet(int numRows, int numColumns)
        {
            // Creating a spreadsheet with 2d array
            this.SheetArray = new Cell[numRows, numColumns];

            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numColumns; col++)
                {
                    this.SheetArray[row, col] = new InstantiateCell(row, col);

                    // We are subscribing to each cell
                    this.SheetArray[row, col].PropertyChanged += new PropertyChangedEventHandler(this.CellPropertyChanged);
                }
            }

            this.columnCount = numColumns;
            this.rowCount = numRows;  
        }

        /// <summary>
        /// Represents event changed for the cells
        /// </summary>
        public event PropertyChangedEventHandler CellPropertyChanged;

        /// <summary>
        /// Gets or sets the a cell in the spreadsheet
        /// </summary>
        public Cell[,] SheetArray { get; set; }

        /// <summary>
        /// Get the cell at given index
        /// </summary>
        /// <param name="rowIndex">index of row</param>
        /// <param name="colIndex">index of column.</param>
        /// <returns>The cell location</returns>
        public Cell GetCell(int rowIndex, int colIndex)
        {
            // return null if the cell does not exist
            if ((Cell)this.SheetArray[rowIndex, colIndex] == null)
            {
                return null;
            }

            return (Cell)this.SheetArray[rowIndex, colIndex];
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

        /// <summary>
        /// Create the OnPropertyChanged method to raise the event
        /// The calling member's name will be used as the parameter.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event argument e</param>
        protected void OnCellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // this.CellPropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            if (sender is Cell cell)
            {
                string text = cell.Text;
                if (text[0] == '=')
                {
                    Dictionary<char, int> dictionary = new Dictionary<char, int>();
                    char c = 'A';
                    int i = 0;

                    while (i < 26)
                    {
                        dictionary.Add(c, i);
                        c++;
                        i++;
                    }

                    int column = dictionary[text[1]];
                    int row = 0;

                    if (text.Length == 3)
                    {
                        row = int.Parse(text[2].ToString());
                    }
                    else
                    {
                        char tensC = text[2];
                        char onesC = text[3];
                        int tens = tensC - '0';
                        int ones = onesC - '0';
                        row = (tens * 10) + ones;

                        if (row == 50)
                        {
                            tens++;
                        }
                    }

                    cell.Text = this.SheetArray[row - 1, column].Text;
                    cell.Value = cell.Text;
                }
                else
                {
                    cell.Text = text;
                    cell.Value = cell.Text;
                }

                // editCol = spreadsheetCell.ColumnIndex;
                // editRow = spreadsheetCell.RowIndex;
                this.OnPropertyChanged(e.PropertyName);
            }
        }

        /// <summary>
        /// Create OnPropertyChanged method to raise the event
        /// </summary>
        /// <param name="name">The property name</param>
        protected void OnPropertyChanged(string name)
        {
            this.CellPropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        /// <summary>
        /// We instantiate a new cell here
        /// </summary>
        public class InstantiateCell : Cell
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="InstantiateCell"/> class
            /// </summary>
            /// <param name="newRow"> new column being added </param>
            /// <param name="newCol"> new row being added </param>
            public InstantiateCell(int newRow, int newCol) : base(newCol, newRow)
            {
                // I think everything should handle itself inside the Cell constructor
            }
        }
    }
}
