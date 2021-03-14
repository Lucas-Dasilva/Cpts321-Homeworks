//-----------------------------------------------------------------------
// <copyright file="Spreadsheet.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Parent class to all expression tree nodes and children nodes
    /// </summary>
    partial class ExpressionTree
    {
        /// <summary>
        /// Dictionary for holding variables
        /// </summary>
        private Dictionary<string, double> variables = new Dictionary<string, double>();

        /// <summary>
        /// The root node, used for evaluating expression
        /// </summary>
        private ExpressionTreeNode root;

        /// <summary>
        /// Saves original Expression into string array
        /// </summary>
        private string[] expression;

        /// <summary>
        /// A check to see if tree was built
        /// </summary>
        public Boolean treeBuilt = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree.ExpressionTree"/> class.
        /// </summary>
        public ExpressionTree(string[] exp)
        {
            // Saving expression
            this.expression = exp; 

            //Creating stack of nodes
            Stack<ExpressionTreeNode> NodeStack = new Stack<ExpressionTreeNode>();

            //Factory for operator nodes
            OperatorNodeFactory opFact = new OperatorNodeFactory();

            // Looping through string array to build the tree
            for (int i = 0; i < exp.Length; i++)
            {
                string c = exp[i];
                // checking if string is an operrand
                // Checking if string is a Constant number(double or int)
                // Else it's a variable
                if (c == "/" || c == "*" || c == "+" || c == "-")
                {
                    // Popping two operands 
                    ExpressionTreeNode tmp1 = NodeStack.Pop();
                    ExpressionTreeNode tmp2 = NodeStack.Pop();
                    
                    //Creating operator node then having it point to the two operands
                    OperatorNode opNode = opFact.CreateOperatorNode(char.Parse(c));
                    opNode.Left = tmp2;
                    opNode.Right = tmp1;

                    // Making the operator node the new stack pointer
                    NodeStack.Push(opNode);
                }
                else if (double.TryParse(exp[i], out double n))
                {
                    try
                    {
                        ExpressionTreeNode consNode = new ConstantNode(n);
                        NodeStack.Push(consNode);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    try
                    {
                        ExpressionTreeNode varNode = new VariableNode(exp[i], ref this.variables);
                        NodeStack.Push(varNode);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            //setting the root to the final pointer to the tree which is usually an operator
            this.root = NodeStack.Peek();
            this.treeBuilt = true;
        }

        /// <summary>
        /// Sets the specified variable within the ExpressionTree variables dictionary
        /// </summary>
        /// <param name="variableName">The name of the variable from user</param>
        /// <param name="variableValue">The value given to the variable</param>
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
            if (this.root != null && CheckDictionary())
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
        /// Evaluates the expression if all variables arre filled in
        /// </summary>
        /// <param name="exp">The expression from user</param>
        /// <returns>The evaluated expression</returns>
        private double EvaluateHelper()
        {
            return this.root.Evaluate();
        }

        /// <summary>
        /// Cehcks if all variables have a value
        /// </summary>
        /// <returns>True if no other variables require a value</returns>
        private bool CheckDictionary()
        {

            return true;
        }



    }
}
