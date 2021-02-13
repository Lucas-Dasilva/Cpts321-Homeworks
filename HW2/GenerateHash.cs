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
        /// Generate list with 10,000 random ints 
        /// </summary>
        /// <returns>list of ints</returns>
        public List<int> CreateList()
        {
            Random rnd = new Random();
            List<int> randIntList = new List<int>();
            for (int i = 0; i < 10000; i++)
            {
                randIntList.Add(rnd.Next(0,20000));
            }
            return randIntList;
        }

        /// <summary>
        /// Filter out integer list and put only distinct integers inside hashset 
        /// </summary>
        /// <param name="randIntList"> list with 10k random integers</param>
        /// <returns>Distinct integer list hashset</returns>
        public HashSet<int> ListParser(List<int> randIntList)
        {
            HashSet<int> distinctIntSet = new HashSet<int>();
            foreach (int value in randIntList) // O(n) 
            {
                if (!distinctIntSet.Contains(value)) // O(1)
                {
                    distinctIntSet.Add(value); // O(1)
                }
            }
            return distinctIntSet;
        }
        /// <summary>
        /// Counts the amountof distinct integers in list
        /// </summary>
        /// <param name="distinctIntSet"></param>
        /// <returns>number of elements in hashset</returns>
        public int CountDistinctInts(HashSet<int> distinctIntSet)
        {
            return distinctIntSet.Count;
        }
        
    }

    
}
