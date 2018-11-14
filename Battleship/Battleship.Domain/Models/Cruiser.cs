using Battleship.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Domain.Models
{
    public class Cruiser : BaseShip
    {
        public Cruiser()
        {
            Name = "Cruiser";
            Space = 3;
            PlacementType = PlacementType.Cruiser;
        }
    }
}
