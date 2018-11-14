
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Domain.Models
{
    public class Game
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public Game()
        {

        }

        public void PlayRound()
        {
            throw new NotImplementedException();
        }

        public void PlayToEnd()
        {
            throw new NotImplementedException();
        }
    }
}
