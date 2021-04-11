//-----------------------------------------------------------------------
// <copyright file="UndoText.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CptS321
{
    /// <summary>
    /// Holds the command for executing a change of Text on a cell
    /// </summary>
    internal class UndoText : ICommand
    {
        /// <summary>
        /// The current text
        /// </summary>
        private string currentText;
        
        /// <summary>
        /// The previous text
        /// </summary>
        private string oldText;

        /// <summary>
        /// cell row index
        /// </summary>
        private int cellRow;

        /// <summary>
        /// cell column index
        /// </summary>
        private int cellColumn;

        /// <summary>
        /// Initializes a new instance of the <see cref="UndoText"/> class.
        /// </summary>
        /// <param name="currentText">Current text</param>
        /// <param name="oldText">old text</param>
        /// <param name="rowIndex">row index</param>
        /// <param name="colIndex">column index</param>
        public UndoText(string currentText, string oldText, int rowIndex, int colIndex)
        {
            this.currentText = currentText;
            this.oldText = oldText;
            this.cellRow = rowIndex;
            this.cellColumn = colIndex;
        }

        /// <summary>
        /// Undo the action that was previously issued
        /// </summary>
        /// <param name="sheet">The reference to the spreadsheet</param>
        /// <returns>The either Undo Text or Undo Color commands</returns>
        public ICommand Undo(Spreadsheet sheet)
        {
            Cell cell = sheet.GetCell(this.cellRow, this.cellColumn);
            string tempOldText = cell.Text;
            this.currentText = this.oldText;
            this.oldText = tempOldText;
            cell.Text = this.currentText;

            // old test = 45 and current text == 45
            return new UndoText(this.currentText, this.oldText, this.cellRow, this.cellColumn);
        }
    }
}
