using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Petrol : Liquid
    {
        private int _octaneNumber;
        public Petrol()
        {

        }

        public int OctaneNumber
        {
            get { return _octaneNumber; }
            set { _octaneNumber = value; }
        }

        public Petrol(string name, int density, double surfaceTension, int octaneNumber) : base(name, density, surfaceTension)
        {
            _octaneNumber = octaneNumber;
        }

        public void ChangeOctaneNumber(int octaneNumber)
        {
            if(octaneNumber <= 0)
            {
                return;
            }
            _octaneNumber = octaneNumber;
            Console.WriteLine("Octane number change");
        }

        public override string ShowInfo()
        {
            return $"{base.ShowInfo()}, \nOctane number {_octaneNumber}";
        }
    }
}
