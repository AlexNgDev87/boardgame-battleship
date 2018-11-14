using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Domain.Models
{
    public class FiringBoard : GameBoard
    {
        public List<Coordinate> GetOpenRandomPanels()
        {
            throw new NotImplementedException();
        }

        public List<Coordinate> GetHitNeighbors()
        {
            throw new NotImplementedException();
        }

        public List<Panel> GetNeighbors(Coordinate coordinates)
        {
            throw new NotImplementedException();
        }
    }
}
