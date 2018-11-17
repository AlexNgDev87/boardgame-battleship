using Battleship.Boards;
using Battleship.Domain.Models;
using System;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            int player1WinCount = 0; 
            int player2WinCount = 0;

            Console.WriteLine("Welcome to Battleship Board Game simulation");
            Console.WriteLine("Please enter Player 1 name: ");
            var firstPlayerName = Console.ReadLine();

            Console.WriteLine("Please enter Player 2 name: ");
            var secondPlayerName = Console.ReadLine();

            Game game1 = new Game(firstPlayerName, secondPlayerName);
            game1.PlayToEnd();

            if (game1.Player1.HasLost)
            {
                player2WinCount++;
            }
            else
            {
                player1WinCount++;
            }

            Console.WriteLine($"{firstPlayerName} Wins: {player1WinCount}");
            Console.WriteLine($"{secondPlayerName} Wins: {player2WinCount}");
            Console.ReadLine();
        }
    }
}
