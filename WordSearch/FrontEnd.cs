/*==============================================================*
*  Manage get user input, print output to user through console  *
*===============================================================*
*  1. Print messages to user:                                   *
*   a. Greeting message                                         *
*   b. Prompt user to select play or quit on first play         *
*   c. Prompt user to select word list size                     *
*   d. Prompt user to select word list category                 *
*   e. Prompt user to select play or quit after first play      *
*   f. Information about NeetFreek                              *
*  2. Print names of category lists for user to choose from     *
*  3. Print game elements:                                      *
*   a. List of Words for user to find                           *
*   b. Game Grid comprised of Words' and random characters      *
*  4. Get user input                                            *
*  5. Change characters' colours (foreground colours)           *
*===============================================================*/
using System;
using WordSearch.Common;

namespace WordSearch
{
    public static class FrontEnd
    {
        /*==================*
        * 1. Print messages *
        *===================*/
        public static void MessageGreet()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Welcome to Word Search! Find Words from differnet category lists.{Environment.NewLine}" +
                $"Each time you play the game the Grid is re-shuffled.");
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
        public static void MessagePromptListSize()
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
        public static void MessagePromptListSelect()
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
        public static void MessageNFInfo()
        {
            Console.WriteLine($"{Environment.NewLine}Made by NeetFreek {Environment.NewLine}" +
                $"2019{Environment.NewLine}" +
                $"https://neetfreek.net {Environment.NewLine}" +
                $"jonathan.widdowson@neetfreek.net");
        }

        /*==================================*
        *  2. Print list of word categories *
        *===================================*/
        private static void PrintListOfLists(string[] array)
        {
            int length = array.Length;

            for (int counter = 0; counter < length; counter++)
            {
                // Print first letter of list name in dark green
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                foreach (char character in array[counter])
                {
                    // print rest of list name in white
                    Console.Write($"{character}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                // Print space between list names
                Console.Write($" ");
            }
        }

        /*==========================*
        *  3. Print game elements:  *
        *===========================*/
        public static void HandlePrintGame(string[] words, char[,] grid)
        {
            Console.WriteLine($"{Environment.NewLine}=== WORDS ==={Environment.NewLine}");
            PrintGameWordsList(words);
            Console.WriteLine();

            Console.WriteLine($"{Environment.NewLine}=== WORD SEARCH ==={Environment.NewLine}");
            PrintGameGrid(grid);
        }
        private static void PrintGameWordsList(string[] array)
        {
            int counterNewLine = 0;
            int length = array.Length;

            for (int counter = 0; counter < length; counter++)
            {
                // Print each word to find seperated by space
                Console.Write($"{array[counter]} ");

                // new line every six Words
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
        private static void PrintGameGrid(char[,] matrixToPrint)
        {
            int numRows = matrixToPrint.GetLength(0);
            int numCols = matrixToPrint.GetLength(1);

            for (int counterRows = 0; counterRows < numRows; counterRows++)
            {
                for (int counterCols = 0; counterCols < numCols; counterCols++)
                {
                    // print Grid element
                    Console.Write($"{matrixToPrint[counterRows, counterCols]}".PadLeft(2));
                }
                // move to next line to print next row
                Console.WriteLine();
            }
        }

        /*======================*
        *  4. Get user input    *
        *=======================*/
        public static char ReadUserInput()
        {
            char input = Console.ReadKey().KeyChar;
            input = char.ToLower(input);
            Console.Write("\b \b");

            return input;
        }

        /*==================================*
        *  5. Change characters' colours    *
        *===================================*/
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