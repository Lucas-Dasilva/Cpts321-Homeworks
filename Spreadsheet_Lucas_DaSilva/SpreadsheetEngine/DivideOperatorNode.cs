//-----------------------------------------------------------------------
// <copyright file="DivideOperatorNode.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CptS321
{
    /// <summary>
    /// The class the represents division operations
    /// </summary>
    public class DivideOperatorNode : OperatorNode
    {
        /// <summary>
        /// The operation symbol
        /// </summary>
        public static new char Operator => '/';

        /// <summary>
        /// The order of precedence
        /// </summary>
        public static ushort Precendence => 6;

        /// <summary>
        /// The symbols associativity
        /// </summary>
        public static Associative Associativity => Associative.Left;

        /// <summary>
        /// Evaluation of left and right node
        /// </summary>
        /// <returns>The evaluated value</returns>
        public override double Evaluate()
        {
            return Left.Evaluate() / Right.Evaluate();
        }
    }
}
