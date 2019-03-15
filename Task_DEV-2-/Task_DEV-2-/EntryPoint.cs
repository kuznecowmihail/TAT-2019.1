using System;

namespace Task_DEV_2_
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            try
            {
                ConverterWordToPhonemes[] converterWordToPhonemes = new ConverterWordToPhonemes[args.Length];
                for (int i = 0; i < converterWordToPhonemes.Length; i++)
                {
                    converterWordToPhonemes[i] = new ConverterWordToPhonemes(args[i]);
                    converterWordToPhonemes[i].PrintPhonemes(converterWordToPhonemes[i].ConvertWord());
                }
            }
            catch(Exception)
            {
                Console.WriteLine("Something error");
            }
        }
    }
}
