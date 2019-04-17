using Task_DEV_2_;
using NUnit.Framework;

namespace Task_DEV_2Test
{
    /// <summary>
    /// Summary description for CountLettersToWordTest
    /// </summary>
    [TestFixture]
    public class CounterLettersToWordTest
    {
        [TestCase("молоко+", 6)]
        [TestCase("ё", 1)]
        public void CountLettersToWord_Test(string word, int count)
        {
            ConverterWordToPhonemes convererWordToPhonemes = new ConverterWordToPhonemes
            {
                Word = word
            };
            convererWordToPhonemes.SearchStress();
            convererWordToPhonemes.DevideWordIntoLetters();
            Assert.AreEqual(count, convererWordToPhonemes.ListOfLetters.Count);
        }
    }
}
