using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleClassLibrary
{
    public class Date
    {
        private int _year;
        private string _month;
        private string _day;
        private int _hours;
        private int _minutes;

        public Date()
        {

        }

        public Date(int year, string month, string day, int hours, int minutes)
        {
            _year = year;
            _month = month;
            _day = day;
            _hours = hours;
            _minutes = minutes;
        }

        public int Hours
        {
            get { return _hours; }
            set { _hours = value; }
        }

        public int Minutes
        {
            get { return _minutes; }
            set { _minutes = value; }
        }

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public string Month
        {
            get { return _month; }
            set { _month = value; }
        }

        public string Day
        {
            get { return _day; }
            set { _day = value; }
        }

        public override string ToString()
        {
            return $"{Day} {Month} {Year}, {Hours:D2}:{Minutes:D2}";
        }

    }
}
