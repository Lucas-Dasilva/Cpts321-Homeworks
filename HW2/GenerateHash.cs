//-----------------------------------------------------------------------
// <copyright file="GenerateHash.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace HW2
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Use the Random class to create a list with 10,000 random 
    /// integers in the range[0, 20000]
    /// Then determine how many distinct integers are in the list with 3 different approaches.
    /// Also, have them run in the order listed below. Do not change the order.
    /// </summary>
    public class GenerateHash
    {
        /// <summary>
        /// Calls all functions from this class
        /// </summary>
        /// <param name="ls"> random List</param>
        /// <returns>returns unique numbers for generateHash</returns>
        public int ConstructHash(List<int> ls)
        {
            HashSet<int> set = this.ListParser(ls);
            int count = this.CountDistinctInts(set);
            return count;
        }

        /// <summary>
        /// Generate list with 10,000 random integers 
        /// </summary>
        /// <param name="rnd"> takes in random seed</param>
        /// <returns>list of integers</returns>
        public List<int> CreateList(Random rnd)
        {
            List<int> randIntList = new List<int>();
            for (int i = 0; i < 10000; i++)
            {
                randIntList.Add(rnd.Next(0, 20000));
            }
            return randIntList;
        }

        /// <summary>
        /// Filter out integer list and put only distinct integers inside hash set 
        /// </summary>
        /// <param name="randIntList"> list with 10k random integers</param>
        /// <returns>Distinct integer list hash set</returns>
        public HashSet<int> ListParser(List<int> randIntList)
        {
            HashSet<int> distinctIntSet = new HashSet<int>();
            foreach (int value in randIntList) // O(n) 
            {
                // if the hashset does not already contain the value
                if (!distinctIntSet.Contains(value)) // O(1)
                {
                    distinctIntSet.Add(value); // O(1)
                }
            }
            return distinctIntSet;
        }

        /// <summary>
        /// Counts the amount of distinct integers in list
        /// </summary>
        /// <param name="distinctIntSet">The hashset containing distinct integers</param>
        /// <returns>number of elements in hash set</returns>
        public int CountDistinctInts(HashSet<int> distinctIntSet)
        {
            return distinctIntSet.Count;
        }
        
    }

    
}
