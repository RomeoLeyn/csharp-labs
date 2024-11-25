using System;
using System.Collections.Generic;

namespace lr6
{
    class Program
    {
        static List<Airplane> airplaneLists = new List<Airplane>();
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("\nLibrary Menu:");
                Console.WriteLine("1. Add new airplane");
                Console.WriteLine("2. View all airplane");
                Console.WriteLine("3. Summary time");
                Console.WriteLine("4. Arrival day");
                Console.WriteLine("5. Exit");

                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();
                switch (choice) {
                    case "1":
                        AddNewAirplane();
                        break;
                    case "2":
                        ViewAllAirplane();
                        break;
                    case "3":
                        CalculateSummaryTime();
                        break;
                    case "4":
                        CheckArrivalDay();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        static void AddNewAirplane()
        {
            Console.Write("Departure city: ");
            string derpatureCity = Console.ReadLine();

            Console.Write("Arrival city: ");
            string arrivalCity = Console.ReadLine();

            Console.Write("Enter year: ");
            int departureYear = int.Parse(Console.ReadLine());

            Console.Write("Enter month: ");
            string departureMonth = Console.ReadLine();

            Console.Write("Enter day: ");
            string departureDay = Console.ReadLine();

            Console.Write("Enter hours: ");
            int departureHours = int.Parse(Console.ReadLine());

            Console.Write("Enter minutes: ");
            int departureMinutes = int.Parse(Console.ReadLine());

            Date departureDate = new Date(departureYear, departureMonth, departureDay, departureHours, departureMinutes);


            Console.WriteLine("Enter year");
            int arrivalYear = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter month");
            string arrivalMonth = Console.ReadLine();

            Console.WriteLine("Enter day");
            string arrivalDay = Console.ReadLine();

            Console.WriteLine("Enter hours");
            int arrivalHours = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter minutes");
            int arrivalMinutes = int.Parse(Console.ReadLine());

            Date arrivalDate = new Date(arrivalYear, arrivalMonth, arrivalDay, arrivalHours, arrivalMinutes);

            Airplane airplane = new Airplane(derpatureCity, arrivalCity, departureDate, arrivalDate);

            airplaneLists.Add(airplane);
        }

        static void ViewAllAirplane()
        {
            foreach(var airplane in airplaneLists)
            {
                Console.WriteLine(airplane);
            }
        }

        static void CalculateSummaryTime()
        {
            Console.Write("Enter departure city: ");
            string depCity = Console.ReadLine();

            Console.Write("Enter arrival city: ");
            string arrCity = Console.ReadLine();

            Console.Write("Enter departure hour: ");
            int depHour = int.Parse(Console.ReadLine());

            foreach (var airplane in airplaneLists)
            {
                if (airplane.DepartureCityProperty.Equals(depCity, StringComparison.OrdinalIgnoreCase) &&
                    airplane.ArrivalCityProperty.Equals(arrCity, StringComparison.OrdinalIgnoreCase) &&
                    airplane.DepartureDateProperty.Hours == depHour)
                {
                    int totalTime = airplane.GetTotalTime();
                    Console.WriteLine($"Total travel time: {totalTime} minutes");
                    return;
                }
            }

            Console.WriteLine("No matching airplane found.");
        }

        static void CheckArrivalDay()
        {
            Console.Write("Enter departure city: ");
            string depCity = Console.ReadLine();

            Console.Write("Enter arrival city: ");
            string arrCity = Console.ReadLine();

            Console.Write("Enter departure hour: ");
            int depHour = int.Parse(Console.ReadLine());

            foreach (var airplane in airplaneLists)
            {
                if (airplane.DepartureCityProperty.Equals(depCity, StringComparison.OrdinalIgnoreCase) &&
                    airplane.ArrivalCityProperty.Equals(arrCity, StringComparison.OrdinalIgnoreCase) &&
                    airplane.DepartureDateProperty.Hours == depHour)
                {
                    bool isArrivingToday = airplane.IsArrivingToday();
                    Console.WriteLine(isArrivingToday
                        ? "The airplane arrives on the same day."
                        : "The airplane arrives on a different day.");
                    return;
                }
            }

            Console.WriteLine("No matching airplane found.");
        }
    }

    class Airplane
    {
        private string DepartureCity;
        private string ArrivalCity;
        private Date DepartureDate;
        private Date ArrivalDate;

        public Airplane()
        {

        }

        public Airplane(string departureCity, string arrivalCity, Date departureDate, Date arrivalDate)
        {
            DepartureCity = departureCity;
            ArrivalCity = arrivalCity;
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
        }

        private int ConvertToMinutes(int hours, int additionalMinutes)
        {
            return (hours * 60) + additionalMinutes;
        }

        public int GetTotalTime()
        {
            int hours = ArrivalDate.Hours - DepartureDate.Hours;
            int minutes = DepartureDate.Minutes - ArrivalDate.Minutes;

            if (minutes < 0)
            {
                hours--;
                minutes += 60;
            }

            return ConvertToMinutes(hours, minutes);
        }

        public bool IsArrivingToday()
        {
           return DepartureDate.Day == ArrivalDate.Day &&
           DepartureDate.Month == ArrivalDate.Month &&
           DepartureDate.Year == ArrivalDate.Year;
        }

        public string DepartureCityProperty
        {
            get { return DepartureCity; }
            set { DepartureCity = value; }
        }

        public string ArrivalCityProperty
        {
            get { return ArrivalCity; }
            set { ArrivalCity = value; }
        }

        public Date DepartureDateProperty
        {
            get { return DepartureDate; }
            set { DepartureDate = value; }
        }

        public Date ArrivalDateProperty
        {
            get { return ArrivalDate; }
            set { ArrivalDate = value; }
        }

        public override string ToString()
        {
            return $"Виліт із міста: {DepartureCity}, о {DepartureDate}\n" +
                   $"Приліт у місто: {ArrivalCity}, о {ArrivalDate}";
        }

    }

    class Date
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
            set{ _hours = value; }
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
