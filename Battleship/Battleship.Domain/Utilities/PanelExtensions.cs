using Battleship.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleship.Domain.Utilities
{
    public static class PanelExtensions
    {
        public static List<Panel> Range(this List<Panel> panels, int startRow, int startColumn, int endRow, int endColumn)
        {
            return panels
                    .Where(x => x.Coordinate.Row >= startRow
                            && x.Coordinate.Column >= startColumn
                            && x.Coordinate.Row <= endRow
                            && x.Coordinate.Column <= endColumn)
                    .ToList();
        }

        public static Panel At(this List<Panel> panels, int row, int column)
        {
            return panels
                    .Where(x => x.Coordinate.Row == row && x.Coordinate.Column == column)
                    .Select(x => x)
                    .FirstOrDefault();
        }
    }
}
