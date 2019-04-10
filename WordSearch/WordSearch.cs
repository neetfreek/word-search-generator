/*==================================================================================*
*  Manage and hold word list, grid                                                  *
*===================================================================================*
* 1. Contain words to find and Grid properties, set via fields                      *
* 2. Handle setup of words to find array, DataHandler called to return words array  *
* 3. ROUTINE: Handle setup of grid:                                                 *
*   a. Handle setup empty grid                                                      *
*       i. Size based on 1) total number characters in words 2) longest word        *
*       ii. Create empty grid                                                       *
*   b. Handle populate grid with words to find                                      *
*   c. Populate remaining empty grid elements with random characters                *
* 4. Check words have space to fit in grid with different directions, orders        *
* 5. Place words in grid in different directions, orders                            *
*===================================================================================*/
using System;
using WordSearch.Common;

namespace WordSearch
{
    public class WordSearch
    {
        /*==============================================================================*
        *  1. Fields for setting and properties for safe access of word array and grid  *
        *   a. Fields set in HandleSetupWords(), HandleSetupGrid()                      *
        *   b. Properties used by this and other classes                                *
        *===============================================================================*/
        private string[] words;
        private char[,] grid;
        // properties for access
        public string[] Words
        {
            get
            {
                return words;
            }
        }
        public char[,] Grid
        {
            get
            {
                return grid;
            }
        }

        /*==================================*
        *  2. Handle setup words to find    *
        *===================================*/
        public void HandleSetupWords(string listSelected, int listSize)
        {
            words = DataHandler.HandleListLoad(listSelected, listSize);

            //return Words;
        }

        /*======================================*
        *  3. Handle setup grid size, populate  *
        *=======================================*/
        public void HandleSetupGrid()
        {
            HandleSetupEmptyGrid();
            PopulateGridWords(Words, Grid);
            PopulateEmptyElements(Grid);
        }
        /*==============================*
        *  3.a. Handle setup empty grid *
        *===============================*/
        private void HandleSetupEmptyGrid()
        {
            // Declare, initialise with null () values, grids
            int numCharsInWords = Helper.CountWordsCharactersAll(Words);
            int lengthLongestWord = Helper.LongestWord(Words).Length;
            int numGridRowsCols = SetGridSize(numCharsInWords, lengthLongestWord);
            SetupEmptyGrid(numGridRowsCols);
        }
        private int SetGridSize(int numCharsInWords, int lengthLongestWord)
        {
            // minimum Grid dimensions to fit longest wordCurrent
            int sizeMinGrid = lengthLongestWord * lengthLongestWord;

            // add extra Grid elements to ensure enough space for non-wordCurrent characters
            int totalElementsGrid = numCharsInWords * 3;

            int totalElementsGridSquare = (int)Math.Sqrt(totalElementsGrid);

            // increase current number of Grid elements until reaches next root of square (e.g. 5, 6, 7)
            while (Math.Sqrt(sizeMinGrid) != totalElementsGridSquare + 1)
            {
                sizeMinGrid++;
            }

            // get number of rows/cols
            int numRowsCols = (int)Math.Sqrt(sizeMinGrid);

            // optionally add some random rows
            //Random random = new Random();
            //int extraRows = random.Next(0,3);
            //numRowsCols += extraRows;

            return numRowsCols;
        }
        private void SetupEmptyGrid(int numGridElements)
        {
            grid = new char[numGridElements, numGridElements];
        }
        /*======================================*
        *  3.b. Handle populate grid with words *
        *=======================================*/
        private void PopulateGridWords(string[] words, char[,] grid)
        {
            bool wordPlaced = false;
            int numberWordsToPlace = Helper.CountElements(words);

            // iterate Words to place
            for (int wordCurrent = 0; wordCurrent < numberWordsToPlace; wordCurrent++)
            {
                wordPlaced = false;
                while (!wordPlaced)
                {
                    // Get random starting point for word
                    GridPosition coord = new GridPosition(Helper.Random(0, grid.GetLength(0) - 1), Helper.Random(0, grid.GetLength(1) - 1));
                    if (PlaceWordInGrid(coord, words[wordCurrent], grid))
                    {
                        wordPlaced = true;
                    }
                }
            }
        }        
        private bool PlaceWordInGrid(GridPosition pos, string word, char[,] grid)
        {
            int x = pos.Row;
            int y = pos.Col;

            // elements represent placements options, 0 == left->right, 1 = right->left, etc. (in order presented below)
            int[] placementOptions = new int[8] { 9, 9, 9, 9, 9, 9, 9, 9 };
            int placementOption = 9;
            bool haveOptions = false;

            for (int counter = 0; counter < word.Length; counter++)
            {
                // If point empty or point contains same letter word's current character
                if (grid[x, y] == '\0' | grid[x, y] == word[0])
                {
                    if (SpaceRight(word, pos, grid))
                    {
                        placementOptions[0] = 1;
                        haveOptions = true;
                    }
                    if (SpaceLeft(word, pos, grid))
                    {
                        placementOptions[1] = 2;
                        haveOptions = true;
                    }
                    if (SpaceDown(word, pos, grid))
                    {
                        placementOptions[2] = 3;
                        haveOptions = true;
                    }
                    if (SpaceUp(word, pos, grid))
                    {
                        placementOptions[3] = 4;
                        haveOptions = true;
                    }
                    if (SpaceUpRight(word, pos, grid))
                    {
                        placementOptions[4] = 5;
                        haveOptions = true;
                    }
                    if (SpaceDownRight(word, pos, grid))
                    {
                        placementOptions[5] = 6;
                        haveOptions = true;
                    }
                    if (SpaceUpLeft(word, pos, grid))
                    {
                        placementOptions[6] = 7;
                        haveOptions = true;
                    }
                    if (SpaceDownLeft(word, pos, grid))
                    {
                        placementOptions[7] = 8;
                        haveOptions = true;
                    }

                    if (haveOptions)
                    {
                        while (placementOption == 9)
                        {
                            placementOption = placementOptions[Helper.Random(0, placementOptions.Length - 1)];
                        }

                        switch (placementOption)
                        {
                            case 1:
                                PlaceWordRight(word, pos, grid);
                                break;                                     
                            case 2:                                        
                                PlaceWordLeft(word, pos, grid);          
                                break;
                            case 3:
                                PlaceWordDown(word, pos, grid);
                                break;
                            case 4:                                       
                                PlaceWordUp(word, pos, grid);           
                                break;
                            case 5:
                                PlaceWordUpRight(word, pos, grid);           
                                break;
                            case 6:
                                PlaceWordDownRight(word, pos, grid);
                                break;
                            case 7:
                                PlaceWordUpLeft(word, pos, grid);
                                break;
                            case 8:
                                PlaceWordDownLeft(word, pos, grid);
                                break;
                        }
                        return true;
                    }
                }                
            }
            return false;
        }
        /*======================================*
        *  3.c. Populate empty grid elements    *
        *=======================================*/
        private void PopulateEmptyElements(char[,] grid)
        {
            for (int counterRow = 0; counterRow < grid.GetLength(0); counterRow++)
            {
                for (int counterCol = 0; counterCol < grid.GetLength(1); counterCol++)
                {
                    if (grid[counterRow, counterCol] == '\0')
                    {
                        grid[counterRow, counterCol] = Helper.Random('a', 'z');
                    }
                }
            }
        }

