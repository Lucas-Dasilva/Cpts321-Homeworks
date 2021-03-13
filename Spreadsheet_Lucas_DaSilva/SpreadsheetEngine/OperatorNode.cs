//-----------------------------------------------------------------------
// <copyright file="Spreadsheet.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------


namespace SpreadsheetEngine
{
    partial class ExpressionTree
    {
        private class OperatorNode : Node
        {
            public OperatorNode(char c)
            {
                Operator = c;
                Left = Right = null;
            }

            public char Operator { get; set; }

            public Node Left { get; set; }
            public Node Right { get; set; }
        }
    }
}
