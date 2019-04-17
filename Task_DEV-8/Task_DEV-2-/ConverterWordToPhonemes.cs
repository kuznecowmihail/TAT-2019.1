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
        public string Word { get; set; }
        public int Stress { get; private set; }
        public List<Letter> ListOfLetters { get; private set; }
        public StringBuilder Phonemes { get; private set; }
        readonly Dictionary<char, char> keysIsCompoundVowel = new Dictionary<char, char>
        {
            ['ю'] = 'у',
            ['я'] = 'а',
            ['ё'] = 'о',
            ['е'] = 'э'
        };
        readonly Dictionary<char, char> keysIsRingingValueIsDeaf = new Dictionary<char, char>
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
        public ConverterWordToPhonemes()
        {
            ListOfLetters = new List<Letter>();
            Phonemes = new StringBuilder();
        }

        /// <summary>
        /// A method converts word to phonemes and return.
        /// </summary>
        /// <param name="word"></param>
        /// <returns>phonemes</returns>
        public StringBuilder ConvertWordToPhonemes(string word)
        {
            word = word != string.Empty ? word.ToLower() : throw new ArgumentOutOfRangeException();

            foreach (char i in word)
            {
                if ((i >= 1072 && i <= 1103) || i == 'ё' || i == '+')
                {
                    continue;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("letter", "Incorrected letter.");
                }
            }
            this.Word = word;
            ListOfLetters.Clear();
            Phonemes.Clear();
            SearchStress();
            DevideWordIntoLetters();

            foreach (var letter in ListOfLetters)
            {
                switch (letter.DefineTypeOfSymbol(letter.current))
                {
                    case "vowel":
                        AddVowelToPhonemes(letter);
                        continue;
                    case "consonant":
                        AddConsonantToPhonemes(letter);
                        continue;
                    case "other":
                        if (letter.current == 'ь')
                        {
                            Phonemes.Append("'");
                        }
                        continue;
                }
            }

            return Phonemes;
        }

        /// <summary>
        /// A method searches stress and remove symbol of stress from word.
        /// </summary>
        /// <param name="word"></param>
        /// <param name="stress"></param>
        public void SearchStress()
        {
            if (Word.Contains('+'))
            {
                Stress = Word.IndexOf('+') - 1;
                Word = Word.Remove(Word.IndexOf('+'), 1);

                return;
            }
            Stress = -1;
        }

        /// <summary>
        /// This method adds objects to listOfLetters.
        /// </summary>
        public void DevideWordIntoLetters()
        {
            for(var index = 0; index < Word.Length; index++)
            {
                Letter letter = new Letter
                {
                    current = Word[index],
                    index = index
                };

                if (index != 0)
                {
                    letter.previous = Word[index - 1];
                }

                if (index < Word.Length -2)
                {
                    letter.next = Word[index + 1];
                }
                ListOfLetters.Add(letter);
            }
        }

        /// <summary>
        /// A method adds vowel to phonemes.
        /// </summary>
        /// <param name="letter"></param>
        public void AddVowelToPhonemes(Letter letter)
        {
            if(letter == null)
            {
                throw new NullReferenceException("letter is null.");
            }
            // If the key is in compound vowel - true.
            switch (keysIsCompoundVowel.ContainsKey(letter.current))
            {
                case true:
                    // If previous letter is consonant - true.
                    if (letter.DefineTypeOfSymbol(letter.previous) == "consonant")
                    {
                        // Add letter to phonemes.
                        Phonemes.Append($"'{keysIsCompoundVowel[letter.current]}");
                    }
                    else
                    {
                        Phonemes.Append($"й{keysIsCompoundVowel[letter.current]}");
                    }

                    return;
                case false:
                    AddOtherLetterToPhonemes(letter);

                    return;     
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
            if (keysIsRingingValueIsDeaf.ContainsKey(letter.current) && keysIsRingingValueIsDeaf.ContainsValue(letter.next) || letter.next == '\0' && keysIsRingingValueIsDeaf.ContainsKey(letter.current))
            {
                // Add deaf to phenemes. Get the value from the key.
                Phonemes.Append(keysIsRingingValueIsDeaf[letter.current]);

                return;
            }
            // Check on ringing. If first symbol is deaf, next symbol is ringing
            // change the deaf to the ringing.
            else if (keysIsRingingValueIsDeaf.ContainsValue(letter.current) && keysIsRingingValueIsDeaf.ContainsKey(letter.next) && letter.next != 'в')
            {
                // Add ringing to phenemes. Get the key from the value;
                Phonemes.Append(keysIsRingingValueIsDeaf.FirstOrDefault(x => x.Value == letter.current).Key);

                return;
            }
            AddOtherLetterToPhonemes(letter);
        }

        /// <summary>
        /// A method defines the stress vawel or not and adds vawel in phonemes.
        /// </summary>
        /// <param name="index">Index of symbol</param>
        /// <param name="letter">Symbol</param>
        /// <param name="stress">Index of stress</param>
        /// <param name="phonemes">Line of phonemes</param>
        public void AddOtherLetterToPhonemes(Letter letter)
        {
            if ((letter.current >= 1072 && letter.current <= 1103) || letter.current == 'ё')
            {
                if (letter.current == 'о' && letter.index != Stress)
                {
                    Phonemes.Append("а");
                }
                else
                {
                    Phonemes.Append(letter.current);
                }
                return;
            }
            else
            {
                throw new IndexOutOfRangeException("The letter is not russian letter.");
            }
        }
    }
}
