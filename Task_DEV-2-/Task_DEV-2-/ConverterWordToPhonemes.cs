using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task_DEV_2_
{
    /// <summary>
    /// Class that finds and return phonemes of words.
    /// </summary>
    class ConverterWordToPhonemes
    {
        private string word;
        private List<Letter> listOfLetters = new List<Letter>();
        private StringBuilder phonemes = new StringBuilder();
        private int stress = -1;
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
        
        public ConverterWordToPhonemes(string word)
        {
            this.word = word;
        }
        /// <summary>
        /// A method converts word to phonemes and return.
        /// </summary>
        /// <returns>phonemes</returns>
        public StringBuilder ConvertWordToPhonemes()
        {
            SearchStress(ref word, ref stress);
            DevideWordToLetters();
            foreach (var letter in listOfLetters)
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
                            phonemes.Append("'");
                        }
                        continue;
                }
            }
            return phonemes;
        }
        /// <summary>
        /// A method searches stress and remove symbol of stress from word.
        /// </summary>
        /// <param name="word"></param>
        /// <param name="stress"></param>
        public void SearchStress(ref string word,  ref int stress)
        {
            if (word.Contains('+'))
            {
                stress = word.IndexOf('+') - 1;
                word = word.Remove(word.IndexOf('+'), 1);
            }
        }
        /// <summary>
        /// This method adds objects to listOfLetters.
        /// </summary>
        public void DevideWordToLetters()
        {
            for(var index = 0; index < word.Length; index++)
            {
                Letter letter = new Letter
                {
                    current = word[index],
                    index = index
                };
                if (index != 0)
                {
                    letter.previous = word[index - 1];
                }
                if (index < word.Length -2)
                {
                    letter.next = word[index + 1];
                }
                listOfLetters.Add(letter);
            }
        }
        /// <summary>
        /// A method adds vowel to phonemes.
        /// </summary>
        /// <param name="letter"></param>
        public void AddVowelToPhonemes(Letter letter)
        {
            // If compound vowel contains in key this vowel - true.
            switch (keysIsCompoundVowel.ContainsKey(letter.current))
            {
                case true:
                    if(letter.DefineTypeOfSymbol(letter.previous) == "consonant")
                    {
                        phonemes.Append("'" + keysIsCompoundVowel[letter.current]);
                    }
                    else
                    {
                        phonemes.Append("й" + keysIsCompoundVowel[letter.current]);
                    }
                    return;
                case false:
                    AddOtherVowelToPhonemes(letter.index, letter.current, stress, ref phonemes);
                    return;     
            }
        }
        /// <summary>
        /// A method adds consonant to phonemes.
        /// </summary>
        /// <param name="letter"></param>
        public void AddConsonantToPhonemes(Letter letter)
        {
            // Check on deaf. If first symbol is ringing, next symbol is deaf or consonant last and ringing, 
            // change the ringing to the deaf.
            if (keysIsRingingValueIsDeaf.ContainsKey(letter.current) && keysIsRingingValueIsDeaf.ContainsValue(letter.next) || letter.next == '\0' && keysIsRingingValueIsDeaf.ContainsKey(letter.current))
            {
                // Add deaf to phenemes. Get the value from the key.
                phonemes.Append(keysIsRingingValueIsDeaf[letter.current]);
                return;
            }
            // Check on ringing. If first symbol is deaf, next symbol is ringing
            // change the deaf to the ringing.
            else if (keysIsRingingValueIsDeaf.ContainsValue(letter.current) && keysIsRingingValueIsDeaf.ContainsKey(letter.next) && letter.next != 'в')
            {
                // Add ringing to phenemes. Get the key from the value;
                phonemes.Append(keysIsRingingValueIsDeaf.FirstOrDefault(x => x.Value == letter.current).Key);
                return;
            }
            phonemes.Append(letter.current);
        }
        /// <summary>
        /// A method defines the stress vawel or not and adds vawel in phonemes.
        /// </summary>
        /// <param name="index">Index of symbol</param>
        /// <param name="word">Symbol</param>
        /// <param name="stress">Index of stress</param>
        /// <param name="phonemes">Line of phonemes</param>
        public void AddOtherVowelToPhonemes(int index, char word, int stress, ref StringBuilder phonemes)
        {
            if (word == 'о' && index != stress)
            {
                phonemes.Append("а");
                return;
            }
            phonemes.Append(word);
        }
    }
}
