//-----------------------------------------------------------------------
// <copyright file="UndoBgColor.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CptS321
{
    internal class UndoBgColor : ICommand
    {
        /// <summary>
        /// 
        /// </summary>
        private uint currentColor;

        /// <summary>
        /// 
        /// </summary>
        private uint oldColor;

        /// <summary>
        /// 
        /// </summary>
        private int cellRow;

        /// <summary>
        /// 
        /// </summary>
        private int cellColumn;

        /// <summary>
        /// Initializes a new instance of the <see cref="UndoText"/> class.
        /// </summary>
        /// <param name="currentText"></param>
        /// <param name="oldText"></param>
        /// <param name="rowIndex"></param>
        /// <param name="colIndex"></param>
        public UndoBgColor(uint currentColor, uint oldColor, int rowIndex, int colIndex)
        {
            this.currentColor = currentColor;
            this.oldColor = oldColor;
            this.cellRow = rowIndex;
            this.cellColumn = colIndex;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public ICommand Do(Spreadsheet s)
        {
            Cell cell = s.GetCell(this.cellRow, this.cellColumn);
            uint oldColor = cell.BGColor;
            cell.BGColor = this.oldColor;

            return new UndoBgColor(oldColor, currentColor, cellRow, cellColumn);
        }

        public ICommand Undo(Spreadsheet s)
        {
            throw new System.NotImplementedException();
        }
    }
}
