using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task_DEV_2_
{
    /// <summary>
    /// Class that finds and return phonemes of words.
    /// </summary>
    public class ConverterWordToPhonemes
    {
        public string Word { get; private set; }
        public int Stress { get; private set; }
        public List<Letter> ListOfLetters { get; private set; }
        public StringBuilder Phonemes { get; private set; }
        private readonly Dictionary<char, char> keysIsCompoundVowel = new Dictionary<char, char>
        {
            ['ю'] = 'у',
            ['я'] = 'а',
            ['ё'] = 'о',
            ['е'] = 'э'
        };
        private readonly Dictionary<char, char> keysIsRingingValueIsDeaf = new Dictionary<char, char>
        {
            ['б'] = 'п',
            ['в'] = 'ф',
            ['г'] = 'к',
            ['д'] = 'т',
            ['ж'] = 'ш',
            ['з'] = 'с'
        };
        
        /// <summary>
        /// Constructor for ConverWordToPhonemes.
        /// </summary>
        /// <param name="word"></param>
        public ConverterWordToPhonemes()
        {
            ListOfLetters = new List<Letter>();
            Phonemes = new StringBuilder();
        }

        /// <summary>
        /// A method converts word to phonemes and return.
        /// </summary>
        /// <returns>phonemes</returns>
        public StringBuilder ConvertWordToPhonemes(string word)
        {
            SetWord(word);
            ListOfLetters.Clear();
            Phonemes.Clear();
            DevideWordIntoLetters();

            foreach (var letter in ListOfLetters)
            {
                switch (letter.DefineTypeOfSymbol(letter.Current))
                {
                    case "vowel":
                        AddVowelToPhonemes(letter);
                        continue;
                    case "consonant":
                        AddConsonantToPhonemes(letter);
                        continue;
                    case "other":
                        Phonemes.Append(letter.Current == 'ь' ? "'" : "");
                        continue;
                }
            }

            return Phonemes;
        }

        /// <summary>
        /// Method sets parameter to this word and sets stress.
        /// </summary>
        /// <param name="word"></param>
        public void SetWord(string word)
        {
            word = word != null ? word.ToLower() : throw new NullReferenceException();
            int indexStress = 0;

            foreach (var i in word)
            {
                // If strecc of word more than 1 -> exception.
                if (((i >= 1072 && i <= 1103) || i == 'ё' || i == '+') && indexStress <= 1)
                {
                    indexStress +=  i == '+' ? 1 : 0;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("letter", "Incorrected letter.");
                }
            }
            this.Stress = indexStress == 1 ? word.IndexOf('+') - 1 : -1;
            this.Word = indexStress == 1 ? word.Remove(word.IndexOf('+'), 1) : word;
        }

        /// <summary>
        /// This method adds objects to listOfLetters.
        /// </summary>
        public void DevideWordIntoLetters()
        {
            for(var index = 0; index < Word.Length; index++)
            {
                ListOfLetters.Add(new Letter
                {
                    Current = Word[index],
                    Previous = index != 0 ? Word[index - 1] : '\0',
                    Next = index < Word.Length - 2 ? Word[index + 1] : '\0',
                    Index = index
                });
            }
        }

        /// <summary>
        /// A method adds vowel to phonemes.
        /// </summary>
        /// <param name="letter"></param>
        public void AddVowelToPhonemes(Letter letter)
        {
            if (letter == null)
            {
                throw new NullReferenceException("letter is null.");
            }

            // If the key is in compound vowel - true.
            if (keysIsCompoundVowel.ContainsKey(letter.Current))
            {
                // If previous letter is consonant - true(е->'е).
                // Add letter to phonemes.
                Phonemes.Append(
                    letter.DefineTypeOfSymbol(letter.Previous) == "consonant"
                    ? $"'{keysIsCompoundVowel[letter.Current]}"
                    : $"й{keysIsCompoundVowel[letter.Current]}");
            }
            else
            {
                AddOtherLetterToPhonemes(letter);
            }
        }

        /// <summary>
        /// A method adds consonant to phonemes.
        /// </summary>
        /// <param name="letter"></param>
        public void AddConsonantToPhonemes(Letter letter)
        {
            if (letter == null)
            {
                throw new NullReferenceException("letter is null.");
            }

            // Check on deaf. If first symbol is ringing, next symbol is deaf or consonant last and ringing, 
            // change the ringing to the deaf.
            if (keysIsRingingValueIsDeaf.ContainsKey(letter.Current) && keysIsRingingValueIsDeaf.ContainsValue(letter.Next) || letter.Next == '\0' && keysIsRingingValueIsDeaf.ContainsKey(letter.Current))
            {
                // Add deaf to phenemes. Get the value from the key.
                Phonemes.Append(keysIsRingingValueIsDeaf[letter.Current]);

                return;
            }
            // Check on ringing. If first symbol is deaf, next symbol is ringing
            // change the deaf to the ringing.
            else if (keysIsRingingValueIsDeaf.ContainsValue(letter.Current) && keysIsRingingValueIsDeaf.ContainsKey(letter.Next) && letter.Next != 'в')
            {
                // Add ringing to phenemes. Get the key from the value;
                Phonemes.Append(keysIsRingingValueIsDeaf.FirstOrDefault(x => x.Value == letter.Current).Key);

                return;
            }
            AddOtherLetterToPhonemes(letter);
        }

        /// <summary>
        /// A method defines the stress vawel or not and adds vawel in phonemes.
        /// </summary>
        /// <param name="letter">Symbol object</param>
        public void AddOtherLetterToPhonemes(Letter letter)
        {
            if (letter == null)
            {
                throw new NullReferenceException("Letter is null");
            }

            if((letter.Current >= 1072 && letter.Current <= 1103) || letter.Current == 'ё')
            {
                Phonemes.Append(
                (((letter.Current == 'о' && letter.Index != Stress))
                    ? 'а'
                    : letter.Current));
            }
            else
            {
                throw new ArgumentOutOfRangeException("The letter is not russian letter.");
            }
        }
    }
}
