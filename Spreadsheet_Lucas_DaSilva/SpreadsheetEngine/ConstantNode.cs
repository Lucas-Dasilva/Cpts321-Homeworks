//-----------------------------------------------------------------------
// <copyright file="Spreadsheet.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------


namespace SpreadsheetEngine
{
    partial class ExpressionTree
    {
        private class ConstantNode : Node
        {
            public double Value { get; set; }
        }
    }
}
