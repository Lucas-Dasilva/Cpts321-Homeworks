//-----------------------------------------------------------------------
// <copyright file="UndoRedoCollection.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
using System.Collections.Generic;

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
        /// 
        /// </summary>
        private ICommand[] commands;


        public UndoRedoCollection()
        {
            //TODO:
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
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

        public UndoRedoCollection Do(Spreadsheet s)
        {
            List<ICommand> cmdList = new List<ICommand>();

            foreach (ICommand cmd in this.commands)
            {
                cmdList.Add(cmd.Do(s));
            }

            return new UndoRedoCollection(this.changedProperty, cmdList.ToArray());

        }
    }
}
