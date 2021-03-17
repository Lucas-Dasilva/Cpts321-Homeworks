//-----------------------------------------------------------------------
// <copyright file="InfixToPostfixTest.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CptS321
{
    using NUnit.Framework;
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// The class for testing infix to postfix
    /// </summary>
    [TestFixture]
    public class InfixToPostFixTest
    {
        [Test]
        [TestCase("3+5", ExpectedResult = "35+")]
        [TestCase("A*(B+C)/D", ExpectedResult = "ABC+*D/")]
        [TestCase("(X*Y+Z)", ExpectedResult = "XY*Z+")]
        [TestCase("(r+(s+t))", ExpectedResult = "rst++")]
        [TestCase("((r+s)+t)", ExpectedResult = "rs+t+")]

        /// <summary>
        /// Tests Convert function
        /// </summary>
        /// <param name="expression">The string expression</param>
        /// <returns>The concerted infix to postfix value</returns>
        public string TestConvert(string expression)
        {
            InfixToPostfix postfix = new InfixToPostfix();
            // Tokenize string 
            string[] tokenizedLine = Regex.Split(expression, @"([*()\^\/]|(?<!E)[\+\-])");
            string[] line = postfix.Convert(tokenizedLine);
            Array.Reverse(line);

            return string.Join("", line);
        }
    }
}
