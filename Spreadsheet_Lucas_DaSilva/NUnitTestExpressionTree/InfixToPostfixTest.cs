using NUnit.Framework;

namespace Cpts321
{
    [TestFixture]
    public class InfixToPostFixTest
    {
        [Test]
        [TestCase("3+5", ExpectedResult = "35+")]
        [TestCase("A*(B+C)/D", ExpectedResult = "ABC+*D/")]

        public string TestConvert(string expression)
        {
            InfixToPostfix postfix = new InfixToPostfix();

            return postfix.Convert(expression);
        }
    }
}
