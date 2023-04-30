# Game Of Life Kata
---

[Link to the Kata Docs](https://github.com/MYOB-Technology/General_Developer/blob/main/katas/kata-conways-game-of-life/kata-conways-game-of-life.md)

### Author: Ajay Basra
A some what large-scale kata which overall was fun to implement and think about. At the start there was a lot of planning required to have a rough representation of what the project could look like, this was done via creation of an UML diagram. As the project progressed, I found myself refactoring and deviating away from the UML diagram which is only natural as some times issues aren't visible when viewing from a higher-level.
## Room for improvement:
    - Have multiple games running at once
    - Make the output more visually appealing
    - Read in initial board state from a .txt file or similar
### Requirements 🔧
* [Download .NET 7.0](https://dotnet.microsoft.com/en-us/download/dotnet/7.0).

### Installation & Running 🔌
1. Clone the repo or download as zip file.
2. Before running the program you need to setup the command line arguments. This program takes either 3 or 4 arguments depending on which game version you choose. For example, 3 25 5 25 would setup a 3-D game with 25 aisles, 5 rows and 25 columns. The first argument specifies the number of dimensions and subsequent arguments specify the size of the dimensions. Whilst 2/3 and represent 2-D and 3-D respectively, using any other number creates a 2-D game without grid wraparound.
3. Navigate into the project directory.
4. Run the following command: `dotnet run`.