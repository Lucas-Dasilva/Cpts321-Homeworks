//-----------------------------------------------------------------------
// <copyright file="Spreadsheet.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------



namespace SpreadsheetEngine
{
    using System;

    partial class ExpressionTree
    {
        public class OperatorNodeFactory
        {
            /// <summary>
            /// Returns an OperatorNode
            /// </summary>
            public OperatorNode CreateOperatorNode(char op)
            {

                return OperatorNode;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="expression"></param>
            /// <param name="op"></param>
            /// <returns></returns>
            private static Node Compile(string expression, char op)
            {
                // track the parentheses
                int parenthesisCounter = 0;
                // iterate from back to front
                for (int expressionIndex = expression.Length - 1; expressionIndex >= 0; expressionIndex--)
                {
                    // if closed parenthisis INcrement the counter
                    if (')' == expression[expressionIndex])
                    {
                        parenthesisCounter++;
                    }
                    // if open parenthisis DEcrement the counter
                    else if ('(' == expression[expressionIndex])
                    {
                        parenthesisCounter--;
                    }
                    // if the counter is at 0 and we have the operator that we are looking for
                    if (0 == parenthesisCounter && op == expression[expressionIndex])
                    {
                        // build an operator node
                        OperatorNode operatorNode = new OperatorNode(expression[expressionIndex]);
                        // and start over with the left and right sub-expressions
                        operatorNode.Left = Compile(expression.Substring(0, expressionIndex));
                        operatorNode.Right = Compile(expression.Substring(expressionIndex + 1));
                        return operatorNode;
                    }
                }

                // if the counter is not at 0 something was off
                if (parenthesisCounter != 0)
                {
                    // throw a general exception
                    throw new Exception();
                }
                // we did not find the operator
                return null;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="s"></param>
            /// <returns></returns>
            private static Node Compile(string s)
            {
                if (string.IsNullOrEmpty(s))
                {
                    return null;
                }

                // Check for extra parentheses and get rid of them, e.g. (((((2+3)-(4+5)))))
                if ('(' == s[0])
                {
                    int parenthesisCounter = 1;
                    for (int characterIndex = 1; characterIndex < s.Length; characterIndex++)
                    {
                        // if open parenthisis increment a counter
                        if ('(' == s[characterIndex])
                        {
                            parenthesisCounter++;
                        }
                        // if closed parenthisis decrement the counter
                        else if (')' == s[characterIndex])
                        {
                            parenthesisCounter--;
                            // if the counter is 0 check where we are
                            if (0 == parenthesisCounter)
                            {
                                if (characterIndex != s.Length - 1)
                                {
                                    // if we are not at the end, then get out (there are no extra parentheses)
                                    break;
                                }
                                else
                                {
                                    // Else get rid of the outer most parentheses and start over
                                    return Compile(s.Substring(1, s.Length - 2));
                                }
                            }
                        }
                    }
                }

                // define the operators we want to look for in that order
                char[] operators = { '+', '-', '*', '/', '^' };
                foreach (char op in operators)
                {
                    Node n = Compile(s, op);
                    if (n != null) return n;
                }

                // what can we see here?  
                double number;
                // a constant
                if (double.TryParse(s, out number))
                {
                    // We need a ConstantNode
                    return new ConstantNode()
                    {
                        Value = number
                    };
                }
                // or variable
                else
                {
                    // We need a VariableNode
                    return new VariableNode()
                    {
                        Name = s
                    };
                }
            }
        }
    }
}
