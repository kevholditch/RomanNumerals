using System;
using NUnit.Framework;

namespace RomanNumerals
{
    public class RomanNumeralExtensionTests
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
        [TestCase(-1, ExpectedException = typeof(InvalidOperationException))]
        public string CanCalulateRomanNumerals(int input)
        {
            return input.ToRomanNumeral();
        }

    }
}
