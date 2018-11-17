using Battleship.Domain.Models;
using Battleship.Domain.Utilities;
using Battleship.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleship.Boards
{
    // this board tracks each players shots and whether they were hits or misses
    public class FiringBoard : GameBoard
    {
        // return a list of panels that no shots has been fired
        public List<Coordinate> GetOpenRandomPanels()
        {
            var coordinates = new List<Coordinate>();
            var panelService = new PanelService(base.Panels);

            coordinates.AddRange(panelService.GetCoordinationsOfOpenPanels());
            return coordinates;
        }

        public List<Coordinate> GetHitNeighbours()
        {
            List<Coordinate> coordinates = new List<Coordinate>();

            var panelService = new PanelService(base.Panels);
            coordinates.AddRange(panelService.GetEmptyNeighboursOfLastHit());

            // return the coordinate of the empty panel
            return coordinates;
        }
    }
}
