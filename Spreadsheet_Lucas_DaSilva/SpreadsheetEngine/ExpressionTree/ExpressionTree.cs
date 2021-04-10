//-----------------------------------------------------------------------
// <copyright file="ExpressionTree.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CptS321
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Parent class to all expression tree nodes and children nodes
    /// </summary>
    internal partial class ExpressionTree
    {
        /// <summary>
        /// Dictionary for holding variables
        /// </summary>
        private Dictionary<string, double> variables;

        /// <summary>
        /// The root node, used for evaluating expression
        /// </summary>
        private ExpressionTreeNode root;

        /// <summary>
        /// Saves original Expression into string array
        /// </summary>
        private string[] expression;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// </summary>
        /// <param name="exp">The expression string</param>
        public ExpressionTree(string[] exp)
        {
            // Saving expression and creating new dictionary
            this.expression = exp;
            this.variables = new Dictionary<string, double>();

            // Creating stack of nodes
            Stack<ExpressionTreeNode> nodeStack = new Stack<ExpressionTreeNode>();

            // Factory for operator nodes
            OperatorNodeFactory factory = new OperatorNodeFactory();

            // Looping through string array to build the tree
            for (int i = 0; i < exp.Length; i++)
            {
                string c = exp[i];

                // checking if string is empty
                // checking if string is an operrand
                // Checking if string is a Constant number(double or int)
                // Else it's a variable
                if (c == string.Empty)
                {
                    continue;
                }
                else if (c == "/" || c == "*" || c == "+" || c == "-")
                {
                    // Popping two operands 
                    ExpressionTreeNode tmp1 = nodeStack.Pop();
                    ExpressionTreeNode tmp2 = nodeStack.Pop();
                    
                    // Creating operator node then having it point to the two operands
                    OperatorNode operatorNode = factory.CreateOperatorNode(char.Parse(c));
                    operatorNode.Left = tmp2;
                    operatorNode.Right = tmp1;

                    // Making the operator node the new stack pointer
                    nodeStack.Push(operatorNode);
                }
                else if (double.TryParse(exp[i], out double n))
                {
                    try
                    {
                        ExpressionTreeNode consNode = new ConstantNode(n);
                        nodeStack.Push(consNode);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    try
                    {
                        if (this.CheckDictionary(exp[i]))
                        {
                            // Update key value if already exists
                            this.variables[exp[i]] = 0.0;
                            ExpressionTreeNode varNode = new VariableNode(exp[i], ref this.variables);
                            nodeStack.Push(varNode);
                        }
                        else
                        {
                            this.variables.Add(exp[i], 0);
                            ExpressionTreeNode varNode = new VariableNode(exp[i], ref this.variables);
                            nodeStack.Push(varNode);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            // setting the root to the final pointer to the tree which is usually an operator
            this.root = nodeStack.Peek();
        }

        /// <summary>
        /// Sets the specified variable within the ExpressionTree variables dictionary
        /// </summary>
        /// <param name="name">The name of the variable from user</param>
        /// <param name="value">The value given to the variable</param>
        public void SetVariable(string name, double value)
        {
            // The Add method throws an exception if the new key is
            // already in the dictionary.
            try
            {
                // Try to add
                this.variables.Add(name, value);
            }
            catch
            {
                // Update key value if already exists
                this.variables[name] = value;
            }
        }

        /// <summary>
        /// Implement this method with no parameters that evaluates the expression to a double value
        /// </summary>
        /// <returns>the evaluated expression</returns>
        public double Evaluate()
        {
            // If tree is built and all Dictionary names have a value
            // Else, inquire user of error
            if (this.root != null)
            {
                return this.EvaluateHelper();
            }
            else
            {
                Console.WriteLine("Tree Not Built Or Not All Variables Have A Value!");
            }

            return 0.0;
        }

        /// <summary>
        /// Gets a list of variables in the dictionary
        /// </summary>
        /// <returns>String array of variables</returns>
        public List<string> GetAllVariables()
        {
            List<string> varList = new List<string>();
            foreach (string var in this.variables.Keys)
            {
                varList.Add(var);
            }

            return varList;
        }

        /// <summary>
        /// Checks if the variable name is in the dictionary
        /// </summary>
        /// <param name="name">The name of the variable from user</param>
        /// <returns>Returns true if the key is dictionary</returns>
        public bool CheckDictionary(string name)
        {
            if (this.variables.ContainsKey(name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Evaluates the expression if all variables are filled in
        /// </summary>
        /// <returns>The evaluated expression</returns>
        private double EvaluateHelper()
        {
            return this.root.Evaluate();
        }
    }
}
