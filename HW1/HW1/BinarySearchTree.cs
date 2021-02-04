// <copyright file="BinarySearchTree.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

// height = log(n+1) == O(logn)
//          O       lvl 0
//        /   \
//       O     O    lvl 1
//      / \   / \
//     O   O O   O  lvl 2
namespace HW1
{
    using System;

    /// <summary>
    /// Binary search tree structure for storing integer lists from user, and sorts it.
    /// </summary>
    public class BinarySearchTree
    {
        private Node root;

        /// <summary>
        /// Inserts integers into tree after checking if value is not already inside tree.
        /// I would normally just remove duplicates from listbefore entering Insert, but 
        /// I'm not sure we are allowed to use LINQ, so I'm going to do it a different way.
        /// </summary>
        /// <param name="integerList">integerList is a list of integers with duplicate values.</param>
        public void Insert(int[] integerList)
        {
            foreach (var value in integerList)
            {
                if (!AlreadyContains(this.root, value))
                {
                    // if node is not null then insert into new node
                    if (this.root != null)
                    {
                        this.root.Insert(value);
                    }

                    // if node is null, then initialize the new tree
                    else
                    {
                        this.root = new Node(value);
                    }
                }
            }
        }

        /// <summary>
        /// Checks if value already inside binary tree.
        /// </summary>
        /// <param name="value">value is the integer passed from insert.</param>
        /// <returns>false if binary tree does not contain and true if it does.</returns>
        private static bool AlreadyContains(Node root, int value) // O(Log n)
        {
            if (root == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
