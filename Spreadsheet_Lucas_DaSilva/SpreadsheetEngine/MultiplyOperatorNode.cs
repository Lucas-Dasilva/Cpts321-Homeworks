using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    public class MultiplyOperatorNode : OperatorNode
    {
        /// <summary>
        /// Declaring multiplication operator
        /// </summary>
        public static char Operator => '*';

        /// <summary>
        /// Declaring it's precendence
        /// </summary>
        public static ushort Precendence => 6;

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