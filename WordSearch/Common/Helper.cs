using System;

/*==========================================*
*  Common helper methods for Word Search    *
*===========================================*/
namespace WordSearch
{
    public static class Helper
    {
        private static Random random = new Random();
                              
        /*==================================================================*
        *  Return STRING vector with all strings' CHARACTERS capitalised    *
        *===================================================================*/
        public static string[] CaptitaliseAll(string[] vector)
        {
            string toAdd = "";

            string[] vectorCapitalised = new string[vector.Length];

            for (int word = 0; word < vector.Length; word++)
            {
                toAdd = "";
                toAdd = vector[word].ToUpper();
                vectorCapitalised[word] = toAdd;
            }

            return vectorCapitalised;
        }

        /*======================================*
        *  Return number of digits in INTEGER   *
        *=======================================*/
        public static int CountDigitsInt(int number)
        {
            int numCharsInInt = number.ToString().Length;
            return numCharsInInt;
        }

        /*==============================================*
        *  Return INT number of elements in STRING vector   *
        *===============================================*/
        public static int CountElementsVector(string[] vector)
        {
            int count = 0;
            foreach (string word in vector)
            {
                count++;
            }
            return count;
        }

        /*======================================================================*
        *  Return INT number of all CHARACTERS in all elements of STRING vector *
        *=======================================================================*/
        public static int CountLettersVector(string[] vector)
        {
            int count = 0;
            foreach (string word in vector)
            {
                foreach (char character in word)
                {
                    count++;
                }
            }

            return count;
        }

        /*======================================================*
        *  Return STRING with most characters in STRING vector  *
        *=======================================================*/
        public static string LongestWordVector(string[] vector)
        {
            string longestWord = "";

            foreach (string word in vector)
            {
                if (word.Length > longestWord.Length)
                {
                    longestWord = word;
                }
            }

            return longestWord;
        }

        /*==========================================================*
        *  Return random INTEGER between intMin, intMax inclusive   *
        *===========================================================*/
        public static int RandomInt(int intMin, int intMax)
        {
            int intRandom = random.Next(intMin, intMax + 1);

            return intRandom;
        }

        /*======================================================================*
        *  Return random CHARACTER (letter) between intMin, intMax inclusive    *
        *  return "null" ('\0') if min, max not letter                          *
        *=======================================================================*/
        public static char RandomLetter(char min, char max)
        {
            char minFixed = char.ToUpper(min);
            char maxFixed = char.ToUpper(max);
            string charSetTotal = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int indexStart = charSetTotal.IndexOf(minFixed);
            int indexEnd = charSetTotal.IndexOf(maxFixed);
            int charsToInsertLength = (indexEnd - indexStart) + 1;

            //int indexEnd = charSetTotal.IndexOf(maxFixed);

            if (indexStart == -1 | indexEnd == -1)
            {
                Console.WriteLine("Aborting. Entered character(s) not letters.");
                return ('\0');
            }

            string charSet = charSetTotal.Substring(indexStart, charsToInsertLength);
            char charToInsert = charSet[RandomInt(0, charSet.Length - 1)];

            return charToInsert;
        }

        /*==============================================================================================*
        *  Return random <INTEGER, INTEGER> point between intMin, intMax inclusive in CHARACTER matrix  *
        *===============================================================================================*/
        public static Tuple<int, int> RandomPointMatrix(char[,] matrix)
        {
            int x = Helper.RandomInt(0, matrix.GetLength(0) - 1);
            int y = Helper.RandomInt(0, matrix.GetLength(1) - 1);
            Tuple<int, int> point = new Tuple<int, int>(x, y);

            return point;
        }
    }
}