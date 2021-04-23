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
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Xml;

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
        /// Holds the string index and the text of cell
        /// </summary>
        private int iteration;

        /// <summary>
        /// Holds the string index and the text of cell
        /// </summary>
        private string[] cellReference;

        /// <summary>
        /// Holds the string index and the text of cell
        /// </summary>
        private string[] tempReference;

        /// <summary>
        /// Stack of undo commands
        /// </summary>
        private Stack<UndoRedoCollection> undoStack = new Stack<UndoRedoCollection>();

        /// <summary>
        /// Stack of redo commands
        /// </summary>
        private Stack<UndoRedoCollection> redoStack = new Stack<UndoRedoCollection>();

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
                    this.SheetArray[row, col].StringIndex = this.CoordsToString(row, col);
                    
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
        /// Reference a cell that has been marked with circular reference
        /// </summary>
        /// <param name="stringIndex">The string index of the cell</param>
        /// <param name="cellText">The cell's Text property</param>
        public void SetCellCheck(string stringIndex, string cellText)
        {
            this.cellReference = new string[2];
            this.cellReference[0] = stringIndex;
            this.cellReference[1] = cellText;
        }

        /// <summary>
        /// Reference a cell that has been marked with circular reference
        /// </summary>
        /// <param name="stringIndex">The string index of the cell</param>
        /// <param name="cellText">The cell's Text property</param>
        public void SetTempCellCheck(string stringIndex, string cellText)
        {
            this.tempReference = new string[2];
            this.tempReference[0] = stringIndex;
            this.tempReference[1] = cellText;
        }

        /// <summary>
        /// Sets the iteration of property changed to 0
        /// </summary>
        public void IsFirstIteration()
        {
            this.iteration = 0;
        }

        /// <summary>
        /// Adds a cell to the undoStack so the user can undo this operation.
        /// </summary>
        /// <param name="undo">The collection of undo commands</param>
        public void AddUndo(UndoRedoCollection undo)
        {
            this.undoStack.Push(undo);
        }

        /// <summary>
        /// Adds a cell to the redoStack so the user can redo this operation.
        /// </summary>
        /// <param name="redo">The collection of redo commands</param>
        public void AddRedo(UndoRedoCollection redo)
        {
            this.redoStack.Push(redo);
        }

        /// <summary>
        /// Undoes the last item in the undo stack
        /// </summary>
        /// <param name="s">the sheet array</param>
        public void Undo(Spreadsheet s)
        {
            if (this.undoStack.Count > 0)
            {
                // We pop the commands that we need to execute
                UndoRedoCollection undoCollection = this.undoStack.Pop();

                // Execute Undo
                undoCollection.ExecuteUndo(s);

                // We want to push the command that was last executed into the redo stack
                this.redoStack.Push(undoCollection);
            }
        }

        /// <summary>
        /// Redoes the last item in the redo stack
        /// </summary>
        /// <param name="s">The sheet array</param>
        public void Redo(Spreadsheet s)
        {
            // We pop the commands that we need to execute
            UndoRedoCollection redoCollection = this.redoStack.Pop();

            // Execute Redo
            redoCollection.ExecuteUndo(s);

            // We want to push the command that was last executed into the undo stack
            this.undoStack.Push(redoCollection);
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
        /// Getter for column count
        /// </summary>
        /// <returns>the column count</returns>
        public int GetRedoStackCount()
        {
            return this.redoStack.Count;
        }

        /// <summary>
        /// Getter for column count
        /// </summary>
        /// <returns>the column count</returns>
        public int GetUndoStackCount()
        {
            return this.undoStack.Count;
        }

        /// <summary>
        /// Get the cell at given index
        /// </summary>
        /// <param name="rowIndex">index of row</param>
        /// <param name="colIndex">index of column.</param>
        /// <returns>The cell location</returns>
        public Cell GetCell(int rowIndex, int colIndex)
        {
            if (rowIndex >= this.rowCount || colIndex >= this.columnCount)
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
        public Cell GetCell(string name)
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
        /// Get the string of the property that was changed from the undo stack
        /// </summary>
        /// <returns>String of property change</returns>
        public string PeekUndoStack()
        {
            return this.undoStack.Peek().ChangedProperty;
        }

        /// <summary>
        /// Get the string of the property that was changed from the redo stack
        /// </summary>
        /// <returns>String of property change</returns>
        public string PeekRedoStack()
        {
            return this.redoStack.Peek().ChangedProperty;
        }

        /// <summary>
        /// Load xml data into the sheet array
        /// </summary>
        /// <param name="stream">The file stream</param>
        public void LoadXml(Stream stream)
        {
            // Clear spreadsheet
            this.ResetSpreadsheet(50, 26);

            XmlDocument doc = new XmlDocument();
            
            // Load the file
            doc.Load(stream);

            // Save all the element tag names into it's appropriate list
            XmlNodeList coordList = doc.GetElementsByTagName("name");
            XmlNodeList textList = doc.GetElementsByTagName("text");
            XmlNodeList colorList = doc.GetElementsByTagName("bgcolor");

            // Iterate through xml node list, and store each value into the cell
            for (int i = 0; i < coordList.Count; i++)
            {
                Cell loadedCell = this.GetCell(coordList[i].InnerXml);
                loadedCell.Text = textList[i].InnerXml;
                loadedCell.BGColor = Convert.ToUInt32(colorList[i].InnerXml);

                // Commit changes to the cell
                this.OnPropertyChanged("Cell", loadedCell);
            }

            this.undoStack.Clear();
            this.redoStack.Clear();
        }

        /// <summary>
        /// Save cell spreadsheet array data to XML
        /// </summary>
        /// <param name="stream">The file stream</param>
        public void SaveToXml(Stream stream)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create(stream, settings))
            {
                writer.WriteStartElement("spreadsheet");

                foreach (Cell cell in this.SheetArray)
                {
                    // Check if cell is not a default cell and that it has been changed by user
                    if (cell.Text != string.Empty || cell.BGColor != 0xFFFFFFFF)
                    {
                        writer.WriteStartElement("cell");
                        writer.WriteElementString("name", cell.StringIndex);
                        writer.WriteElementString("bgcolor", cell.BGColor.ToString());
                        writer.WriteElementString("text", cell.Text);
                        writer.WriteEndElement();
                    }
                }

                writer.WriteEndElement();
            }
        }

        /// <summary>
        /// Create the OnPropertyChanged method to raise the event
        /// The calling member's name will be used as the parameter.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event argument e</param>
        protected void CellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Iteration of even property changed
            this.iteration++;

            // Check if it
            if (sender is Cell cell)
            {
                // Check if the property changed is text
                // Else, the property is "Value"
                if (e.PropertyName == "Text")
                {
                    // Check if cell is an expressive value
                    // Check if the string is empty
                    if (cell.Text == string.Empty)
                    {
                        cell.MyExpressionTree = null;
                    }
                    else if (cell != null && cell.Text[0] == '=')
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

                                    if (tempCell != null)
                                    {
                                        tempCell.PropertyChanged -= cell.CellPropertyChanged;
                                    }
                                }
                            }

                            // Build new expression tree
                            InfixToPostfix postfix = new InfixToPostfix();
                            string[] tokenizedLine = Regex.Split(cell.Text.Substring(1), @"([*()\^\/]|(?<!E)[\+\-])");
                            string[] expression = postfix.Convert(tokenizedLine);
                            Array.Reverse(expression);
                            cell.MyExpressionTree = new ExpressionTree(expression);

                            // Scroll through each substring in the expression
                            foreach (string token in expression)
                            {
                                // Check if substring in the variable dictionary
                                // else, evaluate expression as is
                                if (cell.MyExpressionTree.CheckDictionary(token))
                                {
                                    // Get the cell from the substring, which is a variable name
                                    Cell tempCell = this.GetCell(token);
                                    
                                    // Check if it's a valid cell entry
                                    if (tempCell == null)
                                    {
                                        this.SheetArray[cell.RowIndex, cell.ColumnIndex].Value = "!(Bad Reference)";
                                        this.OnPropertyChanged("Text", cell);
                                        return;
                                    }

                                    // If it's the first iteration of property change calls, then set the initial cell and temp cell values
                                    if (this.iteration == 1)
                                    {
                                        this.SetCellCheck(cell.StringIndex, cell.Text);
                                        this.SetTempCellCheck(tempCell.StringIndex, tempCell.Text);
                                    }
                        
                                    // Check self reference
                                    if (cell.StringIndex == token)
                                    {
                                        this.SheetArray[cell.RowIndex, cell.ColumnIndex].Value = "!(Self Reference)";
                                        this.OnPropertyChanged("Text", cell);
                                        return;
                                    }

                                    // Checking for circular reference
                                    if (this.cellReference != null && this.tempReference != null)
                                    {
                                        if (tempCell.Value == "!(Circular Reference)")
                                        {
                                            if (tempCell != null)
                                            {
                                                string va = this.GetValueOfCellAt(token);
                                                if (double.TryParse(va, out double cellVal))
                                                {
                                                    cell.MyExpressionTree.SetVariable(token, cellVal);
                                                    this.SheetArray[cell.RowIndex, cell.ColumnIndex].Value = cell.MyExpressionTree.Evaluate().ToString();
                                                }

                                                return;
                                            }
                                        }
    
                                        else if (((cell.StringIndex == this.cellReference[0] && cell.Text == this.cellReference[1] ) || (cell.StringIndex == this.tempReference[0] && cell.Text == this.tempReference[1])) && this.iteration > 2)
                                        {
                                            Cell tempoCell = this.GetCell(this.cellReference[0]);
                                            this.SheetArray[tempoCell.RowIndex, tempoCell.ColumnIndex].Value = "!(Circular Reference)";
                                            return;
                                        }
                                    }

                                    // Get the value of that cell
                                    string stringCellValue = this.GetValueOfCellAt(token);

                                    // Try to parse the string to a double so we can evaluate
                                    if (double.TryParse(stringCellValue, out double cellValue))
                                    {
                                        cell.MyExpressionTree.SetVariable(token, cellValue);
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
        /// Converts the first alphabetical character of column to an index
        /// </summary>
        /// <param name="c">Capital letter</param>
        /// <returns>The correlated index</returns>
        private int CellColumnToIndex(char c)
        {
            return (int)c - 65;
        }

        /// <summary>
        /// We are clearing all the spreadsheet data before loading the file data
        /// </summary>
        /// <param name="numRows">The number of rows</param>
        /// <param name="numColumns">the number of columns</param>
        private void ResetSpreadsheet(int numRows, int numColumns)
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
                    this.SheetArray[row, col].StringIndex = this.CoordsToString(row, col);

                    // We are subscribing to each cell
                    this.SheetArray[row, col].PropertyChanged += new PropertyChangedEventHandler(this.CellPropertyChanged);
                }
            }

            this.columnCount = numColumns;
            this.rowCount = numRows;
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
                if (this.SheetArray[rowIndex, colIndex].Value == string.Empty)
                {
                    return "0.0";
                }

                return this.SheetArray[rowIndex, colIndex].Value;
            }
            else
            {
                return "Could not parse column name";
            }
        }

        /// <summary>
        /// Transform coordinates of cell into its string form
        /// </summary>
        /// <param name="rowIndex">the row index of the cell</param>
        /// <param name="colIndex">the column index of the cell</param>
        /// <returns>The string form for the coordinates</returns>
        private string CoordsToString(int rowIndex, int colIndex)
        {
            char colName = (char)(colIndex + 65);
            string rowString = (rowIndex + 1).ToString();
            return colName + rowString;
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
