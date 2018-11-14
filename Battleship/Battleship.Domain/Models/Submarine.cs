using Battleship.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Domain.Models
{
    public class Submarine: BaseShip
    {
        public Submarine()
        {
            Name = "Submarine";
            Space = 3;
            PlacementType = PlacementType.Submarine;
        }
    }
}
