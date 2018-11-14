using Battleship.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Domain.Models
{
    public class Carrier: BaseShip
    {
        public Carrier()
        {
            Name = "Carrier";
            Space = 5;
            PlacementType = PlacementType.Carrier;
        }
    }
}
