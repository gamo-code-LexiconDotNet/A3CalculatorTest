using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Test
{
    public class InternalMenuTestData
    {
        public static IEnumerable<object[]> MenuText
        {
            get
            {
                yield return new object[]
                {
                    "[Lexicon C#/.Net Programming] Assignment 3 - Calculator Test\n\r\n" +
                    "Choose what to calculate:\r\n" +
                    "1)  Add a to b (a + b)\r\n" +
                    "2)  Divide a by b (a / b)\r\n" +
                    "3)  Subtract b from a (a - b)\r\n" +
                    "4)  Multiply a with b (a * b)\r\n" +
                    "5)  Take to power of b to a (a ^ b)\r\n" +
                    "6)  Take the b root of a (a ^ (1 / b))\r\n" +
                    "7)  Take modulo b of a (a % b)\r\n" +
                    "8)  Take Log a with base b (Log(a) / Log(b)\r\n" +
                    "0)  Exit\n" +
                    "> "
                };
            }
        }

        public static IEnumerable<object[]> Options
        {
            get
            {
                yield return new object[] { "1", "1", "1.1", "2.1" }; // Add
                yield return new object[] { "2", "1", "2", "0.5" }; // Divide
                yield return new object[] { "3", "-1.1", "1", "-2.1" }; // Subtract
                yield return new object[] { "4", "2.1", "2", "4.2" }; // Multiply
                yield return new object[] { "5", "2.1", "2.1", "4.7496" }; // Power
                yield return new object[] { "6", "2", "3", "1.2599" }; //Root
                yield return new object[] { "7", "2.2", "2.1", "0.1" }; // Modulo
                yield return new object[] { "8", "16", "4", "2" }; // Log
            }
        }

        public static IEnumerable<object[]> OptionsDivideByZero
        {
            get
            {
                yield return new object[] { "2", "1", "0", "Cannot divide by Zero." }; // Divide
                yield return new object[] { "6", "2", "0", "Cannot divide by Zero." }; // Root
            }
        }
    }
}
