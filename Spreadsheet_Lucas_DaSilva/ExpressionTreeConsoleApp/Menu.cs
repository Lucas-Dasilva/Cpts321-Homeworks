//-----------------------------------------------------------------------
// <copyright file="Menu.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CptS321
{
    using System;

    /// <summary>
    /// A custom console menu made by Lucas Da Silva
    /// Go Cougars!
    /// </summary>
    internal class Menu
    {
        /// <summary>
        /// Points to current option
        /// </summary>
        private int selectedIndex;

        /// <summary>
        /// Array of menu options
        /// </summary>
        private string[] options;

        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class.
        /// </summary>
        /// <param name="options">Array of menu options</param>
        public Menu(string[] options)
        {         
            this.options = options;
            this.selectedIndex = 0;
        }

        /// <summary>
        /// Runs the menu
        /// </summary>
        /// <param name="prompt">The prompt that the user sees at the top</param>
        /// <returns>The selected index for switch statement</returns>
        public int Run(string prompt)
        {
            Console.Clear();
            this.DisplayOptions(prompt);
            string line = Console.ReadLine(); // Get string
            while (line != "1" && line != "2" && line != "3" && line != "4")
            {
                Console.Clear();
                Console.WriteLine("Please enter a number between 1 and 4 :)");
                this.DisplayOptions(prompt);
                line = Console.ReadLine(); // Get string
            }

            this.selectedIndex = Convert.ToInt32(line);
            Console.Clear();
            return this.selectedIndex - 1;
        }
        
        /// <summary>
        /// Dis the menu options to console
        /// </summary>
        /// <param name="prompt">The string the user sees</param>
        private void DisplayOptions(string prompt)
        {
            // Main menu message
            Console.WriteLine("Menu (Current expression = \"{0}\")", prompt);
            for (int i = 0; i < this.options.Length; i++)
            {
                // Display the options
                Console.WriteLine("{0}: {1}", i + 1, this.options[i]);
            }
        }
    }
}
