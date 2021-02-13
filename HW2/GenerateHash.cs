namespace HW2
{
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
        public List<int> ListCreator()
        {
            List<int> randIntList = new List<int>();
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
            return distinctIntSet;
        }
        public int CountDistinctInts(HashSet<int> distinctIntSet)
        {
            return distinctIntSet.Count;
        }
        
    }
    
}
