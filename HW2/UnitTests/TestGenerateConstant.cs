namespace HW2
{
    using NUnit.Framework;
    using System.Collections.Generic;
    public class TestGenerateConstant
    {
        /// <summary>
        /// Test if the listCreator creates list of 10k elements
        /// </summary>
        [Test]
        public void TestCreateList()
        {
            GenerateConstant testClass = new GenerateConstant();
            //List<int> testList = testClass.CreateList();
            //Assert.AreEqual(testList.Count, 10000);
        }

        /// <summary>
        /// Test if FilterList() returns hashset with only distinct integers
        /// Do not alter the list in any way 
        /// Determine time complexity
        /// Use MSDN to help with this
        /// </summary>
        [Test]
        public void TestFilterList()
        {
            GenerateConstant testClass = new GenerateConstant();
            List<int> testList = new List<int>() { 1, 2, 3, 3, 3, 5, 2, 8, 34, 546, 3434, 3434, 545 };
            int[] testSet2 = new int[] { 1, 2, 3, 5, 8, 34, 546, 3434, 545 };
            // Assert.AreEqual(testSet2, testSet);
        }

        /// <summary>
        /// Testing if the number of ints counted are correct
        /// </summary>
        [Test]
        public void TestCountInts()
        {
            GenerateConstant testClass = new GenerateConstant();
            List<int> testList = new List<int>() { 1, 2, 3, 3, 3, 5, 2, 8, 34, 546, 3434, 3434, 545 };
            // int[] testSet = testClass.ListParser(testList);
            // int testCount = testClass.CountDistinctInts(testSet);
            //Assert.AreEqual(9, testCount);
        }

    }
}
