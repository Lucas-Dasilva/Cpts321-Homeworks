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
        /// <summary>
        /// Pointer to the root node.
        /// </summary>
        private Node root;

        /// <summary>
        /// Inserts integers into tree after checking if value is not already inside tree.
        /// I would normally just remove duplicates from list, before entering Insert, but
        /// I'm not sure we are allowed to use LINQ, so I'm going to do it a different way.
        /// </summary>
        /// <param name="integerList">integerList is a list of integers with duplicate values.</param>
        public void Insert(int[] integerList)
        {
            foreach (var value in integerList)
            {
                // only insert if tree does not contain value
                // if node is not null then insert into new node
                // else initialize the new tree
                if (!this.AlreadyContains(this.root, value))
                {
                    if (this.root != null)
                    {
                        this.root.Insert(this.root, value);
                    }
                    else
                    {
                        this.root = new Node(value);
                    }
                }
            }
        }

        /// <summary>
        /// Recursively print out the sorted BST.
        /// </summary>
        /// <param name="curNode">Root of node, that gets replaced by current node.</param>
        public void PrintSortedBst(Node curNode)
        {
            // upon reaching end of bst, start backtracking
            if (curNode == null)
            {
                return;
            }

            // start at the left most position
            if (curNode != null)
            {
                // Start traversing left
                this.PrintSortedBst(curNode.GetLeftNode());
                Console.WriteLine(curNode.GetValue()); // print value
                this.PrintSortedBst(curNode.GetRightNode());
            }
        }

        /// <summary>
        /// Display number of items, number of levels (height), min number of level given number of items.
        /// </summary>
        public void DisplayStats()
        {
            Console.WriteLine("******Statistics of BST******");

            // Display num of items
            int count;
            count = this.NumberOfItems(this.root);
            Console.WriteLine("Number of Items: {0}", count);

            // Display num height
            int height;
            height = this.HeightOfBst(this.root);
            Console.WriteLine("Height of BST: {0}", height);

            // Display theoretical minimum height
            Console.WriteLine("Theoretical Min Height of BST with count of ({0}): {1}", count, Math.Floor(Math.Log2(count)));
        }

        /// <summary>
        /// Gets the rood node of the BST.
        /// </summary>
        /// <returns>Returns root of BST.</returns>
        public Node GetRoot()
        {
            return this.root;
        }

        /// <summary>
        /// Recursively get the number of items in BST.
        /// </summary>
        /// <param name="curNode">Pointer to current node.</param>
        /// <returns>returns the number of items in BST(integer).</returns>
        private int NumberOfItems(Node curNode)
        {
            int count = 1;

            // start at the left most position
            if (curNode.GetLeftNode() != null)
            {
                // keep track of count for left side
                count += this.NumberOfItems(curNode.GetLeftNode());
            }

            // start at the left most position
            if (curNode.GetRightNode() != null)
            {
                // keep track of count for right side
                count += this.NumberOfItems(curNode.GetRightNode());
            }

            return count;
        }

        /// <summary>
        /// Get the the height of the BST.
        /// </summary>
        /// <param name="curNode">root of tree.</param>
        /// <returns>returns the height of BST.</returns>
        private int HeightOfBst(Node curNode) // O(n)
        {
            // I used GeeksforGeeks youtube video as reference for this function!
            // tree is empty
            if (curNode == null)
            {
                return 0;
            }
            else
            {
                // ffind out the height of the longest path of each subtree
                int leftHeight = this.HeightOfBst(curNode.GetLeftNode());
                int rightHeight = this.HeightOfBst(curNode.GetRightNode());

                // only return the largest one of the two
                if (leftHeight > rightHeight)
                {
                    return leftHeight + 1;
                }
                else
                {
                    return rightHeight + 1;
                }
            }
        }

        /// <summary>
        /// Checks if a given integer is already inside the BST.
        /// </summary>
        /// <param name="root">Points to the current node when traversing through BST.</param>
        /// <param name="value">The new data value that is being used to compare to current node value.</param>
        /// <returns>False if not inside BST, and true otherwise.</returns>
        private bool AlreadyContains(Node root, int value) // O(Log n)
        {
            // if empty, return false
            if (root == null)
            {
                return false;
            }

            // if value == new value, return true
            if (root.GetValue() == value)
            {
                return true;
            }

            // traverse left, if node value is greater than new value
            // else traverse left, if node value is greater than new value
            if (root.GetValue() > value)
            {
                return this.AlreadyContains(root.GetLeftNode(), value);
            }
            else
            {
                return this.AlreadyContains(root.GetRightNode(), value);
            }
        }
    }
}
