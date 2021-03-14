using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    public class PlusOperatorNode : OperatorNode
    {
        /// <summary>
        /// Plus operator
        /// </summary>
        public static char Operator => '+';

        /// <summary>
        /// Declaring it's precendence
        /// </summary>
        public static ushort Precendence => 7;

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