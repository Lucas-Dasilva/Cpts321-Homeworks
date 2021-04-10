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
    internal class UndoRedoCollection : ICommand<string>
    {
        /// <summary>
        /// The property that was changed
        /// </summary>
        private string changedProperty;
        public UndoRedoCollection()
        {
            //TODO:
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        public UndoRedoCollection(string propertyName)
        {
            this.changedProperty = propertyName;
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

        public string Do(string input)
        {
            throw new System.NotImplementedException();
        }

        public string Undo(string input)
        {
            throw new System.NotImplementedException();
        }
    }
}
