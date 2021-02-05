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
            // 1. get list of integers from user
            Console.Write("Enter numbers in range [0,100]:");
            string input = Console.ReadLine();

            string[] stringList = input.Split(' ');
            int[] integerList = Array.ConvertAll(stringList, int.Parse);

            // 2. add numbers to a bst
            BinarySearchTree bst = new BinarySearchTree();
            bst.Insert(integerList);

            // 3. display in sorted order
            Console.WriteLine("******Sorted BST******");
            bst.PrintSortedBst(bst.GetRoot());

            // 4. Display stats
            bst.DisplayStats();
        }
    }
}
