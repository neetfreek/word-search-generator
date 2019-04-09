# Word Search Generator
This project is for generating word search grids. It currently uses words hard-coded into `WordSearch.cs`.
Files in `WordSearch/Common` are taken from my `AlgorithmsCSharp` project
I plan on building a small front-end for this project, maybe with Unity.

## The Game
A grid is generating with a size relative to the number of words in the words list. 
Words are randomly placed in the grid horizontally and vertically, backwards and forwards.

## To Play
Cone this repository or download it as a zip.
Open it up and build the project as Debug or Release.
Find the `WordSearch.exe` executable file in `WordSearch/bin/Debug` or `WordSearch/bin/Release`


**TODO:**
- Clean up code in `WordSearch.cs`
- Move all console functionality from /Common to FrontEnd.cs
- <strike>Add functionality for diagonal words</strike>
- Add functionality for taking words from external data files
- Add input-based selection of different word lists
