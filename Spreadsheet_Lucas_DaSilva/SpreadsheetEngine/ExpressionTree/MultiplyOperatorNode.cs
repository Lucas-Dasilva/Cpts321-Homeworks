//-----------------------------------------------------------------------
// <copyright file="MultiplyOperatorNode.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CptS321
{
    /// <summary>
    /// The multiply class the performs multiplication and determines precedence
    /// </summary>
    internal class MultiplyOperatorNode : OperatorNode
    {
        /// <summary>
        /// Declaring multiplication operator
        /// </summary>
        public static new char Operator => '*';

        /// <summary>
        /// Declaring it's precedence
        /// </summary>
        public static ushort Precedence => 6;

        /// <summary>
        /// Declaring it's associativity
        /// </summary>
        public static Associative Associativity => Associative.Left;

        /// <summary>
        /// Evaluating based on the operator
        /// </summary>
        /// <returns>The multiplied values</returns>
        public override double Evaluate()
        {
            return Left.Evaluate() * Right.Evaluate();
        }
    }
}