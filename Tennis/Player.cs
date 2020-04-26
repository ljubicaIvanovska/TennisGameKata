using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis
{
    public class Player
    {
        private string _name = "";
        private int _point = 0;
        private int _pointDifference = 0;

        public Player(string name)
        {
            _name = name;
        }
    }
}
