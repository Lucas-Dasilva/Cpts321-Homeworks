//-----------------------------------------------------------------------
// <copyright file="Spreadsheet.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------



namespace CptS321
{
    using System;

    /// <summary>
    /// Operator factory class used for creating the operator nodes
    /// </summary>
    public class OperatorNodeFactory 
    {
        /// <summary>
        /// Returns an OperatorNode depending on the character
        /// </summary>
        public OperatorNode CreateOperatorNode(char c)
        {
            // picking case for operator
            switch (c)
            {
                case '+':
                    return new PlusOperatorNode{ };
                case '-':
                    return new MinusOperatorNode { };
                case '*':
                    return new MultiplyOperatorNode { };
                case '/':
                    return new DivideOperatorNode { };
                default: // if it is not any of the operators that we support, throw an exception:
                    throw new NotSupportedException(
                        "Operator " + c + " not supported.");
            }

        }
    }
}
