using System;

namespace Cpts321
{
    class Program
    {
        public static void Main(string[] args)
        {

            while (true)
            {
                InfixToPostfix postfix = new InfixToPostfix();

                Console.Write("Enter expression: ");
                string line = Console.ReadLine(); 
                line = postfix.Convert(line);  //Converting from infix to postfix
                ExpressionTree exp = new ExpressionTree(line);
                Console.WriteLine(exp.Evaluate().ToString());
                Console.ReadKey();
            }
        }
    }
}
