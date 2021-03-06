﻿using System;
using System.Linq;

namespace Task_DEV_2_
{
    /// <summary>
    /// Class describes the letter and its neighbors.
    /// </summary>
    public class Letter
    {
        public char Previous { get; set; }
        public char Current { get; set; }
        public char Next { get; set; }
        public int Index { get; set; }
        readonly string vowels = "аоиеёэыуюя";
        readonly string consonants = "бвгджзйклмнпрстфхцчшщ";
        readonly string other = "ьъ\0";

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
            else if (other.Contains(letter))
            {
                return "other";
            }
            throw new ArgumentOutOfRangeException("letter", "Incorrected letter");
        }
    }
}
