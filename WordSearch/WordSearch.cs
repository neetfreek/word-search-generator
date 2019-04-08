using System;

namespace WordSearch
{
    public static class WordSearch
    {
        public static void StartWordSearch()
        {

            Setup();
        }

        // SETUP METHODS
        private static void Setup()
        {
            string[] words = CreateVectorWords();
            FrontEnd.PrintWords(words);

            int numCharsInWords = Vectors.CountLettersVector(words);
            int lengthLongestWord = Vectors.LongestWordVector(words).Length;
            int numGridRowsCols = NumberGridRowsCols(numCharsInWords, lengthLongestWord);
            char[,] grid = CreatGrid(numGridRowsCols);
            PopulateGridWords(words, grid);
            FillRemainingElements(grid);

            FrontEnd.PrintGrid(grid);
        }

        private static string[] CreateVectorWords()
        {
            string[] wordsInput = new string[] {"chicken", "frog", "cat", "dog", "goat", "moose", "lion", "dolphon", "lemur", "antelope"};
            string[] words = Vectors.CaptitaliseAll(wordsInput);

            return words;
        }
        private static int NumberGridRowsCols(int numCharsInWords, int lengthLongestWord)
        {
            // minimum grid dimensions to fit longest wordCurrent
            int sizeMinGrid = lengthLongestWord * lengthLongestWord;

            // add extra grid elements to ensure enough space for non-wordCurrent characters
            int totalElementsGrid = numCharsInWords * 3;

            int totalElementsGridSquare = (int)Math.Sqrt(totalElementsGrid);

            // increase current number of grid elements until reaches next root of square (e.g. 5, 6, 7)
            while (Math.Sqrt(sizeMinGrid) != totalElementsGridSquare+1)
            {
                sizeMinGrid ++;
            }

            // get number of rows/cols
            int numRowsCols = (int)Math.Sqrt(sizeMinGrid);

            // optionally add some random rows
            //Random random = new Random();
            //int extraRows = random.Next(0,3);
            //numRowsCols += extraRows;

            return numRowsCols;
        }
        private static char[,] CreatGrid(int numGridElements)
        {
            // empty grid
            char[,] grid = new char[numGridElements, numGridElements];

            // test grid (to see size)
            //char[,] grid = Matrices.MatrixRandom(numGridElements, numGridElements, 'a', 'z');
            return grid;
        }
                
        // POPULATE METHODS
        private static void PopulateGridWords(string[] words, char[,] grid)
        {
            bool wordPlaced = false;
            int numberWordsToPlace = Vectors.CountElementsVector(words);

            // iterate words to place
            for (int wordCurrent = 0; wordCurrent < numberWordsToPlace; wordCurrent++)
            {
                wordPlaced = false;
                while (!wordPlaced)
                {
                    // Get random starting point for word
                    Tuple<int, int> point = Matrices.RandomPointMatrix(grid);

                    if (PlaceWordInGrid(point, words[wordCurrent], grid))
                    {
                        wordPlaced = true;
                    }
                }
            }

            // fill remaining empty elements with random letters

        }        
        // check space for wordCurrent from position
        private static bool PlaceWordInGrid(Tuple<int, int> point, string word, char[,] grid)
        {
            int x = point.Item1;
            int y = point.Item2;

            // elements represent placements options, 0 == left->right, 1 = right->left, etc. (in order presented below)
            int[] placementOptions = new int[4] { 9, 9, 9, 9 };
            int placementOption = 9;
            bool haveOptions = false;

            for (int counter = 0; counter < word.Length; counter++)
            {
                // If point empty or point contains same letter word's current character
                if (grid[x, y] == '\0' | grid[x, y] == word[0])
                {
                    if (SpaceRight(word, point, grid))
                    {
                        placementOptions[0] = 1;
                        haveOptions = true;
                    }
                    if (SpaceLeft(word, point, grid))
                    {
                        placementOptions[1] = 2;
                        haveOptions = true;                    
                    }
                    if (SpaceUp(word, point, grid))
                    {
                        placementOptions[2] = 3;
                        haveOptions = true;                    
                    }
                    if (SpaceDown(word, point, grid))
                    {
                        placementOptions[3] = 4;
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
                                PlaceWordRight(word, point, grid);
                                break;                                     
                            case 2:                                        
                                PlaceWordLeft(word, point, grid);          
                                break;                                    
                            case 3:                                       
                                PlaceWordUp(word, point, grid);           
                                break;                                    
                            case 4:                                       
                                PlaceWordDown(word, point, grid);         
                                break;
                        }
                        return true;
                    }

                }                
            }
            return false;
        }
        // fill remaining empty elements
        private static void FillRemainingElements(char[,] grid)
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


