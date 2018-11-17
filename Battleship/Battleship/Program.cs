using Battleship.Boards;
using Battleship.Domain.Models;
using System;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            int player1Wins = 0, player2Wins = 0;

            Console.WriteLine("How many games do you want to play?");
            var numGames = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter Player 1 name: ");
            var firstPlayerName = Console.ReadLine();

            Console.WriteLine("Please enter Player 2 name: ");
            var secondPlayerName = Console.ReadLine();

            for (int i = 0; i < numGames; i++)
            {
                Game game1 = new Game(firstPlayerName, secondPlayerName);
                game1.PlayToEnd();

                if (game1.Player1.HasLost)
                {
                    player2Wins++;
                }
                else
                {
                    player1Wins++;
                }
            }

            Console.WriteLine("Player 1 Wins: " + player1Wins.ToString());
            Console.WriteLine("Player 2 Wins: " + player2Wins.ToString());
            Console.ReadLine();
        }
    }
}
