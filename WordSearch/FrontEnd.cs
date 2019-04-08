using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearch
{
    class FrontEnd
    {
        static void Main(string[] args)
        {
            StartGame();
        }

        public static void PrintWords(string[] words)
        {
            Console.WriteLine($"{Environment.NewLine}=== WORDS ==={Environment.NewLine}");
            Vectors.PrintVector(words);
        }

        public static void PrintGrid(char[,] grid)
        {
            Console.WriteLine($"{Environment.NewLine}=== WORD SEARCH ==={Environment.NewLine}");
            Matrices.PrintMatrix(grid);
        }

        private static void StartGame()
        {
            Greet();
            WordSearch.StartWordSearch();
            RestartOrQuit();
        }

        private static void Greet()
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

        private static void RestartOrQuit()
        {
            Console.WriteLine($"{Environment.NewLine}Made by NeetFreek {Environment.NewLine}" +
                $"2019{Environment.NewLine}" +
                $"https://neetfreek.net {Environment.NewLine}" +
                $"jonathan.widdowson@neetfreek.net");
            char input = Console.ReadKey().KeyChar;

            if (input == 'P' | input == 'p')
            {
                Console.Clear();
                StartGame();
            }
        }
    }
}
