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

    public interface ICommand<T>
    {
        /// <summary>
        /// Input a value and return a value of the same type
        /// </summary>
        /// <param name="input"></param>
        /// <returns>The command</returns>
        T Do(T input);

        /// <summary>
        /// Undo the action
        /// </summary>
        /// <param name="input">The command</param>
        /// <returns>The command</returns>
        T Undo(T input);

    }
}
