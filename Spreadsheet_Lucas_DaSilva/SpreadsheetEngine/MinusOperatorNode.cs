//-----------------------------------------------------------------------
// <copyright file="MinusOperatorNode.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CptS321
{
    /// <summary>
    /// The minus operator class that performs subtraction
    /// </summary>
    public class MinusOperatorNode : OperatorNode
    {
        /// <summary>
        /// Declaring operator character
        /// </summary>
        public static new char Operator => '-';

        /// <summary>
        /// Declaring operation precedence
        /// </summary>
        public static ushort Precedence => 7;

        /// <summary>
        /// Declaring operation associativity
        /// </summary>
        public static Associative Associativity => Associative.Left;

        /// <summary>
        /// Evaluates based on operation
        /// </summary>
        /// <returns>The subtracted values </returns>
        public override double Evaluate()
        {
            return Left.Evaluate() - Right.Evaluate();
        }
    }
}
