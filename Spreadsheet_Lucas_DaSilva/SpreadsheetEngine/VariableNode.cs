//-----------------------------------------------------------------------
// <copyright file="VariableNode.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CptS321
{
    using System.Collections.Generic;

    /// <summary>
    /// Variable node class, for calculating and storing variables
    /// </summary>
    public class VariableNode : ExpressionTreeNode
    {
        /// <summary>
        /// The name of the variable
        /// </summary>
        private readonly string name;

        /// <summary>
        /// Dictionary that stores value and name of variable
        /// </summary>
        private Dictionary<string, double> variables;

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableNode" class./>
        /// </summary>
        /// <param name="name">Name of variable</param>
        /// <param name="variables">The reference to the dictionary</param>
        internal VariableNode(string name, ref Dictionary<string, double> var)
        {
            this.name = name;
            this.variables = var;
        }

        /// <summary>
        /// Returns the value of the node using the dictionary of variables, if not found value will be 0.0
        /// </summary>
        /// <returns>0.0 or value assigned to the variable in the dictionary</returns>
        public override double Evaluate()
        {
            double value = 0.0;
            if (this.variables.ContainsKey(this.name))
            {
                value = this.variables[this.name];
            }

            return value;
        }
    }
}
