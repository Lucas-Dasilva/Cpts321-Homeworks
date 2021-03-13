using System;

namespace Cpts321
{
    class Program
    {
        public static void Main(string[] args)
        {

            while (true)
            {
                Console.Write("Enter expression: ");
                string line = Console.ReadLine();
                ExpressionTree exp = new ExpressionTree(line);
                Console.WriteLine(exp.Evaluate().ToString());

                Console.ReadKey();
            }
        }
    }
}
