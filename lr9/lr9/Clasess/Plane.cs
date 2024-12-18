using System;
using System.Collections.Generic;
using System.Text;

namespace lr9
{
    class Plane : Transport, IMovable
    {
        public override double GetDistance(int speed) => speed * 1.5;
    }
}
