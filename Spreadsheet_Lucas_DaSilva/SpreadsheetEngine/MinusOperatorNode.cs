using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    public class MinusOperatorNode : OperatorNode
    {
        /// <summary>
        /// Declaring operatorr character
        /// </summary>
        public static char Operator => '-';

        /// <summary>
        /// Declaring operation precendence
        /// </summary>
        public static ushort Precendence => 7;

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
