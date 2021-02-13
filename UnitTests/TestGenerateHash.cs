namespace HW2
{
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
            GenerateHash testClass = new GenerateHash();
            List<int> testList = testClass.ListCreator();
            Assert.IsNotEmpty(testList);
        }

        /// <summary>
        /// Test if FilterList() returns hashset with only distinct integers
        /// </summary>
        [Test]
        public void TestFilterList()
        {
            GenerateHash testClass = new GenerateHash();
            List<int> testList = new List<int>() { 1, 2, 3, 3, 3,5, 2, 8, 34, 546, 3434, 3434, 545 };
            HashSet<int> testSet = testClass.ListParser(testList);
            HashSet<int> testSet2 = new HashSet<int>() { 1, 2, 3, 5, 8, 34, 546, 3434, 545 };
            Assert.AreSame(testSet2, testSet);
        }

        /// <summary>
        /// Testing if the number of ints counted are correct
        /// </summary>
        [Test]
        public void TestCountDistinctInts()
        {
            GenerateHash testClass = new GenerateHash();
            HashSet<int> testSet = new HashSet<int>() { 1, 2, 3, 5, 8, 34, 546, 3434, 545 };
            int testCount = testClass.CountDistinctInts(testSet);
            Assert.AreEqual(9, testCount);
        }



    }
}
