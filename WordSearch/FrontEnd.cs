using System;
using System.Text;

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
            Console.WriteLine($"Welcome to Word Search! Try to find the words listed in the grid below.{Environment.NewLine}" +
                $"Each time you play the game the grid is re-shuffled.{Environment.NewLine}");
            Console.Write("Press ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("P");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" to play again, or any other key to quit.{Environment.NewLine}");
        }
        public static void MessageEnd()
        {
            Console.WriteLine($"{Environment.NewLine}Made by NeetFreek {Environment.NewLine}" +
                $"2019{Environment.NewLine}" +
                $"https://neetfreek.net {Environment.NewLine}" +
                $"jonathan.widdowson@neetfreek.net");
        }
        public static bool MessageRestartGame()
        {
            char input = Console.ReadKey().KeyChar;
            if (input == 'P' | input == 'p')
            {
                Console.Clear();
                return true;
            }
            return false;
        }

        /*=========================================================*
        *  Print grid (2D array) to user in UI (console) front-end *
        *==========================================================*/
        public static void PrintMatrix(char[,] matrixToPrint)
        {
            int numRows = matrixToPrint.GetLength(0);
            int numCols = matrixToPrint.GetLength(1);

            // number of digits in largest element
            // padding prepended to number to align elements printed
            string padding = " ";

            // iterate rows
            for (int counterRows = 0; counterRows < numRows; counterRows++)
            {
                // iterate columns, print elements
                for (int counterCols = 0; counterCols < numCols; counterCols++)
                {
                    Console.Write($"{padding}{matrixToPrint[counterRows, counterCols]} ");
                }
                // move to next line to print next row
                Console.WriteLine();
            }
        }

        /*==============================================================*
        *  Print vector (1D array) to user in UI (console) front-end    *
        *===============================================================*/
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