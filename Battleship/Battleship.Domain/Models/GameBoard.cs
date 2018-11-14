﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Domain.Models
{
    public class GameBoard
    {
        public List<Panel> Panels { get; set; }

        public GameBoard()
        {
            this.Panels = new List<Panel>();
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Panels.Add(new Panel(i, j));
                }
            }
        }
    }
}
