//-----------------------------------------------------------------------
// <copyright file="TestGenerateSort.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace HW2
{
    using NUnit.Framework;
    using System.Collections.Generic;
    public class TestGenerateSort
    {
        /// <summary>
        /// Test if the sort list is returning a sorted List
        /// </summary>
        [Test]
        public void TestSortList()
        {
            GenerateSort testClass = new GenerateSort();
            List<int> testList = new List<int>() { 34, 1, 2, 5, 52, 67, 23 };
            List<int> sortedList = testClass.SortList(testList);
            Assert.AreEqual(sortedList, new List<int>() { 1, 2, 5, 23, 34, 52, 67 });
        }

        /// <summary>
        /// Test if Non dynamic Linear Parse returns the correct number of 
        /// distinct integers
        /// the list is sorted
        /// </summary>
        [Test]
        public void TestNonDynamicLinearParse()
        {
            GenerateSort testClass = new GenerateSort();
            List<int> testList = new List<int>() { 1, 2, 3, 3, 4, 4, 5, 6, 7, 7, 7 };
            int testSet = testClass.NonDynamicLinearParse(testList);
            Assert.AreEqual(7, testSet);
        }
    }
}
