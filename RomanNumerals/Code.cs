using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace RomanNumerals
{
    public class Tests
    {
        [TestCase(0, ExpectedResult = "")]
        [TestCase(1, ExpectedResult = "I")]
        [TestCase(3, ExpectedResult = "III")]
        [TestCase(14, ExpectedResult = "XIV")]
        [TestCase(64, ExpectedResult = "LXIV")]
        [TestCase(226, ExpectedResult = "CCXXVI")]
        [TestCase(900, ExpectedResult = "CM")]
        [TestCase(998, ExpectedResult = "CMXCVIII")]
        [TestCase(1712, ExpectedResult = "MDCCXII")]
        [TestCase(4000, ExpectedResult = "MMMM")]
        [TestCase(4001, ExpectedException = typeof(InvalidOperationException))]
        public string CanCalulateRomanNumerals(int input)
        {
            return input.ToRomanNumeral();
        }

    }

    public static class IntegerExtensions
    {

        private static Dictionary<int, string> CreateMapping(string baseSymbol, string midSymbol, string upperSymbol)
        {
            return new Dictionary<int, string>
                {
                    {0, ""},
                    {1, baseSymbol},
                    {2, baseSymbol + baseSymbol},
                    {3, baseSymbol + baseSymbol + baseSymbol},
                    {4, baseSymbol + midSymbol},
                    {5, midSymbol},
                    {6, midSymbol + baseSymbol},
                    {7, midSymbol + baseSymbol + baseSymbol},
                    {8, midSymbol + baseSymbol + baseSymbol + baseSymbol},
                    {9, baseSymbol + upperSymbol},
                };
        }

        private static readonly Dictionary<int, string> UnitMapping = CreateMapping("I", "V", "X");
        private static readonly Dictionary<int, string> TensMapping = CreateMapping("X", "L", "C");
        private static readonly Dictionary<int, string> HundredsMapping = CreateMapping("C", "D", "M");

        public static string ToRomanNumeral(this int integer)
        {
            if (integer > 4000)
                throw new InvalidOperationException("Numbers over 4000 are not supported!");

            var stringBuilder = new StringBuilder();

            var intAsString = integer.ToString();

            for (var i = 0; i < intAsString.Length; i++)
            {
                var current = int.Parse(intAsString[i].ToString());
                var column = intAsString.Length - i - 1;
                if (column == 0)
                {
                    stringBuilder.Append(UnitMapping[current]);
                }
                else if (column == 1)
                {
                    stringBuilder.Append(TensMapping[current]);
                }
                else if (column == 2)
                {
                    stringBuilder.Append(HundredsMapping[current]);
                }
                else
                {
                    stringBuilder.Append(new String('M', current));
                }
            }


            return stringBuilder.ToString();
        }
    }
}
