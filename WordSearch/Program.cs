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
            //Common.DataHandler.AllLists();
            StartGame();
        }

        /*==================================*
        *  Handle front end (console) calls  *
        *===================================*/
        public static void PrintStartUI(string[] words, char[,] grid)
        {
            PrintWords(words);
            PrintGrid(grid);
        }
        private static void PrintWords(string[] words)
        {
            Console.WriteLine($"{Environment.NewLine}=== WORDS ==={Environment.NewLine}");
            FrontEnd.PrintWordsToFind(words);
        }
        private static void PrintGrid(char[,] grid)
        {
            Console.WriteLine($"{Environment.NewLine}=== WORD SEARCH ==={Environment.NewLine}");
            FrontEnd.PrintMatrix(grid);
        }

        /*==============================*
        *  Handle play, re-play game    *
        *===============================*/
        private static void StartGame()
        {
            FrontEnd.MessageGreet();
            WordSearch wordSearch = new WordSearch();

            string listSelected = SetupListWords();
            wordSearch.SetupWordSearch(listSelected);

            FrontEnd.PrintGame(wordSearch.words, wordSearch.grid);
            FrontEnd.MessageEnd();

            if (FrontEnd.MessageRestartGame())
            {
                StartGame();
            }
        }

        private static string SetupListWords()
        {
            string listSelected = "";

            while (listSelected == "")
            {
                listSelected = FrontEnd.MessageSelectList();
            }

            return listSelected;
        }
    }
}