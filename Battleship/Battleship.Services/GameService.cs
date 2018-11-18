using Battleship.Domain.Abstract;
using Battleship.Domain.Boards;
using Battleship.Domain.Models;
using Battleship.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleship.Services
{
    public class GameService
    {
        public ShotResult ProcessShot(string name, List<BaseShip> ships, GameBoard board, Coordinate coord)
        {
            var panel = board.Panels.At(coord.Row, coord.Column);

            if (!panel.IsOccupied)
            {
                Console.WriteLine($"{name} says: \"Miss!\"");
                return ShotResult.Miss;
            }

            var ship = ships.First(x => x.PlacementType == panel.PlacementType);

            ship.Hits++;

            Console.WriteLine($"{name} says: \"Hit!\"");

            if (ship.IsSunk)
                Console.WriteLine($"{name} says: \"You sunk my {ship.Name}!\"");

            return ShotResult.Hit;
        }
    }
}
