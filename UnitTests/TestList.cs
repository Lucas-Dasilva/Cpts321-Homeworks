namespace HW2
{
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    class TestList
    {

        [Test]
        public void TestCreateList()
        {
            GenerateHash testClass = new GenerateHash();
            List<int> testList = testClass.listGenerator();
            // List<int> List = new List<int>() 

            Assert.IsNotEmpty(testList);


        }

    }
}
