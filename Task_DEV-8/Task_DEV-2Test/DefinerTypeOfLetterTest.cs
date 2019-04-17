using System;
using Task_DEV_2_;
using NUnit.Framework;

namespace Task_DEV_2Test
{
    /// <summary>
    /// Summary description for DefineTypeOfLetterTest
    /// </summary>
    [TestFixture]
    public class DefinerTypeOfLetterTest
    {
        [TestCase('а', "vowel")]
        [TestCase('б', "consonant")]
        [TestCase('ь', "other")]
        [TestCase('ъ', "other")]
        public void DefineTypeOfLetter_Test(char letter, string resultType)
        {
            Letter letterObject = new Letter();
            Assert.AreEqual(resultType, letterObject.DefineTypeOfSymbol(letter));
        }

        [TestCase('f')]
        public void DifineIncorrectedLetter_Test(char letter)
        {
            Letter letterObject = new Letter();
            Assert.Throws<ArgumentOutOfRangeException>
            (
                () => letterObject.DefineTypeOfSymbol(letter)
            );
        }
    }
}
