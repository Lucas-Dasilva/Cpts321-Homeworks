using NUnit.Framework;

namespace CptS321
{
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

        public double TestEvaluate(string expression)
        {
            ExpressionTree exp = new ExpressionTree(expression);
            return exp.Evaluate();
        }
    }
}
