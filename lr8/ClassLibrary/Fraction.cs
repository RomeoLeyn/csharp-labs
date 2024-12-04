using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Fraction
    {
        private int numerator;   
        private int denominator;

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Denominator cannot be zero.");
            this.numerator = numerator;
            this.denominator = denominator;
            Simplify();
        }

        public Fraction(int wholeNumber) : this(wholeNumber, 1) { } 

        public Fraction() : this(0, 1) { } 

        private void Simplify()
        {
            int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
            numerator /= gcd;
            denominator /= gcd;

            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }
        }

        private static int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        public static Fraction operator +(Fraction f) => f;
        public static Fraction operator -(Fraction f) => new Fraction(-f.numerator, f.denominator);

        public static Fraction operator +(Fraction a, Fraction b)
        {
            return new Fraction(a.numerator * b.denominator + b.numerator * a.denominator,
                                a.denominator * b.denominator);
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            return new Fraction(a.numerator * b.denominator - b.numerator * a.denominator,
                                a.denominator * b.denominator);
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a.numerator * b.numerator, a.denominator * b.denominator);
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.numerator == 0)
                throw new DivideByZeroException("Cannot divide by zero fraction.");
            return new Fraction(a.numerator * b.denominator, a.denominator * b.numerator);
        }

        public static bool operator >(Fraction a, Fraction b) =>
            a.numerator * b.denominator > b.numerator * a.denominator;

        public static bool operator <(Fraction a, Fraction b) =>
            a.numerator * b.denominator < b.numerator * a.denominator;

        public static bool operator >=(Fraction a, Fraction b) => !(a < b);
        public static bool operator <=(Fraction a, Fraction b) => !(a > b);
        public static bool operator ==(Fraction a, Fraction b) =>
            a.numerator * b.denominator == b.numerator * a.denominator;

        public static bool operator !=(Fraction a, Fraction b) => !(a == b);

        public static explicit operator double(Fraction f)
        {
            return (double)f.numerator / f.denominator;
        }

        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Fraction f)
            {
                return numerator * f.denominator == denominator * f.numerator;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(numerator, denominator);
        }
    }
}
