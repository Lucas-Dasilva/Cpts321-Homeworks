//-----------------------------------------------------------------------
// <copyright file="ICommand.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CptS321
{
    /// <summary>
    /// The command interface for executing undo and redo commands
    /// </summary>
    internal interface ICommand
    {
        /// <summary>
        /// Undoes the last action executed
        /// </summary>
        /// <param name="s">The spreadsheet array</param>
        /// <returns>Returns the new updated command list</returns>
        ICommand Undo(Spreadsheet s);
    }
}
