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
        [TestCase("место", "м'эста")]
        [TestCase("сде+лать", "зд'элат'")]
        [TestCase("сто+лб", "столп")]
        [TestCase("гриб", "грип")]
        public void ConvertWordToPhonemes_Test(string word, string resultPhoneme)
        {
            ConverterWordToPhonemes converterWordToPhonemes = new ConverterWordToPhonemes();
            var actualResult = converterWordToPhonemes.ConvertWordToPhonemes(word).ToString();
            Assert.AreEqual(resultPhoneme, actualResult);
        }

        [TestCase(null)]
        public void ConvertNullWordToPhonemes_Test(string word)
        {
            ConverterWordToPhonemes converterWordToPhonemes = new ConverterWordToPhonemes();
            Assert.Throws<NullReferenceException>
            (
                () => converterWordToPhonemes.ConvertWordToPhonemes(word)
            );
        }
    }
}
