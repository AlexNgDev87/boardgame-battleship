using Battleship.Domain.Models;
using Battleship.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship.Services
{
    public class PanelService
    {
        public List<Panel> _Panels { get; private set; }

        public PanelService(List<Panel> panels)
        {
            this._Panels = panels;
        }

        public List<Coordinate> GetCoordinationsOfOpenPanels()
        {
            return _Panels
                    .Where(x => x.PlacementType == PlacementType.Empty && x.IsRandomAvailable)
                    .Select(x => x.Coordinate)
                    .ToList();
        }

        public List<Coordinate> GetEmptyNeighboursOfLastHit()
        {
            var neighbouringPanels = new List<Panel>();
            var hits = _Panels.Where(x => x.PlacementType == PlacementType.Hit).ToList();
            foreach (var hit in hits)
            {
                neighbouringPanels.AddRange(GetNeighbouringPanelsBasedOnCoordinates(hit.Coordinate).ToList());
            }

            return neighbouringPanels
                    .Distinct()
                    .Where(x => x.PlacementType == PlacementType.Empty)
                    .Select(x => x.Coordinate)
                    .ToList();
        }

        public List<Panel> GetNeighbouringPanelsBasedOnCoordinates(Coordinate coordinate)
        {
            int row = coordinate.Row;
            int column = coordinate.Column;

            List<Panel> neighbouringPanels = new List<Panel>();
            if (column > 1)
            {
                neighbouringPanels.Add(_Panels.At(row, column - 1));
            }
            if (row > 1)
            {
                neighbouringPanels.Add(_Panels.At(row - 1, column));
            }
            if (row < 10)
            {
                neighbouringPanels.Add(_Panels.At(row + 1, column));
            }
            if (column < 10)
            {
                neighbouringPanels.Add(_Panels.At(row, column + 1));
            }
            return _Panels;
        }
    }
}
