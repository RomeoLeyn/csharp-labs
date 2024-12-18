using System;

namespace ClassLibrary
{
    public class Liquid
    {
        private string _name;
        private int _density;
        private double _surfaceTension;

        public Liquid()
        {

        }

        public Liquid(string name, int density, double surfaceTension)
        {
            _name = name;
            _density = density;
            _surfaceTension = surfaceTension;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Denstiny
        {
            get { return _density; }
            set { _density = value;  }
        }

        public double SurfaceTension
        {
            get { return _surfaceTension; }
            set { _surfaceTension = value; }
        }


        public void ChangeDesinty(int density)
        {
            if (density <= 0)
            {
                Console.WriteLine("Destiny negative");
                return;
            }

            _density = density;

            Console.WriteLine("Destiny change");
            return;
        }

        public void ChangeSurfaceTension(double surfaceTension)
        {
            if (surfaceTension <= 0)
            {
                Console.WriteLine("surfaceTension negative");
                return;
            }

            _surfaceTension = surfaceTension;

            Console.WriteLine("surfaceTension change");
        }

        public virtual string ShowInfo()
        {
            return $"Name: {_name}, \nDensity: {_density}, \nSurface tension: {_surfaceTension}";
        }
    }
}
