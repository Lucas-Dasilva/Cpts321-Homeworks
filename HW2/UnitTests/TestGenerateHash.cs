//-----------------------------------------------------------------------
// <copyright file="TestGenerateHash.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace HW2
{
    using System;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    class TestGenerateHash
    {
        /// <summary>
        /// Test if the listCreator creates list of 10k elements
        /// </summary>
        [Test]
        public void TestCreateList()
        {
            Random rnd = new Random();
            GenerateHash testClass = new GenerateHash();
            List<int> testList = testClass.CreateList(rnd);
            Assert.AreEqual(testList.Count, 10000);
        }

        /// <summary>
        /// Test if FilterList() returns hash set with only distinct integers
        /// Do not alter the list in any way 
        /// Determine time complexity
        /// Use MSDN to help with this
        /// </summary>
        [Test]
        public void TestFilterList()
        {
            GenerateHash testClass = new GenerateHash();
            List<int> testList = new List<int>() { 1, 2, 3, 3, 3, 5, 2, 8, 34, 546, 3434, 3434, 545 };
            HashSet<int> testSet = testClass.ListParser(testList);
            HashSet<int> testSet2 = new HashSet<int>() { 1, 2, 3, 5, 8, 34, 546, 3434, 545 };
            Assert.AreEqual(testSet, testSet2);
        }

        /// <summary>
        /// Testing if the number of integers counted are correct
        /// </summary>
        [Test]
        public void TestCountDistinctInts()
        {
            GenerateHash testClass = new GenerateHash();
            List<int> testList = new List<int>() { 1, 2, 3, 3, 3, 5, 2, 8, 34, 546, 3434, 3434, 545 };
            HashSet<int> testSet = testClass.ListParser(testList);
            int testCount = testClass.CountDistinctInts(testSet);
            Assert.AreEqual(9, testCount);
        }



    }
}
