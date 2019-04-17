using System;
using Task_DEV_2_;
using NUnit.Framework;

namespace Task_DEV_2Test
{
    [TestFixture]
    class ConverterWordToPhonemesTest
    {
        [TestCase("молоко+", "малако")]
        [TestCase("ё+лка", "йолка")]
        [TestCase("ме+сто", "м'эста")]
        [TestCase("сде+лать", "зд'элат'")]
        public void ConvertWordToPhonemes_Test(string word, string resultPhoneme)
        {
            ConverterWordToPhonemes converterWordToPhonemes = new ConverterWordToPhonemes();
            Assert.AreEqual(resultPhoneme, converterWordToPhonemes.ConvertWordToPhonemes(word).ToString());
        }

        [TestCase(null)]
        public void AddNullVowelToPhoneme_Test(Letter letter)
        {
            ConverterWordToPhonemes converterWordToPhonemes = new ConverterWordToPhonemes();
            Assert.Throws<NullReferenceException>
            (
                () => converterWordToPhonemes.AddVowelToPhonemes(letter)
            );
        }

        [TestCase(null)]
        public void AddNullConsonantToPhoneme_Test(Letter letter)
        {
            ConverterWordToPhonemes converterWordToPhonemes = new ConverterWordToPhonemes();
            Assert.Throws<NullReferenceException>
            (
                () => converterWordToPhonemes.AddConsonantToPhonemes(letter)
            );
        }
    }
}
