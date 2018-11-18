using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Battleship.Domain.Models
{
    public enum PlacementType
    {
        [Description("_")]
        Empty,
        [Description("B")]
        Battleship,
        [Description("C")]
        Cruiser,
        [Description("D")]
        Destroyer,
        [Description("S")]
        Submarine,
        [Description("A")]
        Carrier,
        [Description("X")]
        Hit,
        [Description("M")]
        Miss
    }
}
