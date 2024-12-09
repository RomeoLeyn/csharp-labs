using System;
using System.Collections.Generic;
using System.Text;

namespace lr9
{
    public abstract class Transport : IMovable
    {
        public abstract double GetDistance(int speed);
    }
}
