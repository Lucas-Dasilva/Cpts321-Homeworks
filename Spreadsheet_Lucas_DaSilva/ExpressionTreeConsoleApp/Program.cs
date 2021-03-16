//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CptS321
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Opening Class of Setup, where we initialize Setup object and call setup.run
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Start of project
        /// </summary>
        /// <param name="args">arguments passed if any</param>
        public static void Main(string[] args)
        {
            while (true)
            {
                Setup initialize = new Setup();
                initialize.Start();
            }
        }
    }
}
