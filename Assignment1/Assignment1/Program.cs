using System;
using System.Diagnostics;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BigNumberCalculator.ToDecimal("0x843FF66FFCDDCDDDCDFFF"));
            // Debug.Assert(BigNumberCalculator.ToDecimal("0x843FF66FFCDDCDDDCDFFF") == "-9350296660948911804063745");
        }
    }
}