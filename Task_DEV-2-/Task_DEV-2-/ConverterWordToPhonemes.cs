using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task_DEV_2_
{
    /// <summary>
    /// class that finds and prints phonemes of words.
    /// </summary>
    class ConverterWordToPhonemes
    {
        private string word = string.Empty;
        private StringBuilder phonemes = new StringBuilder();
        private int stress = -2;
        private readonly List<char> vowels = new List<char>
        {
            'а', 'о', 'и', 'е', 'ё', 'э', 'ы', 'у', 'ю', 'я'
        };
        private readonly List<char> consonants = new List<char>
        {
            'б', 'в', 'г', 'д', 'ж', 'з', 'й', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ'
        };
        private readonly Dictionary<char, char> vowelBeforeConsonant = new Dictionary<char, char>
        {
            ['ю'] = 'у',
            ['я'] = 'а',
            ['ё'] = 'о',
            ['е'] = 'э'
        };
        private readonly Dictionary<char, string> vowelBeforeVowel = new Dictionary<char, string>
        {
            ['ю'] = "йу",
            ['я'] = "йа",
            ['ё'] = "йо",
            ['е'] = "йэ"
        };
        private readonly Dictionary<char, char> key_ringing_value_deaf = new Dictionary<char, char>
        {
            ['б'] = 'п',
            ['в'] = 'ф',
            ['г'] = 'к',
            ['д'] = 'т',
            ['ж'] = 'ш',
            ['з'] = 'с'
        };
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="line"></param>
        public ConverterWordToPhonemes(string line)
        {
            word = line;
        }
        /// <summary>
        /// A method that finds and return phonemes of words.
        /// </summary>
        /// <returns>phonemes</returns>
        public StringBuilder ConvertWord()
        {
            // Search stress and remove symbol '+' from word.
            if (word.Contains('+'))
            {
                stress = word.IndexOf('+') - 1;
                word = word.Remove(word.IndexOf('+'), 1);
            }
            for (int i = 0; i < word.Length; i++)
            {
                // Vowel check and add element in phonemes.
                if(DefineType(word[i], vowels))
                {
                    // Check that "Vawel before consonat" dictionary contains symbol in key. 
                    // Check go when the lowel isn't first or after the consonat.
                    if (i != 0 && DefineType(word[i - 1], consonants) && vowelBeforeConsonant.ContainsKey(word[i]))
                    {
                        // Add value to phonemes.
                        phonemes.Append("'" + vowelBeforeConsonant[word[i]]);
                        continue;
                    }
                    // Check that "Vawel before vawel" dictionary contains symbol in key. 
                    // Check go when the lowel is first or after the lowel.
                    else if (vowelBeforeVowel.ContainsKey(word[i]))
                    {
                        phonemes.Append(vowelBeforeVowel[word[i]]);
                        continue;
                    }
                    AddUnstressesLetter(i, word[i], stress, ref phonemes);
                }
                // Consonat check.
                if(DefineType(word[i], consonants))
                {
                    // Check on last element and contains symbol in keys. Check on deaf
                    if(i == word.Length - 1 && key_ringing_value_deaf.ContainsKey(word[i]))
                    {
                        // Add value to phonemes.
                        phonemes.Append(key_ringing_value_deaf[word[i]]);
                        break;
                    }
                    else if (i == word.Length - 1)
                    {
                        phonemes.Append(word[i]);
                        break;
                    }
                    // Check on deaf. If first symbol is ringing, next symbol is consonant, 
                    // change the ringing to the deaf.
                    if (DefineType(word[i + 1], consonants) && key_ringing_value_deaf.ContainsKey(word[i]))
                    {
                        // Add deaf to phenemes. Get the value from the key.
                        phonemes.Append(key_ringing_value_deaf[word[i]]);
                        continue;
                    }
                    // Check on ringing.If second symbol is ringing, next symbol is consonant, 
                    // change the deaf to the ringing.
                    else if (DefineType(word[i + 1], consonants) && key_ringing_value_deaf.ContainsKey(word[i + 1]) && word[i + 1] != 'в')
                    {
                        // Add ringing to phenemes. Get the key from the value;
                        phonemes.Append(key_ringing_value_deaf.FirstOrDefault(x => x.Value == word[i]).Key);
                        continue;
                    }
                    phonemes.Append(word[i]);
                }
                // Check on 'ь' and 'ъ'.
                else if (word[i] == 'ь')
                {
                    phonemes.Append("'");
                }
            }
            return phonemes;
        }
        /// <summary>
        /// A method that define type of symbol: consonant or vawel.
        /// </summary>
        /// <param name="word">Symbol that define type</param>
        /// <param name="type">List of vawel or consonant with wich we compare the symbol</param>
        public bool DefineType(char word, List<char> type)
        {
            if (type.Contains(word))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// A method that defines the stress or not the vowel and adds vawel in phonemes.
        /// </summary>
        /// <param name="i">Index of symbol</param>
        /// <param name="word">Symbol</param>
        /// <param name="stress">Index of stress</param>
        /// <param name="phonemes">Line of phonemes</param>
        public void AddUnstressesLetter(int i, char word, int stress, ref StringBuilder phonemes)
        {
            if (word == 'о' && i != stress)
            {
                phonemes.Append("а");
            }
            else
            {
                phonemes.Append(word);
            }
        }
        /// <summary>
        /// A method that prints phonemes.
        /// </summary>
        /// <param name="line">Line that prints</param>
        public void PrintPhonemes(StringBuilder line)
        {
            Console.WriteLine(word + " -> " + line);
        }
    }
}