        /*==============================*
        *  4. Check words fit in grid   *
        *===============================*/
        private bool SpaceRight(string word, GridPosition pos, char[,] grid)
        {
            if ((grid.GetLength(0)) - pos.Col >= word.Length)
            {
                // iterate right in row, checking each successive element empty or same as current char
                for (int counter = 0; counter < word.Length; counter++)
                {
                    if (grid[pos.Row, pos.Col + counter] != '\0' && grid[pos.Row, pos.Col + counter] != word[counter])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        } // check space left -> right
        private bool SpaceLeft(string word, GridPosition pos, char[,] grid)
        {
            if (pos.Col >= word.Length - 1)
            {
                // iterate left in row, checking each successive element empty or same as current char
                for (int counter = 0; counter < word.Length; counter++)
                {
                    if (grid[pos.Row, pos.Col - counter] != '\0' && grid[pos.Row, pos.Col - counter] != word[counter])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        } // check space right -> left
        private bool SpaceDown(string word, GridPosition pos, char[,] grid)
        {
            if ((grid.GetLength(0)) - pos.Row >= word.Length)
            {
                // iterate right in row, checking each successive element empty or same as current char
                for (int counter = 0; counter < word.Length; counter++)
                {
                    if (grid[pos.Row + counter, pos.Col] != '\0' && grid[pos.Row + counter, pos.Col] != word[counter])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        } // check space up -> down
        private bool SpaceUp(string word, GridPosition pos, char[,] grid)
        {
            if (pos.Row >= word.Length - 1)
            {
                // iterate left in row, checking each successive element empty or same as current char
                for (int counter = 0; counter < word.Length; counter++)
                {
                    if (grid[pos.Row - counter, pos.Col] != '\0' && grid[pos.Row - counter, pos.Col] != word[counter])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        } // check space down -> up
        private bool SpaceUpRight(string word, GridPosition pos, char[,] grid)
        {
            if ((grid.GetLength(0)) - pos.Col >= word.Length && // if space right
                (pos.Row >= word.Length - 1)) // if space up
            {
                // iterate right in row, checking each successive element empty or same as current char
                for (int counter = 0; counter < word.Length; counter++)
                {
                    if (grid[pos.Row - counter, pos.Col + counter] != '\0' && grid[pos.Row - counter, pos.Col + counter] != word[counter])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        } // check space diagonal left -> up right
        private bool SpaceDownRight(string word, GridPosition pos, char[,] grid)
        {
            if ((grid.GetLength(0)) - pos.Col >= word.Length && // if space right
                (grid.GetLength(1)) - pos.Row >= word.Length) // if space down
            {
                // iterate right in row, checking each successive element empty or same as current char
                for (int counter = 0; counter < word.Length; counter++)
                {
                    if (grid[pos.Row + counter, pos.Col + counter] != '\0' && grid[pos.Row + counter, pos.Col + counter] != word[counter])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        } // check space diagonal left -> down right
        private bool SpaceUpLeft(string word, GridPosition pos, char[,] grid)
        {
            if (pos.Row >= word.Length - 1 && // if space up
                pos.Col >= word.Length - 1) // if space left
            {
                // iterate right in row, checking each successive element empty or same as current char
                for (int counter = 0; counter < word.Length; counter++)
                {
                    if (grid[pos.Row - counter, pos.Col - counter] != '\0' && grid[pos.Row - counter, pos.Col - counter] != word[counter])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        } // check space diagonal left -> up right
        private bool SpaceDownLeft(string word, GridPosition pos, char[,] grid)
        {
            if ((grid.GetLength(0)) - pos.Row >= word.Length && // if space down
                pos.Col >= word.Length - 1) // if space left
            {
                // iterate right in row, checking each successive element empty or same as current char
                for (int counter = 0; counter < word.Length; counter++)
                {
                    if (grid[pos.Row + counter, pos.Col - counter] != '\0' && grid[pos.Row + counter, pos.Col - counter] != word[counter])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        } // check space diagonal left -> up right

        /*==============================*
        *  5. Word placement in grid    *
        *===============================*/
        private void PlaceWordRight(string word, GridPosition pos, char[,] grid)
        {
            for (int counter = 0; counter < word.Length; counter++)
            {
                grid[pos.Row, pos.Col + counter] = word[counter];
            }
        } // place word left -> right
        private void PlaceWordLeft(string word, GridPosition pos, char[,] grid)
        {
            for (int counter = 0; counter < word.Length; counter++)
            {
                grid[pos.Row, pos.Col - counter] = word[counter];
            }
        } // place word right -> left
        private void PlaceWordDown(string word, GridPosition pos, char[,] grid)
        {
            for (int counter = 0; counter < word.Length; counter++)
            {
                grid[pos.Row + counter, pos.Col] = word[counter];
            }
        } // place word up -> down
        private void PlaceWordUp(string word, GridPosition pos, char[,] grid)
        {
            for (int counter = 0; counter < word.Length; counter++)
            {
                grid[pos.Row - counter, pos.Col] = word[counter];
            }
        } // place word down -> up
        private void PlaceWordUpRight(string word, GridPosition pos, char[,] grid)
        {
            for (int counter = 0; counter < word.Length; counter++)
            {
                grid[pos.Row - counter, pos.Col + counter] = word[counter];
            }
        } // place word diagonal left -> up right
        private void PlaceWordDownRight(string word, GridPosition pos, char[,] grid)
        {
            for (int counter = 0; counter < word.Length; counter++)
            {
                grid[pos.Row + counter, pos.Col + counter] = word[counter];
            }
        } // place word diagonal left -> down right
        private void PlaceWordUpLeft(string word, GridPosition pos, char[,] grid)
        {
            for (int counter = 0; counter < word.Length; counter++)
            {
                grid[pos.Row - counter, pos.Col - counter] = word[counter];
            }
        } // place word diagonal left -> up left
        private void PlaceWordDownLeft(string word, GridPosition pos, char[,] grid)
        {
            for (int counter = 0; counter < word.Length; counter++)
            {
                grid[pos.Row + counter, pos.Col - counter] = word[counter];
            }
        } // place word diagonal left -> down left
    }
}