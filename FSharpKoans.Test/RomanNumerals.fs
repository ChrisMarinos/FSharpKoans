module RomanNumeralsTests

open NUnit.Framework
open RomanNumerals

[<TestCase("I", 1)>]
let fromRomanNumeralsValidCases input expected =
    let actual = RomanNumerals.fromRomanNumeral input
    Assert.AreEqual(actual, expected) 