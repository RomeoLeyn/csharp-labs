using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Alcohol : Liquid
    {
        private double _strength;

        public Alcohol()
        {

        }

        public Alcohol(string name, int density, double surfaceTension, double strength) : base(name, density, surfaceTension)
        {
            _strength = strength;
        }

        public double Strength
        {
            get { return _strength; }
            set { _strength = value; }
        }

        public void ChangeStrength(double newStrength)
        {
            if(newStrength <= 0)
            {
                return;
            }

            _strength = newStrength;
            Console.WriteLine("Value change");
        }

        public override string ShowInfo()
        {
            return $"{base.ShowInfo()}, \nStrength: {_strength}";
        }
    }
}
