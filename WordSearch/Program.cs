using System;

/*==========================================================*
*  Word Search startup project, entry point                 *
*  Handles setting up game by:                              *
*  1. Calling DataHandler.cs to get word list               *
*  2. Calling FrontEnd.cs handle user input, display output *
*  3. Calling WordSearch.cs to generate grid                *
*===========================================================*/

namespace WordSearch
{
    class Program
    {
        // set true in GameLoop, skips HandleNewGame while loop on game restart
       static bool inGame = false;

        /*======================*
        *  Program entry point  *
        *=======================*/
        static void Main(string[] args)
        {
            StartScreen();
        }

        /*==================================*
        *  Game setup and setup user input  *
        *===================================*/
        private static void StartScreen()
        {
            FrontEnd.MessageGreet();
            FrontEnd.MessagePromptStart();
            HandleNewGame();
        }

        private static void HandleNewGame()
        {
            bool setup = true;
            while (setup && !inGame)
            {
                char input = FrontEnd.ReadUserInput();
                switch (input)
                {
                    case 'p':
                        HandleSetupGame();
                        break;
                    case 'q':
                        Environment.Exit(0);
                        break;
                }
            }
            HandleSetupGame();
        }
        private static void HandleSetupGame()
        {
            FrontEnd.MessageListSize();
            int listSize = HandleGetSizeSelection();
            FrontEnd.MessageListSelect();
            string listSelected = HandleGetListSelection();
            SetupGame(listSize, listSelected);
            FrontEnd.MessagePromptRestart();
            GameLoop();
        }
        private static int HandleGetSizeSelection()
        {
            int listSize = 0;
            while (listSize == 0)
            {
                char input = FrontEnd.ReadUserInput();
                switch (input)
                {
                    case 's':
                        listSize = 6;
                        break;
                    case 'm':
                        listSize = 12;
                        break;
                    case 'l':
                        listSize = 18;
                        break;
                }
            }
            return listSize;
        }
        private static string HandleGetListSelection()
        {
            string listSelected = "";
            while (listSelected == "")
            {
                char input = FrontEnd.ReadUserInput();
                switch (input)
                {
                    case 'i':
                        listSelected = "Instruments";
                        break;
                    case 'm':
                        listSelected = "Mammals";
                        break;
                    case 'o':
                        listSelected = "Occupations";
                        break;
                }
            }
            return listSelected;
        }
        private static void SetupGame(int sizeList, string nameList)
        {
            WordSearch wordSearch = new WordSearch();
            wordSearch.SetupWordSearch(nameList, sizeList);

            FrontEnd.HandlePrintInGame(wordSearch.words, wordSearch.grid);
            FrontEnd.MessageEnd();
        }

        /*======================*
        * In-game user input    *
        *=======================*/
        private static void GameLoop()
        {
            inGame = true;
            while (inGame)
            {
                char input = FrontEnd.ReadUserInput();
                switch (input)
                {
                    case 'p':
                        StartScreen();
                        break;
                    case 'q':
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}