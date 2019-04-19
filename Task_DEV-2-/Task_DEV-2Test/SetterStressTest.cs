using Task_DEV_2_;
using NUnit.Framework;

namespace Task_DEV_2Test
{
    [TestFixture]
    public class SetterStressTest
    {
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
