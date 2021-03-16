//-----------------------------------------------------------------------
// <copyright file="OperatorNode.cs" company="Lucas Da Silva 11631988">
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
            /// <summary>
            /// Represents the right node
            /// </summary>
            Right,

            /// <summary>
            /// represents the left node
            /// </summary>
            Left
        }

        /// <summary>
        /// Gets or sets the operator
        /// </summary>
        public char Operator { get; set; }

        /// <summary>
        /// Gets or sets the left node
        /// </summary>
        public ExpressionTreeNode Left { get; set; }

        /// <summary>
        /// Gets or sets the right node
        /// </summary>
        public ExpressionTreeNode Right { get; set; }
    }
}
