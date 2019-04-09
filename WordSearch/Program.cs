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
        // set true in GameLoop, skips SetupLoop while loop on game restart
       static bool inGame = false;

        /*======================*
        *  Program entry point  *
        *=======================*/
        static void Main(string[] args)
        {
            StartSetup();
        }

        /*==================================*
        *  Game setup and setup user input  *
        *===================================*/
        private static void StartSetup()
        {
            FrontEnd.MessageGreet();
            FrontEnd.MessagePromptStart();
            SetupLoop();
        }
        private static void SetupLoop()
        {
            bool setup = true;

            while (setup && !inGame)
            {
                char input = FrontEnd.ReadUserInput();
                switch (input)
                {
                    case 'p':
                        HandleStartGame();
                        break;
                    case 'q':
                        Environment.Exit(0);
                        break;
                }
            }
            HandleStartGame();
        }

        /*==================================*
        *  Game start and in-game input     *
        *===================================*/
        private static void HandleStartGame()
        {
            FrontEnd.MessageLists();
            StartGame();
            GameLoop();
        }
        private static void StartGame()
        {
            string listSelected = "";

            while (listSelected == "")
            {
                char input = FrontEnd.ReadUserInput();

                switch (input)
                {
                    case 'a':
                        listSelected = "Animals";
                        break;
                    case 't':
                        listSelected = "Trees";
                        break;
                    case 'f':
                        listSelected = "Fish";
                        break;
                }
            }

            WordSearch wordSearch = new WordSearch();
            wordSearch.SetupWordSearch(listSelected);

            FrontEnd.HandlePrintInGame(wordSearch.words, wordSearch.grid);
            FrontEnd.MessageEnd();
        }
        private static void GameLoop()
        {
            FrontEnd.MessagePromptRestart();

            inGame = true;

            while (inGame)
            {
                char input = FrontEnd.ReadUserInput();

                switch (input)
                {
                    case 'p':
                        StartSetup();
                        break;
                    case 'q':
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}