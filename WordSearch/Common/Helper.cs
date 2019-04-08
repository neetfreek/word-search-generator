using System;
using System.Text;

/*==============================================*
*  Common helper methods for AlgorithmsLibrary  *
*===============================================*/
namespace WordSearch
{
    public static class Helper
    {
        private static Random random = new Random();

        /*==============================================================*
        *  Return whether first INTEGER is greater than second INTEGER  *
        *   first > second (== true), first < second (== false)         *
        *===============================================================*/
        public static bool GreaterThan(int first, int second)
        {
            return first.CompareTo(second) > 0;
        }

        /*======================================*
        *  Return number of digits in INTEGER   *
        *=======================================*/
        public static int DigitsInInt(int number)
        {
            int numCharsInInt = number.ToString().Length;
            return numCharsInInt;
        }

        /*==========================================================*
        *  Return random INTEGER between intMin, intMax inclusive   *
        *===========================================================*/
        public static int RandomInt(int intMin, int intMax)
        {
            int intRandom = random.Next(intMin, intMax+1);

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
            int charsToInsertLength = (indexEnd - indexStart) +1;

            //int indexEnd = charSetTotal.IndexOf(maxFixed);

            if (indexStart == -1 | indexEnd == -1)
            {
                Console.WriteLine("Aborting. Entered character(s) not letters.");
                return ('\0');
            }

            string charSet = charSetTotal.Substring(indexStart, charsToInsertLength);
            char charToInsert = charSet[RandomInt(0, charSet.Length-1)];             

            return charToInsert;
        }

        /*======================================*
        *  Return numSpaces blank spaces (" ")  *
        *=======================================*/
        public static string Padding(int numSpaces)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int counter = 0; counter < numSpaces; counter++)
            {
                stringBuilder.Append(" ");
            }

            string gapAlignment = stringBuilder.ToString();

            return gapAlignment;
        }
    }
}