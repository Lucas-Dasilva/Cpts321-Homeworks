//-----------------------------------------------------------------------
// <copyright file="Spreadsheet.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------


namespace Cpts321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    partial class ExpressionTree
    {

        private Node root;

        private Dictionary<string, double> variables = new Dictionary<string, double>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTreeCodeDemo.Expression"/> class.
        /// </summary>
        public ExpressionTree(string expression)
        {
            //root = Compile(expression);
        }

        

        

        // Precondition: n is non-null
        private double Evaluate(Node node)
        {
            // try to evaluate the node as a constant
            // the "as" operator is evaluated to null 
            // as opposed to throwing an exception
            ConstantNode constantNode = node as ConstantNode;
            if (null != constantNode)
            {
                return constantNode.Value;
            }

            // as a variable
            VariableNode variableNode = node as VariableNode;
            if (null != variableNode)
            {
                return variables[variableNode.Name];
            }

            // it is an operator node if we came here
            OperatorNode operatorNode = node as OperatorNode;
            if (null != operatorNode)
            {
                // but which one?
                switch (operatorNode.Operator)
                {
                    case '+':
                        return Evaluate(operatorNode.Left) + Evaluate(operatorNode.Right);
                    case '-':
                        return Evaluate(operatorNode.Left) - Evaluate(operatorNode.Right);
                    case '*':
                        return Evaluate(operatorNode.Left) * Evaluate(operatorNode.Right);
                    case '/':
                        return Evaluate(operatorNode.Left) / Evaluate(operatorNode.Right);
                    case '^':
                        return Math.Pow(Evaluate(operatorNode.Left), Evaluate(operatorNode.Right));
                    default: // if it is not any of the operators that we support, throw an exception:
                        throw new NotSupportedException(
                            "Operator " + operatorNode.Operator.ToString() + " not supported.");
                }
            }

            throw new NotSupportedException();
        }

        /// <summary>
        /// Implement this method with no parameters that evaluates the expression to a double
        /// value
        /// </summary>
        /// <returns></returns>

        public double Evaluate()
        {
            return Evaluate(root);
        }

        /// <summary>
        /// Sets the specified variable within the ExpressionTree variables dictionary
        /// </summary>
        /// <param name="variableName"></param>
        /// <param name="variableValue"></param>
        public void SetVariable(string name, double value)
        {
            variables[name] = value;
        }
    }
}
