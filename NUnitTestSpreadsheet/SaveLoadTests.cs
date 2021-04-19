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

        /// <summary>
        /// Tests the save and load operations in the spreadsheet
        /// </summary>
        /// <returns>The evaluated value</returns>
        public bool TestEvaluate()
        {
            Spreadsheet ss = new Spreadsheet(50, 26);

            string[] coordinates = new string[] { "A1", "A2", "A3" };
            uint color = 0x00ffff;
            string[] text = new string[] { "45", "2", "=A1+A2" };
            for (int i = 0; i < coordinates.Length; i++)
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
