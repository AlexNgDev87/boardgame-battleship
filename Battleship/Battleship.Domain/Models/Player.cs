using Battleship.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleship.Domain.Models
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
                return Ships.All(x => x.IsSunk);
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
                new Battleship(),
                new Carrier()
            };
            this.GameBoard = new GameBoard();
            this.FiringBoard = new FiringBoard();
        }
    }
}
