//-----------------------------------------------------------------------
// <copyright file="UndoText.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CptS321
{
    internal class UndoText : ICommand
    {
        /// <summary>
        /// 
        /// </summary>
        private string currentText;
        
        /// <summary>
        /// 
        /// </summary>
        private string oldText;

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
        public UndoText(string currentText, string oldText, int rowIndex, int colIndex)
        {
            this.currentText = currentText;
            this.oldText = oldText;
            this.cellRow = rowIndex;
            this.cellColumn = colIndex;
        }

        public ICommand Do(Spreadsheet s)
        {
            Cell cell = s.GetCell(cellRow, cellColumn);
            string oldText = cell.Text;
            cell.Text = this.oldText;

            return new UndoText(oldText, this.currentText, this.cellRow, this.cellColumn);
        }

        public ICommand Undo(Spreadsheet s)
        {
            Cell cell = s.GetCell(cellRow, cellColumn);
            string oldText = cell.Text;
            cell.Text = this.oldText;

            return new UndoText(oldText, this.currentText, this.cellRow, this.cellColumn);
        }
    }
}
