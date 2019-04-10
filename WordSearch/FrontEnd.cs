using System;
using WordSearch.Common;

/*======================================================*
*  Handle user-facing (front-end) console functionality *
*=======================================================*/

namespace WordSearch
{
    public static class FrontEnd
    {
        /*==================================================*
        *  Print messages to user in UI (console) front-end *
        *===================================================*/
        public static void MessageGreet()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Welcome to Word Search! Find words from differnet category lists.{Environment.NewLine}" +
                $"Each time you play the game the grid is re-shuffled.");
        }
        public static void MessagePromptStart()
        {
            Console.Write($"{Environment.NewLine}Press ");
            CharColourGreen('P');
            Console.Write($" to Play game. ");
            Console.Write($"Press ");
            CharColourRed('Q');
            Console.Write($" to Quit.{Environment.NewLine}");
        }
        public static void MessageListSize()
        {
            Console.WriteLine($"{Environment.NewLine}Select a list size:{Environment.NewLine}");
            CharColourGreen('S');
            Console.Write("mall, ");
            CharColourGreen('M');
            Console.Write("edium, ");
            CharColourGreen('L');
            Console.Write("arge.");
            Console.WriteLine();
        }
        public static void MessageListSelect()
        {
            Console.WriteLine($"{Environment.NewLine}Select a list:{Environment.NewLine}");
            PrintListOfLists(DataHandler.AllLists());
            Console.WriteLine();
        }
        public static void MessagePromptRestart()
        {
            Console.Write($"{Environment.NewLine}Press ");
            CharColourGreen('P');
            Console.Write($" to Play again. ");
            Console.Write($"Press ");
            CharColourRed('Q');
            Console.Write($" to Quit.{Environment.NewLine}");
        }
        public static void MessageEnd()
        {
            Console.WriteLine($"{Environment.NewLine}Made by NeetFreek {Environment.NewLine}" +
                $"2019{Environment.NewLine}" +
                $"https://neetfreek.net {Environment.NewLine}" +
                $"jonathan.widdowson@neetfreek.net");
        }

        /*==================================*
        *  Return user input to Program.cs  *
        *===================================*/
        public static char ReadUserInput()
        {
            char input = Console.ReadKey().KeyChar;
            input = char.ToLower(input);
            Console.Write("\b \b");

            return input;
        }

        /*==============================*
        *  Print words to find, grid    *
        *===============================*/
        public static void HandlePrintInGame(string[] words, char[,] grid)
        {
            Console.WriteLine($"{Environment.NewLine}=== WORDS ==={Environment.NewLine}");
            PrintWordsToFind(words);
            Console.WriteLine();

            Console.WriteLine($"{Environment.NewLine}=== WORD SEARCH ==={Environment.NewLine}");
            PrintGrid(grid);
        }
        private static void PrintWordsToFind(string[] vectorToPrint)
        {
            int counterNewLine = 0;
            int length = vectorToPrint.Length;

            for (int counter = 0; counter < length; counter++)
            {
                // Print each word to find seperated by space
                Console.Write($"{vectorToPrint[counter]} ");

                // new line every six words
                if (counter == 0)
                {
                    counterNewLine = 1;
                }
                else
                {
                    counterNewLine++;
                }
                if (counterNewLine % 6 == 0 && counter != length-1)
                {
                    Console.WriteLine();
                }
            }

        }
        private static void PrintGrid(char[,] matrixToPrint)
        {
            int numRows = matrixToPrint.GetLength(0);
            int numCols = matrixToPrint.GetLength(1);

            for (int counterRows = 0; counterRows < numRows; counterRows++)
            {
                for (int counterCols = 0; counterCols < numCols; counterCols++)
                {
                    // print grid element
                    Console.Write($"{matrixToPrint[counterRows, counterCols]}".PadLeft(2));
                }
                // move to next line to print next row
                Console.WriteLine();
            }
        }

        /*==================================================*
        *  Print names of category lists for user to choose *
        *===================================================*/
        private static void PrintListOfLists(string[] vectorToPrint)
        {
            int length = vectorToPrint.Length;

            for (int counter = 0; counter < length; counter++)
            {
                // Print first letter of list name in dark green
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                foreach (char character in vectorToPrint[counter])
                {
                    // print rest of list name in white
                    Console.Write($"{character}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                // Print space between list names
                Console.Write($" ");
            }
        }

        /*==================================================================*
        *  Change forground colour, print character, reset colour to white  *
        *===================================================================*/
        private static void CharColourGreen(char character)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(character);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static void CharColourRed(char character)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(character);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}