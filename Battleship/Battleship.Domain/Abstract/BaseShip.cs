using Battleship.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Domain.Abstract
{
    public abstract class BaseShip
    {
        public string Name { get; set; }
        public int Space { get; set; }
        public int Hits { get; set; }
        public PlacementType PlacementType { get; set; }
        public bool IsSunk
        {
            get {
                return Hits >= Space;
            }
        }
    }
}
