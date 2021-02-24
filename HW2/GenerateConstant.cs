//-----------------------------------------------------------------------
// <copyright file="GenerateConstant.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace HW2
{
    using System;
    using System.Collections.Generic;
    public class GenerateConstant
    {
        /// <summary>
        /// Calls all functions from this class
        /// </summary>
        /// <param name="ls"> random List</param>
        /// <returns>returns unique numbers for generateHash</returns>
        public int ConstructHash(List<int> ls)
        {
            int count = this.ListParser(ls);
            return count;
        }

        /// <summary>
        /// Filter out integer list and put only distinct integers inside integer array 
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
            // zerotracker keeps track of 0's in the randIntList because array is initialized with all 0's
            int zeroTracker = 0;
            for (int i = 0; i < randIntList.Count; i ++) // O(n)
            {
                // If we havent seen more than one 0 or the current one is 0 then enter
                // Else its a duplicate 0
                if (zeroTracker < 1 || randIntList[i] != 0 ) // O(n) 
                {
                    // If we have 0 for first time then add to tracker of 0's so it can't enter again
                    // if It's not already inside array, increment the distinct count and populate array
                    // Else, increment duplicate count
                    if (randIntList[i] == 0)
                    {
                        zeroTracker += 1;
                    }
                    if (!ListParseHelper(randIntList[i], intArray))
                    {
                        intArray[i - dupTracker] = randIntList[i];
                        distinctCount = distinctCount + 1;
                    }
                    else
                    {
                        dupTracker += 1;
                    }
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
        /// <param name="value">value to compare</param>
        /// <param name="array">full array list</param>
        /// <returns>Returns false for no duplicates and true for yes contains duplicate</returns>
        public bool ListParseHelper(int value, int[] array)
        {
            // The array is already initialized with 0's
            // so without this, if the random seed has a 0, we would return true
            if (value == 0)
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
