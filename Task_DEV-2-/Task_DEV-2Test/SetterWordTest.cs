using System;
using NUnit.Framework;
using Task_DEV_2_;

namespace Task_DEV_2Test
{
    /// <summary>
    /// Summary description for SetterWord
    /// </summary>
    [TestFixture]
    public class SetterWordTest
    {
        [TestCase("молоко+", "молоко")]
        [TestCase("ё+лка", "ёлка")]
        [TestCase("привет", "привет")]
        [TestCase("пра+вда", "правда")]
        public void SetWordTest(string word, string resultWord)
        {
            ConverterWordToPhonemes convererWordToPhonemes = new ConverterWordToPhonemes();
            convererWordToPhonemes.SetWord(word);
            Assert.AreEqual(resultWord, convererWordToPhonemes.Word);
        }

        [TestCase("f")]
        [TestCase("5+")]
        [TestCase("5vs")]
        [TestCase("мо+ло+ко")]
        public void SetIncorrectedWordTest(string word)
        {
            Assert.Throws<ArgumentOutOfRangeException>
             (
                () => new ConverterWordToPhonemes().SetWord(word)
             );
        }

        [TestCase(null)]
        public void SetNullWordTest(string word)
        {
            Assert.Throws<NullReferenceException>
             (
                () => new ConverterWordToPhonemes().SetWord(word)
             );
        }
    }
}
