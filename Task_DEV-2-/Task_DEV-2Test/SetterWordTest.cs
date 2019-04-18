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
        public void SetWord_Test(string word, string resultWord)
        {
            ConverterWordToPhonemes convererWordToPhonemes = new ConverterWordToPhonemes();
            convererWordToPhonemes.SetWord(word);
            Assert.AreEqual(resultWord, convererWordToPhonemes.Word);
        }

        [TestCase("f")]
        [TestCase("5+")]
        [TestCase("5vs")]
        [TestCase("мо+ло+ко")]
        public void SetIncorrectedWord_Test(string word)
        {
            Assert.Throws<ArgumentOutOfRangeException>
             (
                () => new ConverterWordToPhonemes().SetWord(word)
             );
        }

        [TestCase(null)]
        public void SetNullWord_Test(string word)
        {
            Assert.Throws<NullReferenceException>
             (
                () => new ConverterWordToPhonemes().SetWord(word)
             );
        }

        [TestCase("молоко+", 5)]
        [TestCase("ё+лка", 0)]
        [TestCase("привет", -1)]
        [TestCase("пра+вда", 2)]
        public void SetStress_Test(string word, int resultStress)
        {
            ConverterWordToPhonemes convererWordToPhonemes = new ConverterWordToPhonemes();
            convererWordToPhonemes.SetWord(word);
            Assert.AreEqual(resultStress, convererWordToPhonemes.Stress);
        }
    }
}
