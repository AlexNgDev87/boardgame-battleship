﻿using Battleship.Domain.Abstract;
using Battleship.Domain.Boards;
using Battleship.Domain.Models;
using Battleship.Domain.Utilities;
using Battleship.Models;
using Battleship.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleship.Models
{
    public class Player
    {
        public string Name { get; set; }
        public GameBoard GameBoard { get; set; }
        public FiringBoard FiringBoard { get; set; }
        public List<BaseShip> Ships { get; set; }
        public bool HasLost
        {
            get {
                return this.Ships.All(x => x.IsSunk);
            }
        }

        public Player(string name)
        {
            this.Name = name;
            this.Ships = new List<BaseShip>()
            {
                new Destroyer(),
                new Submarine(),
                new Cruiser(),
                new Domain.Models.Battleship(),
                new Carrier()
            };
            this.GameBoard = new GameBoard();
            this.FiringBoard = new FiringBoard();
        }

        public Coordinate FireShot()
        {
            //If there are hits on the board with neighbours which don't have shots, we should fire at those first.
            var hitNeighbours = this.FiringBoard.GetHitNeighbours();
            Coordinate coord;

            if (hitNeighbours.Any())
            {
                coord = SearchingShot();
            }
            else
            {
                coord = RandomShot();
            }
            Console.WriteLine($"{Name} says: \"Firing shot at {coord.Row.ToString()}, {coord.Column.ToString()}\"");
            return coord;
        }

        public ShotResult ProcessShot(string playerName, Coordinate coord)
        {
            var gameService = new GameService();
            var result = gameService.ProcessShot(playerName, Ships, GameBoard, coord);

            return result;
        }

        public void ProcessShotResult(Coordinate coord, ShotResult result)
        {
            var panel = this.FiringBoard.Panels.At(coord.Row, coord.Column);
            switch (result)
            {
                case ShotResult.Hit:
                    panel.PlacementType = PlacementType.Hit;
                    break;

                default:
                    panel.PlacementType = PlacementType.Miss;
                    break;
            }
        }

        // fire our semi-random shots
        private Coordinate RandomShot()
        {
            var availablePanels = this.FiringBoard.GetOpenRandomPanels();

            Random rand = new Random(Guid.NewGuid().GetHashCode());
            var panelId = rand.Next(availablePanels.Count);

            return availablePanels[panelId];
        }

        // fires at nearby panels from the last hit
        private Coordinate SearchingShot()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());

            var hitNeighbours = this.FiringBoard.GetHitNeighbours();
            var neighbourId = rand.Next(hitNeighbours.Count);

            return hitNeighbours[neighbourId];
        }

        public void PlaceShips()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            foreach (var ship in Ships)
            {
                // Select a random row/column combination, then select a random orientation.
                // If none of the proposed panels are occupied, place the ship
                bool isOpen = true;
                while (isOpen)
                {
                    var startcolumn = rand.Next(1, 11);
                    var startrow = rand.Next(1, 11);
                    int endrow = startrow;
                    int endcolumn = startcolumn;
                    var orientation = rand.Next(1, 101) % 2; //0 for Horizontal

                    List<int> panelNumbers = new List<int>();
                    if (orientation == 0)
                    {
                        for (int i = 1; i <= ship.Space; i++)
                            endrow++;
                    }
                    else
                    {
                        for (int i = 1; i <= ship.Space; i++)
                            endcolumn++;
                    }

                    if (endrow > 10 || endcolumn > 10)
                    {
                        isOpen = true;
                        continue; //Restart the while loop to select a new random panel
                    }

                    //Check if specified panels are occupied
                    var affectedPanels = this.GameBoard.Panels.Range(startrow, startcolumn, endrow, endcolumn);
                    if (affectedPanels.Any(x => x.IsOccupied))
                    {
                        isOpen = true;
                        continue;
                    }

                    foreach (var panel in affectedPanels)
                    {
                        panel.PlacementType = ship.PlacementType;
                    }
                    isOpen = false;
                }
            }
        }

        // Display where the player has placed their ships
        public void OutputBoards()
        {
            Console.WriteLine(this.Name);
            Console.WriteLine("Own Board:                          Firing Board:");
            for (int row = 1; row <= 10; row++)
            {
                for (int ownColumn = 1; ownColumn <= 10; ownColumn++)
                {
                    Console.Write($"{this.GameBoard.Panels.At(row, ownColumn).Status} ");
                }
                Console.Write("                ");
                for (int firingColumn = 1; firingColumn <= 10; firingColumn++)
                {
                    Console.Write($"{this.FiringBoard.Panels.At(row, firingColumn).Status} ");
                }
                Console.WriteLine(Environment.NewLine);
            }
            Console.WriteLine(Environment.NewLine);
        }
    }
}
