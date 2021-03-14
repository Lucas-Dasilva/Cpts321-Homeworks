//-----------------------------------------------------------------------
// <copyright file="Spreadsheet.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CptS321
{
    /// <summary>
    /// Abstract used to call Evaluate on each operation node
    /// </summary>
    public abstract class ExpressionTreeNode
    {
        /// <summary>
        /// Evaluates the nodes based on operation
        /// </summary>
        /// <returns>Value from evaluating the operator node</returns>
        public abstract double Evaluate();
    }
}