        // CHECK SPACE METHODS

        // Return space to fit word right -> left
        private static bool SpaceLeft(string word, Tuple<int, int> point, char[,] grid)
        {
            int y = point.Item1;
            int x = point.Item2;

            if (y >= word.Length - 1)
            {
                // iterate left in row, checking each successive element empty or same as current char
                for (int counter = 0; counter < word.Length; counter++)
                {
                    if (grid[x, y - counter] != '\0' && grid[x, y - counter] != word[counter])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        // Return space to fit word left -> right
        private static bool SpaceRight(string word, Tuple<int, int> point, char[,] grid)
        {
            int y = point.Item1; // row point
            int x = point.Item2; // column point

            if ((grid.GetLength(0)) - y >= word.Length)
            {
                // iterate right in row, checking each successive element empty or same as current char
                for (int counter = 0; counter < word.Length; counter++)
                {
                    if (grid[x, y + counter] != '\0' && grid[x, y + counter] != word[counter])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        // Return space to fit word up -> down
        private static bool SpaceDown(string word, Tuple<int, int> point, char[,] grid)
        {
            int y = point.Item1;
            int x = point.Item2;

            if ((grid.GetLength(0)) - x >= word.Length)
            {
                // iterate right in row, checking each successive element empty or same as current char
                for (int counter = 0; counter < word.Length; counter++)
                {
                    if (grid[x + counter, y] != '\0' && grid[x + counter, y] != word[counter])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        // Return space to fit word down -> up
        private static bool SpaceUp(string word, Tuple<int, int> point, char[,] grid)
        {
            int y = point.Item1;
            int x = point.Item2;

            if (x >= word.Length - 1)
            {
                // iterate left in row, checking each successive element empty or same as current char
                for (int counter = 0; counter < word.Length; counter++)
                {
                    if (grid[x - counter, y] != '\0' && grid[x - counter, y] != word[counter])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        // WORD PLACE METHODS
        private static void PlaceWordLeft(string word, Tuple<int, int> point, char[,] grid)
        {
            int y = point.Item1;
            int x = point.Item2;

            for (int counter = 0; counter < word.Length; counter++)
            {
                grid[x , y - counter] = word[counter];
            }
        }
        private static void PlaceWordRight(string word, Tuple<int, int> point, char[,] grid)
        {
            int y = point.Item1;
            int x = point.Item2;

            for (int counter = 0; counter < word.Length; counter++)
            {
                grid[x, y + counter] = word[counter];
            }
        }
        private static void PlaceWordDown(string word, Tuple<int, int> point, char[,] grid)
        {
            int y = point.Item1;
            int x = point.Item2;

            for (int counter = 0; counter < word.Length; counter++)
            {
                grid[x + counter, y] = word[counter];
            }
        }
        private static void PlaceWordUp(string word, Tuple<int, int> point, char[,] grid)
        {
            int y = point.Item1;
            int x = point.Item2;

            for (int counter = 0; counter < word.Length; counter++)
            {
                grid[x - counter, y] = word[counter];
            }
        }
    }
}