/*==========================================================*
*  Common helper methods for Word Search.                   *
*===========================================================*
*  1. Return all STRING elements in array1D capitalised     *
*  2. Return counts:                                        *
*   a. Characters in STRINGS                                *
*   b. Digits in INTEGERS                                   *
*   c. Elements in arrays1D                                 * 
*  3. Return longest STRING in STRING array1D               *
*  4. Return random (inclusive) CHARACTERS (a-z), INTEGERS  *
*===========================================================*/
using System;

namespace WordSearch.Common
{
    public static class Helper
    {
        /*==================================================================================*
        *  Used in Random() methods                                                         *
        *  Delcared here to prevent same Random.Next() values when used in quick succession *
        *===================================================================================*/
        private static Random random = new Random();

        /*======================================*
        *  1. Return capitalised Words array1D  *
        *=======================================*/
        public static string[] CapitaliseWordsAll(string[] array)
        {
            string[] arrayCapitalised = new string[array.Length];
            string wordCapitalised = "";

            for (int word = 0; word < array.Length; word++)
            {
                wordCapitalised = array[word].ToUpper();
                arrayCapitalised[word] = wordCapitalised;
            }
            return arrayCapitalised;
        }

        /*==================*
        *  2. Return counts *
        *===================*/
        public static int CountDigits(int number)
        {
            int numCharsInInt = number.ToString().Length;

            return numCharsInInt;
        }
        public static int CountWordsCharactersAll(string[] array)
        {
            int count = 0;
            foreach (string word in array)
            {
                foreach (char character in word)
                {
                    count++;
                }
            }
            return count;
        }
        public static int CountElements(string[] array)
        {
            int count = 0;
            foreach (string word in array)
            {
                count++;
            }
            return count;
        }

        /*==========================*
        *  3. Return longest word   *
        *===========================*/
        public static string LongestWord(string[] array)
        {
            string longestWord = "";

            foreach (string word in array)
            {
                if (word.Length > longestWord.Length)
                {
                    longestWord = word;
                }
            }
            return longestWord;
        }

        /*==========================*
        *  4. Return random values  *
        *===========================*/
        public static int Random(int intMin, int intMax)
        {
            int intRandom = random.Next(intMin, intMax + 1);

            return intRandom;
        }
        public static char Random(char min, char max)
        {
            char minFixed = char.ToUpper(min);
            char maxFixed = char.ToUpper(max);
            string charSetTotal = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int indexStart = charSetTotal.IndexOf(minFixed);
            int indexEnd = charSetTotal.IndexOf(maxFixed);
            int charsToInsertLength = (indexEnd - indexStart) + 1;

            // Return default null value('\0') if min or max not letter
            if (indexStart == -1 | indexEnd == -1)
            {
                return ('\0');
            }

            string charSet = charSetTotal.Substring(indexStart, charsToInsertLength);
            char charToInsert = charSet[Random(0, charSet.Length - 1)];

            return charToInsert;
        }
    }
}