//-----------------------------------------------------------------------
// <copyright file="UndoBgColor.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CptS321
{
    /// <summary>
    /// Holds the command for executing a change of color on a cell
    /// </summary>
    internal class UndoBgColor : ICommand
    {
        /// <summary>
        /// The current color of the cell
        /// </summary>
        private uint currentColor;

        /// <summary>
        /// The last color of the cell
        /// </summary>
        private uint oldColor;

        /// <summary>
        /// The cell row index
        /// </summary>
        private int cellRow;

        /// <summary>
        /// the cell column index
        /// </summary>
        private int cellColumn;

        /// <summary>
        /// Initializes a new instance of the <see cref="UndoBgColor"/> class.
        /// </summary>
        /// <param name="currentColor">The current color of cell</param>
        /// <param name="oldColor">The previous color of the cell</param>
        /// <param name="rowIndex">cell row index</param>
        /// <param name="colIndex">cell column index</param>
        public UndoBgColor(uint currentColor, uint oldColor, int rowIndex, int colIndex)
        {
            this.currentColor = currentColor;
            this.oldColor = oldColor;
            this.cellRow = rowIndex;
            this.cellColumn = colIndex;
        }

        /// <summary>
        /// Undo the action that was previously issued
        /// </summary>
        /// <param name="s">The reference to the spreadsheet</param>
        /// <returns>The either Undo Text or Undo Color commands</returns>
        public ICommand Undo(Spreadsheet s)
        {
            // For either undo or redo, we want to set up each current and old values
            Cell cell = s.GetCell(this.cellRow, this.cellColumn);
            uint tempOldColor = cell.BGColor;
            this.currentColor = this.oldColor;
            this.oldColor = tempOldColor;
            cell.BGColor = this.currentColor;

            return new UndoBgColor(this.currentColor, this.oldColor, this.cellRow, this.cellColumn);
        }
    }
}
