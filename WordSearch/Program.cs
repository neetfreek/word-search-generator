using System;

/*==========================================*
*  Word Search startup project, entry point *
*  Call start of Word Search functionality  *
*  Call front end (console) functionality   *
*===========================================*/

namespace WordSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            GameLoop();
        }

        /*==================================*
        *  Handle fron end (console) calls  *
        *===================================*/
        public static void PrintStartUI(string[] words, char[,] grid)
        {
            PrintWords(words);
            PrintGrid(grid);
        }
        private static void PrintWords(string[] words)
        {
            Console.WriteLine($"{Environment.NewLine}=== WORDS ==={Environment.NewLine}");
            FrontEnd.PrintVector(words);
        }
        private static void PrintGrid(char[,] grid)
        {
            Console.WriteLine($"{Environment.NewLine}=== WORD SEARCH ==={Environment.NewLine}");
            FrontEnd.PrintMatrix(grid);
        }

        /*==============================*
        *  Handle play, re-play game    *
        *===============================*/
        private static void GameLoop()
        {
            WordSearch wordSearch = new WordSearch();

            FrontEnd.MessageGreet();
            wordSearch.SetupWordSearch();
            PrintStartUI(wordSearch.words, wordSearch.grid);
            FrontEnd.MessageEnd();

            if (FrontEnd.MessageRestartGame())
            {
                GameLoop();
            }
        }
    }
}