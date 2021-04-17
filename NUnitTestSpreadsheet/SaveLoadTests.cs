//-----------------------------------------------------------------------
// <copyright file="SaveLoadTests.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CptS321
{
    using System;
    using System.Text.RegularExpressions;
    using NUnit.Framework;

    /// <summary>
    /// Tests for Expression Tree
    /// </summary>
    [TestFixture]
    public class SaveLoadTests
    {
        [Test]
        //[TestCase(new string[] { "A1", "A2", "A3"}, 0x00ffff, new string[] { "45", "2", "=A1+A2" }, ExpectedResult = true)]
        //[TestCase("A2", 0x0000ff, ExpectedResult = 100.0)]
        //[TestCase("A", 0x008000, ExpectedResult = 1.0)]
        //[TestCase("84-14+26", 0x800080, ExpectedResult = 96.0)]
        //[TestCase("7-4+2", 0xff0000, ExpectedResult = 5.0)]
        //[TestCase("(((((2+3)-(4+5)))))", 0xc0c0c0, ExpectedResult = -4.0)]
        //[TestCase("2 + 3 * 5", 0x008080, ExpectedResult = 17.0)]
        //[TestCase("5/0", 0xffff00, ExpectedResult = double.PositiveInfinity)]

        /// <summary>
        /// Tests the save and load operations in the spreadsheet
        /// </summary>
        /// <param name="coordinates">The string index of the cell</param>
        /// <param name="bgcolor">The cell color</param>
        /// <param name="text">The cell text</param>
        /// <returns>The evaluated value</returns>
        public bool TestEvaluate()
        {
            Spreadsheet ss = new Spreadsheet(50, 26);

            string[] coordinates = new string[] { "A1", "A2", "A3" };
            uint color = 0x00ffff;
            string[] text = new string[] { "45", "2", "=A1+A2" };
            for (int i =0; i < coordinates.Length; i++)
            {
                Cell cell = ss.GetCell(coordinates[i]);
                cell.BGColor = color;
                cell.Text = text[i];

                ss.SheetArray[cell.RowIndex, cell.ColumnIndex].BGColor = color;
                ss.SheetArray[cell.RowIndex, cell.ColumnIndex].Text = text[i];
            }
                
            return false;
        }
    }
}
