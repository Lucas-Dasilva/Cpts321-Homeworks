//-----------------------------------------------------------------------
// <copyright file="ConsoleProgram.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CptS321
{
    /// <summary>
    /// Opening Class of Setup, where we initialize Setup object and call setup.run
    /// </summary>
    public class ConsoleProgram
    {
        /// <summary>
        /// Start of project
        /// </summary>
        /// <param name="args">arguments passed if any</param>
        public static void Main(string[] args)
        {
            Setup initialize = new Setup();
            initialize.Start();
        }
    }
}
