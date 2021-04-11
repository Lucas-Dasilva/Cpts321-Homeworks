//-----------------------------------------------------------------------
// <copyright file="UndoRedoCollection.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CptS321
{
    /// <summary>
    /// Holds the collection of Undo and Redo actions
    /// </summary>
    internal class UndoRedoCollection
    {
        /// <summary>
        /// The property that was changed
        /// </summary>
        private string changedProperty;

        /// <summary>
        /// The list of commands for either redo or undo stack
        /// </summary>
        private ICommand[] commands;

        /// <summary>
        /// Initializes a new instance of the <see cref="UndoRedoCollection"/> class.
        /// </summary>
        public UndoRedoCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UndoRedoCollection"/> class.
        /// </summary>
        /// <param name="propertyName">The property that is being changed</param>
        /// <param name="cmd">The list of commands</param>
        public UndoRedoCollection(string propertyName, ICommand[] cmd)
        {
            this.changedProperty = propertyName;
            this.commands = cmd;
        }

        /// <summary>
        /// Gets or sets the change property name
        /// </summary>
        public string ChangedProperty
        {
            // getter for the cell property
            get
            {
                return this.changedProperty;
            }

            // Setter for the cell property
            set
            {
                this.changedProperty = value;
            }
        }

        /// <summary>
        /// Gets or sets the command list
        /// </summary>
        public ICommand[] CommandList
        {
            get
            {
                return this.commands;
            }

            set
            {
                this.CommandList = value;
            }
        }

        /// <summary>
        /// Runs undo on each individual cell
        /// </summary>
        /// <param name="referenceSheet">The spreadsheet that we can reference back to</param>
        public void ExecuteUndo(Spreadsheet referenceSheet)
        {
            foreach (ICommand cmd in this.commands)
            {
                cmd.Undo(referenceSheet);
            }
        }
    }
}
