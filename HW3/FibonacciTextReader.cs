//-----------------------------------------------------------------------
// <copyright file="FibonacciTextReader.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
// Lucas Da Silva (11631988)
//-----------------------------------------------------------------------

namespace HW3
{
    using System;
    using System.IO;
    using System.Numerics;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// Fibonacci class that inherits from the Text reader object
    /// Note: fib == Fibonacci
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

        /// <summary>
        /// Override readline so it delivers the next  number as a string in the fib sequeunce
        /// </summary>
        /// <param name="max">max lines</param>
        /// <returns>String of fib line sequence</returns>
        private string ReadLine(int max)
        {
            BigInteger seq = GenerateFib(max);
            return seq.ToString();
        }
        
        /// <summary>
        /// Helper function for readline that generate fib sequence
        /// </summary>
        /// <param name="max">The max num</param>
        /// <returns>The sequence of numbers for fib</returns>
        private BigInteger GenerateFib(int max)
        {
            // Code for fib sequence borrowed from 
            // https://stackoverflow.com/questions/40966711/how-to-get-fibonacci-in-c-sharp

            BigInteger x = 0;
            BigInteger y = 1;
            BigInteger z = 0;

            // handle first two numbers as special cases
            if (max == 0)
            {
                return 0;
            }
            else if (max == 1)
            {
                return 1;
            }

            // Computing the fib sequence
            for (int i = 2; i < max; i++)
            {
                z = x;
                x = y;
                y = z + y;
            }
            return x;
        }


        /// <summary>
        /// Override Read to end method
        /// </summary>
        /// <returns>The finished string</returns>
        public override string ReadToEnd()
        {
            StringBuilder str = new StringBuilder();
            // repeadedly call ReadLine() to concatenate all the lines
            for (int i = 0; i < this.Max; i++)
            {
                // If approaching the last line, Don't type out new line
                // Else append a new line
                if (i == this.Max - 1)
                {
                    str.Append((i + 1) + ": " + ReadLine(i));
                }
                else
                {
                    str.Append((i + 1) + ": " + ReadLine(i));
                    str.Append("\r\n");
                }
            }
            str.Remove(Max-1,Max);
            return str.ToString();
        }

        /// <summary>
        /// private max variable
        /// </summary>
        private int Max { get; }
    }
}
