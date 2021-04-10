//-----------------------------------------------------------------------
// <copyright file="PlusOperatorNode.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CptS321
{
    /// <summary>
    /// The plus operator class that determines the precedence and calculations
    /// </summary>
    internal class PlusOperatorNode : OperatorNode
    {
        /// <summary>
        /// Plus operator
        /// </summary>
        public static new char Operator => '+';

        /// <summary>
        /// Declaring it's precedence
        /// </summary>
        public static ushort Precedence => 7;

        /// <summary>
        /// Declaring the associativity
        /// </summary>
        public static Associative Associativity => Associative.Left;

        /// <summary>
        /// Function used to evaluate
        /// </summary>
        /// <returns>Return value of addition operation</returns>
        public override double Evaluate()
        {
            return Left.Evaluate() + Right.Evaluate();
        }
    }
}