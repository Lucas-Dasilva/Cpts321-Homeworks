//-----------------------------------------------------------------------
// <copyright file="GenerateSort.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace HW2
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Sort the list (use built-in sorting functionality)
    /// then use a new algorithm to determine the number of distinct items with:
    /// O(1) storage, no dynamic memory allocation, and O(n) time complexity.
    /// Do not alter the list further after sorting it.
    /// Determine the number of distinct items in O(n) time
    /// </summary>
    public class GenerateSort
    {
        /// <summary>
        /// Sort the list using built in function
        /// </summary>
        /// <param name="unsortedList"> random List</param>
        /// <returns>Returns sorted list of integers</returns>
        public List<int> SortList(List<int> unsortedList)
        {
            unsortedList.Sort();
            return unsortedList;
        }


        /// <summary>
        /// Determine the amount of distinct integers in:
        /// O(1) storage, no dynamic memory allocation, and O(n) time complexity.
        /// </summary>
        /// <param name="sortedIntList"> list with 10k random integers</param>
        /// <returns>Distinct integer list hash set</returns>
        public int NonDynamicLinearParse(List<int> sortedIntList) // O(n)
        {
            // dup is used to track the amount of duplicates we run over
            int dup = 0;
            // Decrease bounds by 2 because I don't want list go out of range
            for (int i = 0; i < (sortedIntList.Count - 1); i++)
            {
                // If the next value is equal to current value, increment dup
                if (sortedIntList[i] == sortedIntList[i + 1])
                {
                    dup += 1;
                }
            }
            // return the total length of list minus the amount of diplicates found
            return (sortedIntList.Count - dup);
        } 

    }

    
}
