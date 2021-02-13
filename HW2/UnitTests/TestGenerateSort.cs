namespace HW2.Sort
{
    using NUnit.Framework;
    using System.Collections.Generic;
    public class TestGenerateSort
    {
        /// <summary>
        /// Test if the sortlist is returning a sorted List
        /// </summary>
        [Test]
        public void TestSortList()
        {
            GenerateSort testClass = new GenerateSort();
            List<int> testList = new List<int>() { 34, 1, 2, 5, 52, 67, 23 };
            List<int> sortedList = testClass.SortList(testList);
            Assert.AreSame(sortedList, new List<int>() { 1, 2, 5, 23, 34, 52, 67 });
        }

        /// <summary>
        /// Test if NondyanmicLinearParse returns the correct number of distinct ints
        /// the list is sorted
        /// </summary>
        [Test]
        public void TestNonDynamicLinearParse()
        {
            GenerateSort testClass = new GenerateSort();
            List<int> testList = new List<int>() { 1, 2, 3, 3, 4, 4, 5, 6, 6, 7 };
            int testSet = testClass.NonDynamicLinearParse(testList);
            Assert.AreEqual(testSet, 7);
        }

        /// <summary>
        /// Testing if number of sorted List distinct integers is correct
        /// Can be dynamic
        /// </summary>
        [Test]
        public void TestLinearParse()
        {
            GenerateSort testClass = new GenerateSort();
            List<int> testList = new List<int>() { 1, 2, 3, 3, 4, 4, 5, 6, 6, 7 };
            int testSet = testClass.LinearParse(testList);
            Assert.AreEqual(testSet, 7);
        }

    }
}
