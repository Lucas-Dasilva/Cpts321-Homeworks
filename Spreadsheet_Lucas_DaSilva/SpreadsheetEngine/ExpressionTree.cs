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
        private Dictionary<string, double> variables;

        private string expression;
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree.ExpressionTree"/> class.
        /// </summary>
        public ExpressionTree(string exp)
        {
            Stack<ExpressionTreeNode> NodeStack = new Stack<ExpressionTreeNode>();
            OperatorNodeFactory OpFact = new OperatorNodeFactory();
            double value = 0.0;
            for (int i = 0; i < exp.Length; i++)
            {
                //checking if it's an operrand
                if (exp[i] == '/' || exp[i] == '*' || exp[i] == '+' || exp[i] == '-')
                {
                    NodeStack.Pop();
                    NodeStack.Pop();
                    NodeStack.Push(OpFact.CreateOperatorNode(exp[i]));
                }
                else
                {
                    try
                    {
                        NodeStack.Push(new ConstantNode((double)exp[i]));
                    }
                    catch
                    {

                    }
                }


            }
        }

            /// <summary>
            /// Sets the specified variable within the ExpressionTree variables dictionary
            /// </summary>
            /// <param name="variableName"></param>
            /// <param name="variableValue"></param>
            public void SetVariable(string name, double value)
        {
            this.variables.Add(name, value);
        }

        /// <summary>
        /// Implement this method with no parameters that evaluates the expression to a double value
        /// </summary>
        /// <returns></returns>
        public double Evaluate()
        {
            return this.EvaluateHelper(this.expression);
        }
        private double EvaluateHelper(string exp)
        {
            double value = 0.0;
            for(int i = 0; i < exp.Length; i++)
            {
                //checking if it's an operrand
                if (exp[i] == '/' || exp[i] == '*' || exp[i] == '+' || exp[i] == '-')
                {
                }
                else
                {
                   new ConstantNode((double)exp[i]);
                }

            }

            return 0.0;
        }



    }
}
