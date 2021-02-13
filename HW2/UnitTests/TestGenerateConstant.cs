//-----------------------------------------------------------------------
// <copyright file="TestGenerateConstant.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace HW2
{
    using NUnit.Framework;
    using System.Collections.Generic;
    public class TestGenerateConstant
    {
        /// <summary>
        /// Test if FilterList() returns hash set with only distinct integers
        /// Do not alter the list in any way 
        /// Determine time complexity
        /// Use MSDN to help with this
        /// </summary>
        [Test]
        public void TestFilterList()
        {
            GenerateConstant testClass = new GenerateConstant();
            List<int> testList = new List<int>() { 1, 2, 3, 3, 0, 0, 0, 0, 2, 8, 34, 546, 3434, 3434, 545 };
            int testSet = testClass.ListParser(testList);
            Assert.AreEqual(9, testSet);
        }

    }
}
