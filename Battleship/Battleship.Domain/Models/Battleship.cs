using Battleship.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Domain.Models
{
    public class Battleship: BaseShip
    {
        public Battleship()
        {
            Name = "Battleship";
            Space = 4;
            PlacementType = PlacementType.Battleship;
        }
    }
}
