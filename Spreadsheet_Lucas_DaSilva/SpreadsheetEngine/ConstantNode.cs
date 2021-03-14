//-----------------------------------------------------------------------
// <copyright file="Spreadsheet.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------


namespace CptS321
{
    using System.Collections.Generic;

    public class ConstantNode : ExpressionTreeNode
    {
        private readonly double value;

        private Dictionary<string, double> variables;

        public ConstantNode(double value)
        {
            this.value = value;
        }

        /// <summary>
        /// Returns the value of the node using the dictionary of variables, if not found value will be 0.0
        /// </summary>
        /// <returns>0.0 or value assigned to the variable in the dictionary</returns>
        override public double Evaluate()
        {
            return value;
        }
    }

}
