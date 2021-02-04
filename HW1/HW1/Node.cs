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
    /// Class node that holds the reference to the left and right node,
    /// and the data value of the current node.
    /// </summary>
    public class Node
    {
        private int value;
        private Node leftNode;
        private Node rightNode;

        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// constructor for node class.
        /// </summary>
        /// <param name="newValue">newVlaue is the integer value for the new node.</param>
        public Node(int newValue)
        {
            this.value = newValue;
        }

        /// <summary>
        /// Insert new Node Value.
        /// </summary>
        /// <param name="newValue">newValue is the data from integer list.</param>
        public void Insert(int newValue)
        {
            // insert into left node
            if (this.value > newValue)
            {
                // if left child is null then create new instance
                if (this.leftNode == null)
                {
                    this.leftNode = new Node(newValue);
                }

                // recursively call until we find an empty node
                else
                {
                    this.Insert(newValue);
                }
            }

            // insert into right node
            else
            {
                // if right child is null then create new instance
                if (this.rightNode == null)
                {
                    this.rightNode = new Node(newValue);
                }

                // recursively call until we find an empty node
                else
                {
                    this.Insert(newValue);
                }
            }
        }

        /// <summary>
        /// gets the node value.
        /// </summary>
        /// <returns>node value.</returns>
        public int GetValue()
        {
            return this.value;
        }
        /// <summary>
        /// returns Left node of tree.
        /// </summary>
        /// <returns>Left node.</returns>
        public Node GetLeftNode()
        {
           return this.leftNode;
        }

        /// <summary>
        /// returns right node of tree.
        /// </summary>
        /// <returns>Right node.</returns>
        public Node GetRightNode()
        {
            return this.rightNode;
        }
    }
}
