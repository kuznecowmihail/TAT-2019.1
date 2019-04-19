using Task_DEV_2_;
using NUnit.Framework;

namespace Task_DEV_2Test
{
    [TestFixture]
    public class CounterLettersToWordTest
    {
        [TestCase("молоко+", 6)]
        [TestCase("ё", 1)]
        [TestCase("", 0)]
        public void CountLettersToWord_Test(string word, int resultCount)
        {
            ConverterWordToPhonemes convererWordToPhonemes = new ConverterWordToPhonemes();
            convererWordToPhonemes.SetWord(word);
            convererWordToPhonemes.DevideWordIntoLetters();
            Assert.AreEqual(resultCount, convererWordToPhonemes.ListOfLetters.Count);
        }
    }
}
