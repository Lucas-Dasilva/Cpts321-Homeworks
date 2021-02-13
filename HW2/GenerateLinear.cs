namespace HW2.Linear
{
    using System.Collections.Generic;
    public class GenerateLinear
    {
        /// <summary>
        /// Generate list with 10,000 random ints 
        /// </summary>
        /// <returns>list of ints</returns>
        public List<int> CreateList()
        {
            List<int> randIntList = new List<int>();
            return randIntList;
        }

        /// <summary>
        /// Filter out integer list and put only distinct integers inside hashset 
        /// Should be Linear time complexity, no dynamic memory access
        /// </summary>
        /// <param name="randIntList"> list with 10k random integers</param>
        /// <returns>Distinct integer list</returns>
        public int[] ListParser(List<int> randIntList)
        {
            int[] intArray = new int[10000];
            return intArray;
        }
        public int CountDistinctInts(int[] distinctIntSet)
        {
            return distinctIntSet.Length;
        }
    }

}
