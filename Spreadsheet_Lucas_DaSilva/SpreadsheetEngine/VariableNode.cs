//-----------------------------------------------------------------------
// <copyright file="Spreadsheet.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------



namespace CptS321
{
    using System.Collections.Generic;

    public class VariableNode : ExpressionTreeNode
    {
        private readonly string name;


        private Dictionary<string, double> variables;

        public VariableNode(string name, ref Dictionary<string, double> variables)
        {
            this.name = name;
            this.variables = variables;
        }

        /// <summary>
        /// Returns the value of the node using the dictionary of variables, if not found value will be 0.0
        /// </summary>
        /// <returns>0.0 or value assigned to the variable in the dictionary</returns>
        override public double Evaluate()
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
