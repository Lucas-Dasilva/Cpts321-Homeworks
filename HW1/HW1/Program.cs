// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace HW1
{
    using System;

    /// <summary>
    /// Homework 1 Assignment.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main function calls all.
        /// </summary>
        /// <param name="args"> main arguments.</param>
        public static void Main(string[] args)
        {
            string testInput = "45 23 1 6 7 83 62 56 23 78 45 45 21 23 24 21 89 72 09 21 2 4 3 6 4";

            string[] stringList = testInput.Split(' ');
            int[] integerList = Array.ConvertAll(stringList, int.Parse);



            Console.WriteLine("Hello World!");
        }
    }
}
