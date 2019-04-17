using NUnit.Framework;
using Task_DEV_2_;

namespace Task_DEV_2Test
{
    [TestFixture]
    public class SeacherStressTest
    {
        [TestCase("молоко+", 5)]
        [TestCase("ё+лка", 0)]
        [TestCase("привет", -1)]
        [TestCase("пра+вда",2)]
        public void SearchStress_Test(string word, int resultStress)
        {
            ConverterWordToPhonemes convererWordToPhonemes = new ConverterWordToPhonemes();
            convererWordToPhonemes.Word = word;
            convererWordToPhonemes.SearchStress();
            Assert.AreEqual(resultStress, convererWordToPhonemes.Stress);
        }
    }
}
