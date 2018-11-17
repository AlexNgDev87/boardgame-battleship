
using Battleship.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Boards
{
    public class Game
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public Game(string firstPlayerName, string secondPlayerName)
        {
            Player1 = new Player(firstPlayerName);
            Player2 = new Player(secondPlayerName);

            Player1.PlaceShips();
            Player2.PlaceShips();

            Player1.OutputBoards();
            Player2.OutputBoards();
        }

        public void PlayRound()
        {
            var coordinate = Player1.FireShot();
            var result = Player2.ProcessShot(coordinate);
            Player1.ProcessShotResult(coordinate, result);

            if (!Player2.HasLost)
            {
                coordinate = Player2.FireShot();
                result = Player1.ProcessShot(coordinate);
                Player2.ProcessShotResult(coordinate, result);
            }
        }

        public void PlayToEnd()
        {
            while (!Player1.HasLost && !Player2.HasLost)
            {
                PlayRound();
            }

            Player1.OutputBoards();
            Player2.OutputBoards();

            if (Player1.HasLost)
            {
                Console.WriteLine($"{Player2.Name} won!");
            }
            else if (Player2.HasLost)
            {
                Console.WriteLine($"{Player1.Name} won!");
            }
        }
    }
}
