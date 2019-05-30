using System;
using Task_DEV_2_;
using NUnit.Framework;

namespace Task_DEV_2Test
{
    [TestFixture]
    public class AdderLetterTest
    {
        [TestCase(null)]
        public void AddNullVowelToPhonemeTest(Letter letter)
        {
            ConverterWordToPhonemes converterWordToPhonemes = new ConverterWordToPhonemes();
            Assert.Throws<NullReferenceException>
            (
                () => converterWordToPhonemes.AddVowelToPhonemes(letter)
            );
        }

        [TestCase(null)]
        public void AddNullConsonantToPhonemeTest(Letter letter)
        {
            ConverterWordToPhonemes converterWordToPhonemes = new ConverterWordToPhonemes();
            Assert.Throws<NullReferenceException>
            (
                () => converterWordToPhonemes.AddConsonantToPhonemes(letter)
            );
        }

        [TestCase('f')]
        [TestCase('5')]
        [TestCase('+')]
        public void AddNotRussianLetterTest(char letter)
        {
            Letter myLetter = new Letter
            {
                Current = letter
            };
            ConverterWordToPhonemes converterWordToPhonemes = new ConverterWordToPhonemes();
            Assert.Throws<ArgumentOutOfRangeException>
            (
                () => converterWordToPhonemes.AddOtherLetterToPhonemes(myLetter)
            );
        }

        [TestCase(null)]
        public void AddNullLetterTest(Letter letter)
        {
            ConverterWordToPhonemes converterWordToPhonemes = new ConverterWordToPhonemes();
            Assert.Throws<NullReferenceException>
            (
                () => converterWordToPhonemes.AddOtherLetterToPhonemes(letter)
            );
        }
    }
}
