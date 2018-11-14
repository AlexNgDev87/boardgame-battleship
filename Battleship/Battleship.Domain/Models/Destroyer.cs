using Battleship.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Domain.Models
{
    public class Destroyer: BaseShip
    {
        public Destroyer()
        {
            Name = "Destroyer";
            Space = 2;
            PlacementType = PlacementType.Destroyer;
        }
    }
}
