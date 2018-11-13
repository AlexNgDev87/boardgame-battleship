using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Battleship.Domain.Models
{
    public class Panel
    {
        public PlacementType PlacementType { get; set; }
        public Coordinate Coordinate { get; set; }

        public Panel(int row, int column)
        {
            this.Coordinate = new Coordinate(row, column);
            this.PlacementType = PlacementType.Empty;
        }

        public string Status
        {
            get {
                return Extensions.GetDescription<PlacementType>(this.PlacementType);
            }
        }

        public bool IsOccupied {
            get {
                return this.PlacementType == PlacementType.Battleship
                    || this.PlacementType == PlacementType.Carrier
                    || this.PlacementType == PlacementType.Cruiser
                    || this.PlacementType == PlacementType.Destroyer
                    || this.PlacementType == PlacementType.Submarine;
            }
        }

        // do we need this ??
        public bool IsRandomAvailable
        {
            get
            {
                return (this.Coordinate.Row % 2 == 0 && this.Coordinate.Column % 2 == 0)
                    || (this.Coordinate.Row % 2 == 1 && this.Coordinate.Column % 2 == 1);
            }
        }
    }
}
