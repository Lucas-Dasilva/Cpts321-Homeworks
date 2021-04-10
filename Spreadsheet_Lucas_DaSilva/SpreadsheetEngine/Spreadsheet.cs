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
    using System.Text.RegularExpressions;

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
                    // Instantiating new cell since it's an abstract class
                    this.SheetArray[row, col] = new InstantiateCell();
                    this.SheetArray[row, col].RowIndex = row;
                    this.SheetArray[row, col].ColumnIndex = col;
                    this.SheetArray[row, col].Text = string.Empty;
                    
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
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the a cell in the spreadsheet
        /// </summary>
        public Cell[,] SheetArray { get; set; }

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
        protected void CellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Check if it
            if (sender is Cell cell)
            {
                // Check if the property changed is text
                // Else, the property is "Value"
                if (e.PropertyName == "Text")
                {
                    // Check if cell is an expressive value
                    if (cell != null && cell.Text[0] == '=')
                    {
                        try
                        {
                            // If the expression tree for this cell has been alive before
                            if (cell.MyExpressionTree != null)
                            {
                                // Getting all variables from previous expression
                                List<string> variables = cell.MyExpressionTree.GetAllVariables();

                                foreach (string var in variables)
                                {
                                    var tempCell = this.GetCell(var);

                                    // We want to unsubscribe from old events
                                    if (tempCell != null)
                                    {
                                        tempCell.PropertyChanged -= cell.CellPropertyChanged;
                                    }
                                }
                            }

                            // Build new expression tree
                            InfixToPostfix postfix = new InfixToPostfix();
                            string[] tokenizedLine = Regex.Split(cell.Text.Substring(1), @"([*()\^\/]|(?<!E)[\+\-])");
                            string[] line = postfix.Convert(tokenizedLine);
                            Array.Reverse(line);
                            cell.MyExpressionTree = new ExpressionTree(line);

                            // Scroll through each substring in the expression
                            foreach (string s in line)
                            {
                                // Check if substring in the variable dictionary
                                // else, evaluate expression as is
                                if (cell.MyExpressionTree.CheckDictionary(s))
                                {
                                    // Get the cell from the substring, which is a variable name
                                    var tempCell = this.GetCell(s);

                                    // Get the value of that cell
                                    string stringCellValue = this.GetValueOfCellAt(s);

                                    // Try to parse the string to a double so we can evaluate
                                    if (double.TryParse(stringCellValue, out double cellValue))
                                    {
                                        cell.MyExpressionTree.SetVariable(s, cellValue);
                                        this.SheetArray[cell.RowIndex, cell.ColumnIndex].Value = cell.MyExpressionTree.Evaluate().ToString();
                                    }

                                    // If the cell is not null then we can subscribe to it
                                    // Subscribing to it ensures that it will automatically update
                                    // when we change a different cell that references tempCell
                                    if (tempCell != null)
                                    {
                                        tempCell.PropertyChanged += cell.CellPropertyChanged;
                                    }
                                }
                                else
                                {
                                    this.SheetArray[cell.RowIndex, cell.ColumnIndex].Value = cell.MyExpressionTree.Evaluate().ToString();
                                    this.OnPropertyChanged("Text", cell);
                                }
                            }
                        }
                        catch (MemberAccessException)
                        {
                            throw new MemberAccessException();
                        }
                        catch (Exception exc)
                        {
                            throw new Exception("Unhandled exception in Spreadsheet Engine class", exc);
                        }
                    }
                    else
                    {
                        // We set expression tree to null if it doesn't have and expression
                        cell.MyExpressionTree = null;
                    }

                    // Raise cell property changed event, where we send in the cell that was changed
                    this.OnPropertyChanged("Text", cell);
                }
                else if (e.PropertyName == "bgColor")
                {
                    this.OnPropertyChanged("bgColor", cell);
                }
            }
            else
            {
                throw new Exception("Sender is not of type cell in spreadsheet class");
            }
        }

        /// <summary>
        /// Invokes the property changed event which alerts the form of which property of the cell is being changed
        /// </summary>
        /// <param name="name">The name of property that's being changed</param>
        /// <param name="cell">The cell whose property is being changed</param>
        protected void OnPropertyChanged(string name, Cell cell)
        {
            this.PropertyChanged?.Invoke(cell, new PropertyChangedEventArgs(name));
        }

        /// <summary>
        /// Get the cell at given index
        /// </summary>
        /// <param name="rowIndex">index of row</param>
        /// <param name="colIndex">index of column.</param>
        /// <returns>The cell location</returns>
        private Cell GetCell(int rowIndex, int colIndex)
        {
            // return null if the cell does not exist
            if ((Cell)this.SheetArray[rowIndex, colIndex] == null)
            {
                return null;
            }

            return (Cell)this.SheetArray[rowIndex, colIndex];
        }

        /// <summary>
        /// Gets the cell at specified coordinates of the cell in a string
        /// </summary>
        /// <param name="name">The coordinates of the cell</param>
        /// <returns>The specified cell</returns>
        private Cell GetCell(string name)
        {
            if (name.Length == 0)
            {
                return null;
            }

            int row;
            int column;
            if (Regex.Matches(name, @"[a-zA-Z]").Count > 0)
            {
                if (int.TryParse(name.Substring(1), out row))
                {
                    column = this.CellColumnToIndex(name[0]);
                    return this.GetCell(row - 1, column);
                }
            }

            // index out of bounds or other error.
            return null;
        }

        /// <summary>
        /// Converts the first alphabetical character of column to an index
        /// </summary>
        /// <param name="c">Capital letter</param>
        /// <returns>The correlated index</returns>
        private int CellColumnToIndex(char c)
        {
            return (int)c - 65;
        }

        /// <summary>
        /// Gets the value of a cell at a certain coordinate
        /// </summary>
        /// <param name="coords">The coordinates of the cell or name. (A1 or B2)etc..</param>
        /// <returns>String value of cell</returns>
        private string GetValueOfCellAt(string coords)
        {
            int colIndex = this.CellColumnToIndex(coords[0]);

            // After getting the corresponding column index, we return it
            if (int.TryParse(coords.Substring(1), out int rowIndex))
            {
                rowIndex--;
                return this.SheetArray[rowIndex, colIndex].Value;
            }
            else
            {
                return "Could not parse column name";
            }
        }

        /// <summary>
        /// We instantiate a new cell here
        /// </summary>
        public class InstantiateCell : Cell
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="InstantiateCell"/> class
            /// </summary>
            public InstantiateCell() : base()
            {
                // I think everything should handle itself inside the Cell constructor
            }
        }
    }
}
