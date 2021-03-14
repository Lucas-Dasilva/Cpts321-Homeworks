//-----------------------------------------------------------------------
// <copyright file="Spreadsheet.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
// This code was built using these two sources as help 
// http://math.oxford.emory.edu/site/cs171/shuntingYardAlgorithm/ 
// https://www.geeksforgeeks.org/stack-set-2-infix-to-postfix/


/// <summary>
/// Infix to post fix helper
/// </summary>
namespace Cpts321
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Infix to postfix class
    /// </summary>
    public class InfixToPostfix
    {
        /// <summary>
        /// Converting infix to post using Shunting Algorithm
        /// </summary>
        /// <param name="exp">The expression</param>
        /// <returns>The infix expression</returns>
        public string Convert(string exp)
        {
            // String used to print, and eventually return 
            string postfix = "";

            // initializing empty stack  
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < exp.Length; ++i)
            {

                // If the incoming symbols is a digit
                // If the incoming symbol is a left parenthesis, push it on the stack.
                // If the incoming symbol is a right parenthesis: discard the right parenthesis, 
                // pop and print the stack symbols until you see a left parenthesis.Pop the left
                // parenthesis and discard it.
                // else, we found an operand so print it postfix
                if (char.IsLetterOrDigit(exp[i]))
                {
                    postfix += exp[i];
                }
                else if (exp[i] == '(')
                {
                    stack.Push(exp[i]);
                }
                else if (exp[i] == ')')
                {
                    while (stack.Count > 0 && stack.Peek() != '(')
                    {
                        postfix += stack.Pop();
                    }

                    if (stack.Count > 0 && stack.Peek() != '(')
                    {
                        return "not valid";
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
                else
                {
                    while (stack.Count > 0 && Precedence(exp[i]) <= Precedence(stack.Peek()))
                    {
                        postfix += stack.Pop();
                    }
                    stack.Push(exp[i]);
                }

            }
            // pop all the operators from the stack  
            while (stack.Count > 0)
            {
                postfix += stack.Pop();
            }

            return postfix; //full fledged string
        }

        /// <summary>
        /// Finding precendence of the character
        /// </summary>
        /// <param name="c">Character of infix</param>
        /// <returns>the precendence</returns>
        internal static int Precedence(char c)
        {
            switch (c)
            {
                case '+':
                case '-':
                    return 1;

                case '*':
                case '/':
                    return 2;
            }
            return -1;
        }


    }
}

