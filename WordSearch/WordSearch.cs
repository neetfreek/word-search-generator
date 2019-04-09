using System;
using WordSearch.Common;
/*======================================*
*  Word list, grid setup functionality  *
*=======================================*/

namespace WordSearch
{
    public class WordSearch
    {
        public string[] words;
        public char[,] grid;

        /*==============================================================================*
        *  Handle creation of words to find, grid, call front-end to display to user    *
        *===============================================================================*/
        public void SetupWordSearch()
        {
            SetupWords();
            SetupGrid();
        }

        /*==================================================*
        *  Word list (vector/1D array) setup functionality  *
        *===================================================*/
        private string[] SetupWords()
        {
            string[] wordsInput = new string[] { "chicken", "frog", "cat", "dog", "goat", "moose", "lion", "dolphon", "lemur", "antelope" };
            words = Helper.CaptitaliseAll(wordsInput);

            return words;
        }

        /*==============================================*
        *  Grid (matrix/2D array) setup functionality   *
        *===============================================*/
        private void SetupGrid()
        {
            // Declare, initialise with null () values, grids
            int numCharsInWords = Helper.CountLettersVector(words);
            int lengthLongestWord = Helper.LongestWordVector(words).Length;
            int numGridRowsCols = NumberGridRowsCols(numCharsInWords, lengthLongestWord);
            grid = CreatGrid(numGridRowsCols);

            // Populate grid with words, random letters
            PopulateGridWords(words, grid);
            //FillRemainingElements(grid);
        }
        private int NumberGridRowsCols(int numCharsInWords, int lengthLongestWord)
        {
            // minimum grid dimensions to fit longest wordCurrent
            int sizeMinGrid = lengthLongestWord * lengthLongestWord;

            // add extra grid elements to ensure enough space for non-wordCurrent characters
            int totalElementsGrid = numCharsInWords * 3;

            int totalElementsGridSquare = (int)Math.Sqrt(totalElementsGrid);

            // increase current number of grid elements until reaches next root of square (e.g. 5, 6, 7)
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
        private char[,] CreatGrid(int numGridElements)
        {
            // empty grid
            char[,] grid = new char[numGridElements, numGridElements];
            return grid;
        }

        /*==============================*
        *  Handle place words in grid   *
        *===============================*/
        private void PopulateGridWords(string[] words, char[,] grid)
        {
            bool wordPlaced = false;
            int numberWordsToPlace = Helper.CountElementsVector(words);

            // iterate words to place
            for (int wordCurrent = 0; wordCurrent < numberWordsToPlace; wordCurrent++)
            {
                wordPlaced = false;
                while (!wordPlaced)
                {
                    // Get random starting point for word
                    GridPosition2D coord = new GridPosition2D(Helper.RandomInt(0, grid.GetLength(0) - 1), Helper.RandomInt(0, grid.GetLength(1) - 1));
                    if (PlaceWordInGrid(coord, words[wordCurrent], grid))
                    {
                        wordPlaced = true;
                    }
                }
            }

            // fill remaining empty elements with random letters

        }        
        private bool PlaceWordInGrid(GridPosition2D pos, string word, char[,] grid)
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
                            placementOption = placementOptions[Helper.RandomInt(0, placementOptions.Length - 1)];
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

        /*==========================================================*
        *  Handle fill remaining empty spaces in grid after words   *
        *===========================================================*/
        private void FillRemainingElements(char[,] grid)
        {
            for (int counterRow = 0; counterRow < grid.GetLength(0); counterRow++)
            {
                for (int counterCol = 0; counterCol < grid.GetLength(1); counterCol++)
                {
                    if (grid[counterRow, counterCol] == '\0')
                    {
                        grid[counterRow, counterCol] = Helper.RandomLetter('a', 'z');
                    }
                }
            }
        }

        /*==================================================================*
        *  Check words have space to fit in different directions, orders    *
        *===================================================================*/
        private bool SpaceRight(string word, GridPosition2D pos, char[,] grid)
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
        private bool SpaceLeft(string word, GridPosition2D pos, char[,] grid)
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
        private bool SpaceDown(string word, GridPosition2D pos, char[,] grid)
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
        private bool SpaceUp(string word, GridPosition2D pos, char[,] grid)
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
        private bool SpaceUpRight(string word, GridPosition2D pos, char[,] grid)
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
        private bool SpaceDownRight(string word, GridPosition2D pos, char[,] grid)
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
        private bool SpaceUpLeft(string word, GridPosition2D pos, char[,] grid)
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
        private bool SpaceDownLeft(string word, GridPosition2D pos, char[,] grid)
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

        /*==================================================*
        *  Word placement for different directions, orders  *
        *===================================================*/
        private void PlaceWordRight(string word, GridPosition2D pos, char[,] grid)
        {
            for (int counter = 0; counter < word.Length; counter++)
            {
                grid[pos.Row, pos.Col + counter] = word[counter];
            }
        } // place word left -> right
        private void PlaceWordLeft(string word, GridPosition2D pos, char[,] grid)
        {
            for (int counter = 0; counter < word.Length; counter++)
            {
                grid[pos.Row, pos.Col - counter] = word[counter];
            }
        } // place word right -> left
        private void PlaceWordDown(string word, GridPosition2D pos, char[,] grid)
        {
            for (int counter = 0; counter < word.Length; counter++)
            {
                grid[pos.Row + counter, pos.Col] = word[counter];
            }
        } // place word up -> down
        private void PlaceWordUp(string word, GridPosition2D pos, char[,] grid)
        {
            for (int counter = 0; counter < word.Length; counter++)
            {
                grid[pos.Row - counter, pos.Col] = word[counter];
            }
        } // place word down -> up
        private void PlaceWordUpRight(string word, GridPosition2D pos, char[,] grid)
        {
            for (int counter = 0; counter < word.Length; counter++)
            {
                grid[pos.Row - counter, pos.Col + counter] = word[counter];
            }
            Console.WriteLine($"Placed {word} diagonally up-right at row {pos.Row}, col {pos.Col}");
        } // place word diagonal left -> up right
        private void PlaceWordDownRight(string word, GridPosition2D pos, char[,] grid)
        {
            for (int counter = 0; counter < word.Length; counter++)
            {
                grid[pos.Row + counter, pos.Col + counter] = word[counter];
            }
            Console.WriteLine($"Placed {word} diagonally down-right at row {pos.Row}, col {pos.Col}");
        } // place word diagonal left -> down right
        private void PlaceWordUpLeft(string word, GridPosition2D pos, char[,] grid)
        {
            for (int counter = 0; counter < word.Length; counter++)
            {
                grid[pos.Row - counter, pos.Col - counter] = word[counter];
            }
            Console.WriteLine($"Placed {word} diagonally up-left at row {pos.Row}, col {pos.Col}");
        } // place word diagonal left -> up left
        private void PlaceWordDownLeft(string word, GridPosition2D pos, char[,] grid)
        {
            for (int counter = 0; counter < word.Length; counter++)
            {
                Console.WriteLine($"D.D.L chec pos {pos.Row + counter},  {pos.Col - counter}");
                grid[pos.Row + counter, pos.Col - counter] = word[counter];
            }
            Console.WriteLine($"Placed {word} diagonally up-left at row {pos.Row}, col {pos.Col}");
        } // place word diagonal left -> down left
    }
}