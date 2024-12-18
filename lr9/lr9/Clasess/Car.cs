using System;
using System.Collections.Generic;
using System.Text;

namespace lr9
{
    public class Car : Transport, IMovable
    {
        public override double GetDistance(int speed) => speed * 0.5;
    }
}
