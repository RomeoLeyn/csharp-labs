using System;

namespace SimpleClassLibrary
{
    public class Airplane
    {
        private string DepartureCity;
        private string ArrivalCity;
        private Date DepartureDate;
        private Date ArrivalDate;
        private double DistanceInKilometers;
        private double DistanceInMiles;
        private double DistanceInMeters;

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

        public void addFlightDistance()
        {
            Console.WriteLine("Select unit for flight distance:");
            Console.WriteLine("1. Kilometers");
            Console.WriteLine("2. Meters");
            Console.WriteLine("3. Miles");

            int choice = int.Parse(Console.ReadLine());

            Console.Write("Enter flight distance: ");
            double distance = double.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DistanceInKilometers = distance;
                    DistanceInMeters = distance * 1000;
                    DistanceInMiles = distance * 0.621371;
                    break;
                case 2:
                    DistanceInMeters = distance;
                    DistanceInKilometers = distance / 1000;
                    DistanceInMiles = distance * 0.000621371;
                    break;
                case 3:
                    DistanceInMiles = distance;
                    DistanceInKilometers = distance / 0.621371;
                    DistanceInMeters = distance / 0.000621371;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please enter a valid option.");
                    break;
            }
        }

        public void DisplayFlightDistance()
        {
            Console.WriteLine($"Flight distance in Kilometers: {DistanceInKilometers} km");
            Console.WriteLine($"Flight distance in Meters: {DistanceInMeters} m");
            Console.WriteLine($"Flight distance in Miles: {DistanceInMiles} mi");
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
}
