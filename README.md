# boardgame-battleship

## Description ##
This is a Battleship Board Game console app

The project is written in C# and it consists of 3 projects:-
- Battleship
- Battleship.Domain
- Battleship.Services

## Requirement ##
Please make sure that you have .Net Core 2.1 SDK installed in your machine

## How to Use ##
1. Set the **Battleship** project as the Startup 
2. Run the project using Visual Studio 2017 
3. The console will request you to enter the **Name** of both Player 1 and 2 
4. The system will generate the board for each Players
5. The system will also generate a mutual board that will indicate *Hits* and *Miss*
6. The player will fire their shots by entering the coordinate (row number, column number) comma separated
7. Enjoy the Game

## Things to work on ##
- Unit testing for the services
- Create an Interface around the services
- Repository for game saving
- Error logging