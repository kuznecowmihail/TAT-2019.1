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
       [TestCase("f")]
       [TestCase("")]
       [TestCase("5+")]
       [TestCase("5vs")]
       public void SetWord_Test(string word)
       {
            Assert.Throws<ArgumentOutOfRangeException>
             (
                () => new ConverterWordToPhonemes().ConvertWordToPhonemes(word)
             );
       }
    }
}
