//-----------------------------------------------------------------------
// <copyright file="Spreadsheet.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------


namespace Cpts321
{
    public abstract class OperatorNode : ExpressionTreeNode
    {
        /// <summary>
        /// 
        /// </summary>
        public enum Associative
        {
            Right,
            Left
        };
        public char Operator { get; set; }

        public ExpressionTreeNode Left { get; set; }
        public ExpressionTreeNode Right { get; set; }
    }
}
