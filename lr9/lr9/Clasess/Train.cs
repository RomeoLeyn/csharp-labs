using System;
using System.Collections.Generic;
using System.Text;

namespace lr9
{
    class Train : Transport, IMovable
    {
        public override double GetDistance(int speed) => speed * 0.8;
    }
}
