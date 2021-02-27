//-----------------------------------------------------------------------
// <copyright file="FibonacciTextReader.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace HW3
{
    using System;
    using System.IO;
    using System.Numerics;
    using System.Windows.Forms;

    /// <summary>
    /// Fibonacci class that inherits from the Text reader object
    /// </summary>
    public class FibonacciTextReader : TextReader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FibonacciTextReader"/> class
        /// Constructor that takes an integer indicating the maximum number of lines available
        /// </summary>
        /// <param name="maxLines">Max lines available</param>

        public FibonacciTextReader(int maxLines)
        {
            this.Max = maxLines;
        }

        private BigInteger ReadLine(int max)
        {
            BigInteger x = 0;
            BigInteger y = 1;
            BigInteger z = 0;

            // return if special case
            if (max == 0) 
            { 
                return 0; 
            }
            else if (max == 1) 
            { 
                return 1; 
            }

            // Computing the fib sequence
            for (int i = 0; i < max; i++)
            {
                z = x;
                x = y;
                y = z + y;
            }
            return z;
        }
        public int Max { get; }
    }
}
