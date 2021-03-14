//-----------------------------------------------------------------------
// <copyright file="Spreadsheet.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------


namespace CptS321
{
    /// <summary>
    /// An abstract class used for assigning value of operator node and it's children
    /// </summary>
    public abstract class OperatorNode : ExpressionTreeNode
    {
        /// <summary>
        /// Creating an associative type for operator node
        /// </summary>
        public enum Associative
        {
            Right,
            Left
        };

        /// <summary>
        /// The operator character
        /// </summary>
        public char Operator { get; set; }

        /// <summary>
        /// Points to the left tree node
        /// </summary>
        public ExpressionTreeNode Left { get; set; }

        /// <summary>
        /// Points to right tree node
        /// </summary>
        public ExpressionTreeNode Right { get; set; }
    }
}
