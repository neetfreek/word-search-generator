# Word Search Generator
This project is for generating word search grids via an interactive console application. It presents the user with a number of random words from the selected list based on selected game size. 
I'm building a small front-end for this project with MonoGame.


## The Game
- User selects the size of grid; Small (6 words), Medium (12 words), Large (18 words)
- User selects a category of words to find (Instruments, Mammals, Occupations)
- User is presented with the words to find and the word search grid
 - Grid size is relative to the number of words in the words list. 
 - Words randomly placed in the grid diagonally, horizontally and vertically, both backwards and forwards.
- User can choose to regenerate a new word grid of a different size with a different list
 

## To Play
Cone this repository or download it as a zip.
Open it up and build the project as Debug or Release.
Find and execute the `WordSearch.exe` executable file in `WordSearch/bin/Debug` or `WordSearch/bin/Release`


**TODO:**
- <strike>Clean up code in `WordSearch.cs`</strike>
- <strike>Move all console functionality from /Common to FrontEnd.cs</strike>
- <strike>Add functionality for diagonal words</strike>
- <strike>Add functionality for taking words from external data files</strike>
- <strike>Add input-based selection of different word lists</strike>
- <strike>Add game size: S,M,L: take varying amounts of words, randomised, from external data file.</strike>
- <strike>Add a couple lists</strike>
- <strike>Improve console presentation and user input</strike>
