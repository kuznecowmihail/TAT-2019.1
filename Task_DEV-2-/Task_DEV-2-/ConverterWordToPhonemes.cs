using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task_DEV_2_
{
    class ConverterWordToPhonemes
    {
        private StringBuilder word = new StringBuilder();
        private StringBuilder phonemes = new StringBuilder();
        private int stress = 0;
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

        public ConverterWordToPhonemes(string line)
        {
            word.Append(line);
        }

        public StringBuilder ConvertWord()
        {
            // Search stress and remove symbol '+' from word.
            for (var i = 0; i < word.Length; i++)
            {
                if (word[i] == '+')
                {
                    stress = i - 1;
                    word.Remove(stress + 1, 1);
                    break;
                }
            }
            for (int i = 0; i < word.Length; i++)
            {
                // Vowel check.
                if(DefineType(word[i], vowels))
                {
                    if(i != 0 && DefineType(word[i - 1], consonants) && vowelBeforeConsonant.ContainsKey(word[i]))
                    {
                        phonemes.Append("'" + vowelBeforeConsonant[word[i]]);
                        continue;
                    }
                    if (vowelBeforeVowel.ContainsKey(word[i]))
                    {
                        phonemes.Append(vowelBeforeVowel[word[i]]);
                        continue;
                    }
                    AddUnstressesLetter(i, word[i], stress, ref phonemes);
                }
                // Consonat check.
                if(DefineType(word[i], consonants))
                {
                    // Check on last element and contains symbol in keys.
                    if(i == (word.Length - 1) && key_ringing_value_deaf.ContainsKey(word[i]))
                    {
                        phonemes.Append(key_ringing_value_deaf[word[i]]);
                        break;
                    }
                    else if (i == word.Length - 1)
                    {
                        phonemes.Append(word[i]);
                        break;
                    }
                    if (DefineType(word[i + 1], consonants) && key_ringing_value_deaf.ContainsKey(word[i]))
                    {
                        // Add deaf to phenemes. Get the value from the key.
                        phonemes.Append(key_ringing_value_deaf[word[i]]);
                        continue;
                    }
                    else if (DefineType(word[i + 1], consonants) && key_ringing_value_deaf.ContainsKey(word[i + 1]) && word[i + 1] != 'в')
                    {
                        // Add ringing to phenemes. Get the key from the value;
                        phonemes.Append(key_ringing_value_deaf.FirstOrDefault(x => x.Value == word[i]).Key);
                        continue;
                    }
                    phonemes.Append(word[i]);
                }
                // Check on 'ь' and 'ъ'.
                if (word[i] == 'ь')
                {
                    phonemes.Append("'");
                }
            }
            return phonemes;
        }

        public bool DefineType(char word, List<char> type)
        {
            if (type.Contains(word))
            {
                return true;
            }
            return false;
        }

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

        public void PrintPhonemes(StringBuilder line)
        {
            Console.WriteLine(word + " -> " + line);
        }
    }
}