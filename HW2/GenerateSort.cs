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
        /// Calls all functions from this class
        /// </summary>
        /// <returns>returns unique numbers for generateHash</returns>
        public int ConstructSort(List<int> ls)
        {
            int count = this.LinearParse(ls);
            return count;
        }

        /// <summary>
        /// Sort the list using built in function
        /// </summary>
        /// <returns>Returns sorted list of ints</returns>
        public List<int> SortList(List<int> unsortedList)
        {
            unsortedList.Sort();
            return unsortedList;
        }


        /// <summary>
        /// Determine the amount of distinct ints in:
        /// O(1) storage, no dynamic memory allocation, and O(n) time complexity.
        /// </summary>
        /// <param name="sortedIntList"> list with 10k random integers</param>
        /// <returns>Distinct integer list hashset</returns>
        public int NonDynamicLinearParse(List<int> sortedIntList) // O(n)
        {
            int dup = 0;
            for(int i =0; i < sortedIntList.Count; i++)
            {
                if (i != 9999 && sortedIntList[i] == sortedIntList[i+1])
                {
                    dup += 1;
                }
            }
            return (sortedIntList.Count-dup);
        } 
        
        /// <summary>
        /// Determine the amount of distinct ints in O(n) time complexity
        /// </summary>
        /// <param name="sortedIntList"> list with 10k random integers</param>
        /// <returns>Distinct integer list hashset</returns>
        public int LinearParse(List<int> sortedIntList)
        {
            int distinctInts = 0;
            return distinctInts;
        }

    }

    
}
