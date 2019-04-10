/*======================================================================================*
*  Word Search startup project. Controls program flow.  | <(^^ )><(^ ^)><( ^^)> NF 2019 *
*  =====================================================================================*
*  1. Contains Main() entry program entry point:                                        *
*   a. Call to display first game message                                               *
*   b. Start game                                                                       *
*  3. ROUTINE: Handle game control flow:                                                *
*   a. Read input to start, quit game                                                   *
*   b. Handle setting up game:                                                          *
*       i. Get word list size from user                                                 *
*       ii. Get word list category from player                                          *
*       iii. Setup game by instantiate, call, wordSearch object to set up Grid, Words   *  
*       iv.  Call GameLoop() to read player input in-game to play again, quit           *
*  4. Handle in-game user input to play again, quit                                     *
*  MISC: Call FrontEnd to get user input, print output to user through console          *
*=======================================================================================*/
using System;

namespace WordSearch
{
    class Program
    {
        // set true in GameLoop, skips ReadStartQuitGame while loop when restarting
       private static bool inGame = false;

        /*=========================*
        *  1. Program entry point  *
        *==========================*/
        private static void Main(string[] args)
        {
            FirstGameMessage();
            ReadStartQuitGame();
        }
        private static void FirstGameMessage()
        {
            FrontEnd.MessageGreet();
            FrontEnd.MessagePromptStart();
        }
        
        /*==============================*
        *  3. Handle game control flow  *
        *===============================*/
        private static void ReadStartQuitGame()
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
            FrontEnd.MessagePromptListSize();
            int listSize = HandleGetSizeSelection();
            FrontEnd.MessagePromptListSelect();
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
            wordSearch.HandleSetupWords(nameList, sizeList);
            wordSearch.HandleSetupGrid();

            FrontEnd.HandlePrintGame(wordSearch.Words, wordSearch.Grid);
            FrontEnd.MessageNFInfo();
        }

        /*======================*
        * 4. In-game user input *
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
                        ReadStartQuitGame();
                        break;
                    case 'q':
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}