using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis
{
    public class Player
    {
        public string Name = "";
        public int Score = 0;
        private int _pointDifference = 0;

        public Player(string name)
        {
            Name = name;
        }
        public void WonPoint()
        {
            Score++;
        }
    }
}
