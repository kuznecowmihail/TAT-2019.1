using System.Linq;


namespace Task_DEV_2_
{
    class Letter
    {
        public char previous;
        public char current;
        public char next;
        public int index;
        private readonly string vowels = "аоиеёэыуюя";
        private readonly string consonants = "бвгджзйклмнпрстфхцчшщ";

        public Letter() { }

        /// <summary>
        /// A method defines type of letter and return.
        /// </summary>
        /// <param name="letter"></param>
        /// <returns vawel></returns>
        /// <returns consonant></returns>
        /// <returns other></returns>
        public string DefineTypeOfSymbol(char letter)
        {
            if (vowels.Contains(letter))
            {
                return "vowel";
            }
            else if (consonants.Contains(letter))
            {
                return "consonant";
            }
            return "other";
        }
    }
}
