using System;

/*=================================================================*
*  Functionality for the creation, manipulation, testing symmetry, *
*      and printing vectors (1D arrays)                            *
*  Methods overloaded for CHARACTER, INTEGERS vectors (1D arrays)  *
*==================================================================*/
namespace WordSearch
{
    public static class Vectors
    {
        /*==================================================*
        *  Generate, return vectors.                        *
        *  Vector contains numEles number of elements       *   
        *  Vector's elements between eleMin, Max, inclusive *
        *  Character vectors return letters A-Z             *
        *===================================================*/
        public static int[] VectorRandom (int numEles, int eleMin, int eleMax)
        {
            // Declare, initialise vector with default (0) values
            int[] vector = new int[numEles];

            // Iterate elements 
            for (int counter = 0; counter < numEles; counter++)
            {
                // Assign elements
                vector[counter] = Helper.RandomInt(eleMin, eleMax);
            }

            return vector;
        }
        public static char[] VectorRandom(int numEles, char eleMin, char eleMax)
        {
            // Declare, initialise vector with default (0) values
            char[] vector = new char[numEles];

            // Ensure min, max elements correctly given
            if (eleMin > eleMax)
            {
                Console.WriteLine("Aborting: minimum element exceeds maximum element.");
                return vector;
            }

            // Iterate elements 
            for (int counter = 0; counter < numEles; counter++)
            {
                // Assign elements                
                vector[counter] = Helper.RandomLetter(eleMin, eleMax);
            }

            return vector;
        }

        /*==============================================================*
        *  Return number of elements in CHAR, INTEGER, STRING vector    *
        *===============================================================*/
        public static int CountElementsVector(int[] vector)
        {
            int count = 0;
            foreach (int integer in vector)
            {
                count++;
            }
            return count;
        }
        public static int CountElementsVector(char[] vector)
        {
            int count = 0;
            foreach (char character in vector)
            {
                count++;
            }
            return count;
        }
        public static int CountElementsVector(string[] vector)
        {
            int count = 0;
            foreach (string word in vector)
            {
                count++;
            }
            return count;
        }

        /*==================================================================*
        *  Return whether vector is symmetrical                             *
        *  Middle elements are excluded from check as always equals itself  *
        *===================================================================*/
        public static bool IsSymmetrical(int[] vector)
        {
            bool isSymmetrical = false;
            int length = vector.Length;

            // Iterate half elements
            for (int counter = 0; counter < length/2; counter++)
            {
                if (vector[counter] != vector[length -1 -counter])
                {
                    return isSymmetrical;
                }
            }
            isSymmetrical = true;

            return isSymmetrical;
        }
        public static bool IsSymmetrical(char[] vector)
        {
            bool isSymmetrical = false;
            int length = vector.Length;

            // Iterate half elements
            for (int counter = 0; counter < length / 2; counter++)
            {
                if (vector[counter] != vector[length - 1 - counter])
                {
                    return isSymmetrical;
                }
            }
            isSymmetrical = true;

            return isSymmetrical;
        }

        /*==================================================================*
        *  Return number of all CHARACTERS in all STRING elements of vector *
        *===================================================================*/
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

        /*==================================================================*
        *  Return STRING with most characters in vector                       *
        *===================================================================*/
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

        /*==========================*
        *  Print vector to console  *
        *===========================*/
        public static void PrintVector(char[] vectorToPrint)
        {
            {
                int length = vectorToPrint.Length;

                // Iterate elements
                for (int i = 0; i < length; i++)
                {
                    // Print element with space
                    Console.Write($"{vectorToPrint[i]} ");
                }
                // 
                Console.Write(Environment.NewLine);
            }
        }
        public static void PrintVector(int[] vectorToPrint)
        {
            int length = vectorToPrint.Length;

            // Iterate elements
            for (int i = 0; i < length; i++)
            {
                // Print element with space
                Console.Write($"{vectorToPrint[i]} ");
            }
            // 
            Console.Write(Environment.NewLine);
        }
        public static void PrintVector(string[] vectorToPrint)
        {
            int length = vectorToPrint.Length;

            // Iterate elements
            for (int i = 0; i < length; i++)
            {
                // Print element with space
                Console.Write($"{vectorToPrint[i]} ");
            }
            // 
            Console.Write(Environment.NewLine);
        }
    }
}