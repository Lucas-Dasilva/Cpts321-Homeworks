//-----------------------------------------------------------------------
// <copyright file="ICommand.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal interface ICommand
    {
        ICommand Do(Spreadsheet s);
        ICommand Undo(Spreadsheet s);
    }
}
