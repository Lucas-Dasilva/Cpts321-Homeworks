//-----------------------------------------------------------------------
// <copyright file="ExpressionTreeTests.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CptS321
{
    using System;
    using System.Text.RegularExpressions;
    using NUnit.Framework;
    
    /// <summary>
    /// Tests for Expression Tree
    /// </summary>
    [TestFixture]
    public class ExpressionTreeTests
    {
        [Test]
        [TestCase("3+5", ExpectedResult = 8.0)]
        [TestCase("100/10*10", ExpectedResult = 100.0)]
        [TestCase("10/(2*5)", ExpectedResult = 1.0)]
        [TestCase("84-14+26", ExpectedResult = 96.0)]
        [TestCase("7-4+2", ExpectedResult = 5.0)]
        [TestCase("(((((2+3)-(4+5)))))", ExpectedResult = -4.0)]
        [TestCase("2 + 3 * 5", ExpectedResult = 17.0)]
        [TestCase("5/0", ExpectedResult = double.PositiveInfinity)]

        /// <summary>
        /// Tests evaluate function
        /// </summary>
        /// <param name="expression">The string expression</param>
        /// <returns>The evaluated value</returns>
        public double TestEvaluate(string expression)
        {
            // Formating
            InfixToPostfix postfix = new InfixToPostfix();
            string[] tokenizedLine = Regex.Split(expression, @"([*()\^\/]|(?<!E)[\+\-])");
            string[] line = postfix.Convert(tokenizedLine);
            Array.Reverse(line);

            // Performing evaluation
            ExpressionTree exp = new ExpressionTree(line);
            return exp.Evaluate();
        }
    }
}
