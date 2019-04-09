# Word Search Generator
This project is for generating word search grids. It loads lists of words to find from `DataWords.xml`
I plan on building a small front-end for this project, maybe with Unity. For now, it's console time!

## The Game
A grid is generating with a size relative to the number of words in the words list. 
Words are randomly placed in the grid horizontally and vertically, backwards and forwards.

## To Play
Cone this repository or download it as a zip.
Open it up and build the project as Debug or Release.
Find the `WordSearch.exe` executable file in `WordSearch/bin/Debug` or `WordSearch/bin/Release` (if none exist, build the solution as either Debug or Release)


**TODO:**
- Clean up code in `WordSearch.cs`
- <strike>Move all console functionality from /Common to FrontEnd.cs</strike>
- <strike>Add functionality for diagonal words</strike>
- <strike>Add functionality for taking words from external data files</strike>
- <strike>Add input-based selection of different word lists</strike>
- Add game size: S,M,L: take varying amounts of words, randomised, from external data file.
- Add a couple lists
- Improve console presentation and user input
