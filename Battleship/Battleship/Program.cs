
using Battleship.Domain.Boards;
using Battleship.Domain.Models;
using Battleship.Models;
using System;
using System.Linq;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Battleship Board Game simulation");
            Console.WriteLine("Please enter Player 1 name: ");
            var firstPlayerName = Console.ReadLine();

            Console.WriteLine("Please enter Player 2 name: ");
            var secondPlayerName = Console.ReadLine();

            Game game = new Game(firstPlayerName, secondPlayerName);

            int iteration = 1;
            while (!game.IsEnd)
            {
                var answer = string.Empty;
                var player = iteration % 2 == 1 ? PlayerSequence.Player1 : PlayerSequence.Player2;

                if (player == PlayerSequence.Player1)
                    Console.WriteLine($"{ firstPlayerName }, please enter your coordinates (row, column): ");
                else
                    Console.WriteLine($"{ secondPlayerName }, please enter your coordinates (row, column): ");

                answer = Console.ReadLine();

                var answers = answer.Split(',');
                var coordinates = new Coordinate(
                        int.Parse(answers[0].ToString()), 
                        int.Parse(answers[1].ToString()));


                game.PlayRound(player, coordinates);
                iteration++;
            }

            if (game.Player1.HasLost)
                Console.WriteLine($"{secondPlayerName} Won!");
            else
                Console.WriteLine($"{firstPlayerName} Won!");

            Console.ReadLine();
        }
    }
}
