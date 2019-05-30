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
        public void ConvertWordToPhonemesTest(string word, string resultPhoneme)
        {
            ConverterWordToPhonemes converterWordToPhonemes = new ConverterWordToPhonemes();
            var actualResult = converterWordToPhonemes.ConvertWordToPhonemes(word).ToString();
            Assert.AreEqual(resultPhoneme, actualResult);
        }

        [TestCase(null)]
        public void ConvertNullWordToPhonemesTest(string word)
        {
            ConverterWordToPhonemes converterWordToPhonemes = new ConverterWordToPhonemes();
            Assert.Throws<NullReferenceException>
            (
                () => converterWordToPhonemes.ConvertWordToPhonemes(word)
            );
        }
    }
}
