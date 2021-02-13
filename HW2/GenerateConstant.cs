namespace HW2
{
    using System;
    using System.Collections.Generic;
    public class GenerateConstant
    {
        /// <summary>
        /// Calls all functions from this class
        /// </summary>
        /// <returns>returns unique numbers for generateHash</returns>
        public int ConstructHash(List<int> ls)
        {
            int count = this.ListParser(ls);
            return count;
        }

        /// <summary>
        /// Filter out integer list and put only distinct integers inside int array 
        /// Should be constant storage complexity, no dynamic memory access
        /// </summary>
        /// <param name="randIntList"> list with 10k random integers</param>
        /// <returns>Distinct integer list</returns>
        public int ListParser(List<int> randIntList)
        {
            int[] intArray = new int[10000];
            int distinctCount = 0;
            // dupTracker is used to shift the index of array whenever we get a duplicate
            int dupTracker = 0;
            for (int i =0; i < randIntList.Count; i ++) // O(n)
            {
           
                // if the function returns false, then we can add value to array
                if (!ListParseHelper(randIntList[i], intArray)) // O(n) 
                {
                    intArray[i - dupTracker] = randIntList[i];
                    distinctCount = distinctCount + 1;
                }
                else
                {
                    dupTracker += 1;
                }
            }
            return distinctCount;
        }

        /// <summary>
        /// Helper functions for list parser that checks if array already contains value
        /// </summary>
        /// <param name="value">value to comapre</param>
        /// <param name="array">full array list</param>
        /// <returns></returns>
        public bool ListParseHelper(int value, int[] array)
        {
            // The array is already initialized with 0's
            // so without this, if the random seed has a 0, we would return true
            if(value == 0)
            {
                return false;
            }
            for (int i = 0; i < array.Length; i++)
            {
                // find duplicate array
                if (value == array[i])
                {
                    return true;
                }
            }
            return false;
        }

    }

}
