// <copyright file="Node.cs" company="PlaceholderCompany">
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
    /// <summary>
    /// Class node that holds the reference to the left and right node,
    /// and the data value of the current node.
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Data value that node holds.
        /// </summary>
        private readonly int value;

        /// <summary>
        /// Pointer to left node.
        /// </summary>
        private Node leftNode;

        /// <summary>
        /// Pointer to right node.
        /// </summary>
        private Node rightNode;

        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// constructor for node class.
        /// </summary>
        /// <param name="newValue">new value is the integer value for the new node.</param>
        public Node(int newValue)
        {
            this.value = newValue;
        }

        /// <summary>
        /// Inserts node into BST.
        /// </summary>
        /// <param name="curNode">Holds current node reference.</param>
        /// <param name="newValue">name="newValue">new value is the data from integer list.</param>
        public void Insert(Node curNode, int newValue)
        {
            // insert into left node
            // else, insert into right node
            if (curNode.value > newValue)
            {
                // if left child is null then create new instance
                // else, recursively call until we find an empty node
                if (curNode.leftNode == null)
                {
                    curNode.leftNode = new Node(newValue);
                }
                else
                {
                    this.Insert(curNode.leftNode, newValue);
                }
            }
            else
            {
                // if right child is null then create new instance
                // else, recursively call until we find an empty node
                if (curNode.rightNode == null)
                {
                    curNode.rightNode = new Node(newValue);
                }
                else
                {
                    this.Insert(curNode.rightNode, newValue);
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