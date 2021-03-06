//-----------------------------------------------------------------------
// <copyright file="Setup.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CptS321
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Sets up the menu and the project
    /// </summary>
    internal class Setup
    {
        /// <summary>
        /// Starts the menu
        /// </summary>
        public void Start()
        {
            // Menu options
            string[] options = { "Enter a New Expression", "Set a variable Value", "Evaluate Tree", "Quit" };

            // Initialize objects and variables
            Menu mainMenu = new Menu(options);
            InfixToPostfix postfix = new InfixToPostfix();
            string[] line = new string[25];

            // User must first Create an expression tree
            Console.Write("Enter an expression: ");
            line[0] = Console.ReadLine();
            string prompt = line[0];

            // Tokenize string 
            string[] tokenizedLine = Regex.Split(line[0], @"([*()\^\/]|(?<!E)[\+\-])");

            // Converting from infix to postfix
            line = postfix.Convert(tokenizedLine);
            Array.Reverse(line);

            // Build expression tree
            ExpressionTree tree = new ExpressionTree(line);

            int selectedIndex = mainMenu.Run(prompt);
            do
            {
                switch (selectedIndex)
                {
                    case 0:
                        // Query user for expression
                        Console.Write("Enter an expression: ");
                        line[0] = Console.ReadLine();
                        prompt = line[0];

                        // Tokenize string 
                        tokenizedLine = Regex.Split(line[0], @"([*()\^\/]|(?<!E)[\+\-])");

                        // Converting from infix to postfix
                        line = postfix.Convert(tokenizedLine);  
                        Array.Reverse(line);

                        // Build expression tree
                        tree = new ExpressionTree(line);
                        break;

                    case 1:
                        // Set new variable value
                        Console.Clear();
                        Console.Write("Enter Variable Name: ");
                        string name = Console.ReadLine();

                        // check if key is in dictionary
                        if (tree.CheckDictionary(name))
                        {
                            Console.Clear();
                            Console.Write("Enter Value for \"{0}\": ", name);
                            double value = Convert.ToDouble(Console.ReadLine());
                            tree.SetVariable(name, value);
                        }
                        else
                        {
                            Console.Write("That variable is not in the dictionary...");
                            Console.ReadLine();
                        }

                        break;

                    case 2:
                        // Evaluate the value
                        Console.Write("Value for expression[{0}]: {1}\n", prompt, tree.Evaluate().ToString());
                        Console.Write("Press any key to continue...");
                        Console.ReadLine();
                        break;

                    case 3:
                        // Quit
                        Environment.Exit(0); // Terminates Console
                        break;
                }

                selectedIndex = mainMenu.Run(prompt);
            }
            while (selectedIndex != 3);
        }
    }
}
