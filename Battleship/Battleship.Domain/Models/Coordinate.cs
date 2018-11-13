using System;

namespace Battleship.Domain.Models
{
    public class Coordinate
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Coordinate(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }
    }
}
