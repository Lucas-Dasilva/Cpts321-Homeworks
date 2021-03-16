//-----------------------------------------------------------------------
// <copyright file="ConstantNode.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CptS321
{
    using System.Collections.Generic;

    /// <summary>
    /// The class the represents a constant integer
    /// </summary>
    public class ConstantNode : ExpressionTreeNode
    {
        /// <summary>
        /// The value of the number
        /// </summary>
        private readonly double value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantNode"/> class.
        /// </summary>
        /// <param name="value">The value of the integer</param>
        public ConstantNode(double value)
        {
            this.value = value;
        }

        /// <summary>
        /// Returns the value of the node using the dictionary of variables, if not found value will be 0.0
        /// </summary>
        /// <returns>0.0 or value assigned to the variable in the dictionary</returns>
        public override double Evaluate()
        {
            return this.value;
        }
    }
}
