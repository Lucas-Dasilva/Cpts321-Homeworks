namespace HW2.Sort
{
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
        /// Creates List of unsorted random ints
        /// </summary>
        /// <returns></returns>
        public List<int> CreateList()
        {
            List<int> randIntList = new List<int>();
            return randIntList;
        }

        /// <summary>
        /// Sort the list using built in function
        /// </summary>
        /// <returns>Returns sorted list of ints</returns>
        public List<int> SortList(List<int> unsortedList)
        {
            
            return unsortedList;
        }


        /// <summary>
        /// Determine the amount of distinct ints in:
        /// O(1) storage, no dynamic memory allocation, and O(n) time complexity.
        /// </summary>
        /// <param name="sortedIntList"> list with 10k random integers</param>
        /// <returns>Distinct integer list hashset</returns>
        public int NonDynamicLinearParse(List<int> sortedIntList)
        {
            int distinctInts = 0;
            return distinctInts;
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
