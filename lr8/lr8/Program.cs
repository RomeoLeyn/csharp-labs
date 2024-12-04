using System;
using System.Collections.Generic;
using ClassLibrary;

namespace lr8
{
    class Program
    {
        static List<Petrol> petrolLists = new List<Petrol>();
        static List<Alcohol> alcoholLists = new List<Alcohol>();
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("\n --- Menu --- ");
                Console.WriteLine("1. Add new petrol");
                Console.WriteLine("2. Change octane number in petrol");
                Console.WriteLine("3. Show all info about petrol");
                Console.WriteLine("\n4. Add new alcohol");
                Console.WriteLine("5. Change strength in alcohol");
                Console.WriteLine("6. Show all info about alcohol");
                Console.WriteLine("\n7. Fraction menu");
                Console.WriteLine("8. Exit");

                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddNewPetrol();
                        break;

                    case "2":

                        Console.Write("Enter name = ");
                        Petrol resultByName = SearchPetrolByName(Console.ReadLine());

                        Console.WriteLine("\n" + resultByName.ShowInfo() + "\n");

                        Console.Write("Enter octane number = ");
                        resultByName.OctaneNumber = int.Parse(Console.ReadLine());

                        Console.WriteLine("\nAfter update \n" + resultByName.ShowInfo() + "\n");
                        break;

                    case "3":
                        ShowAllInfoAboutPetrol();
                        break;

                    case "4":
                        AddNewAlcohol();
                        break;

                    case "5":

                        Console.Write("Enter name = ");
                        Alcohol alcoholByName = SearchAlcoholByName(Console.ReadLine()); 

                        Console.WriteLine("\n" + alcoholByName.ShowInfo() + "\n");

                        Console.Write("Enter strength number = ");
                        alcoholByName.Strength = int.Parse(Console.ReadLine());

                        Console.WriteLine("\nAfter update \n" + alcoholByName.ShowInfo() + "\n");
                        
                        break;
                            
                    case "6":
                        ShowAllInfoAboutAlcohol();
                        break;
                    case "7":
                        FractionMenu();
                        break;

                    case "8":
                        return;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        static void AddNewPetrol()
        {
            Console.Write("Enter name = ");
            string name = Console.ReadLine();

            Console.Write("Enter density = ");
            int density = int.Parse(Console.ReadLine());

            Console.Write("Enter surface tension = ");
            double surfaceTension = Double.Parse(Console.ReadLine());

            Console.Write("Enter octane number = ");
            int octaneNumber = int.Parse(Console.ReadLine());

            Petrol petrol = new Petrol(name, density, surfaceTension, octaneNumber);

            petrolLists.Add(petrol);
        }

        static void AddNewAlcohol()
        {
            Console.Write("Enter name = ");
            string name = Console.ReadLine();

            Console.Write("Enter density = ");
            int density = int.Parse(Console.ReadLine());

            Console.Write("Enter surface tension = ");
            double surfaceTension = Double.Parse(Console.ReadLine());

            Console.Write("Enter strength number = ");
            int strength = int.Parse(Console.ReadLine());

            Alcohol alcohol = new Alcohol(name, density, surfaceTension, strength);

            alcoholLists.Add(alcohol);
        }

        static Petrol SearchPetrolByName(string name)
        {
            return petrolLists.Find(p => p.Name == name);

        }   

        static Alcohol SearchAlcoholByName(string name)
        {
            return alcoholLists.Find(a => a.Name == name);
        }

        static void ShowAllInfoAboutPetrol()
        {
            foreach (Petrol p in petrolLists)
            {
                Console.WriteLine("\n" + p.ShowInfo() + "\n");
            }
        }

        static void ShowAllInfoAboutAlcohol()
        {
            foreach (Alcohol a in alcoholLists)
            {
                Console.WriteLine("\n" + a.ShowInfo() + "\n");
            }
        }

        static void FractionMenu()
        {
            try
            {
                Console.WriteLine("\n--- Working with Fractions ---");

                Console.Write("Enter numerator of the first fraction: ");
                int numerator1 = int.Parse(Console.ReadLine());
                Console.Write("Enter denominator of the first fraction: ");
                int denominator1 = int.Parse(Console.ReadLine());

                Fraction fraction1 = new Fraction(numerator1, denominator1);

                Console.Write("Enter numerator of the second fraction: ");
                int numerator2 = int.Parse(Console.ReadLine());
                Console.Write("Enter denominator of the second fraction: ");
                int denominator2 = int.Parse(Console.ReadLine());

                Fraction fraction2 = new Fraction(numerator2, denominator2);

                Console.WriteLine("\nFractions:");
                Console.WriteLine($"Fraction 1: {fraction1}");
                Console.WriteLine($"Fraction 2: {fraction2}");

                Console.WriteLine("\nArithmetic Operations:");
                Console.WriteLine($"Addition: {fraction1 + fraction2}");
                Console.WriteLine($"Subtraction: {fraction1 - fraction2}");
                Console.WriteLine($"Multiplication: {fraction1 * fraction2}");
                Console.WriteLine($"Division: {fraction1 / fraction2}");

                Console.WriteLine("\nComparison Operations:");
                Console.WriteLine($"Fraction 1 > Fraction 2: {fraction1 > fraction2}");
                Console.WriteLine($"Fraction 1 < Fraction 2: {fraction1 < fraction2}");
                Console.WriteLine($"Fraction 1 == Fraction 2: {fraction1 == fraction2}");

                Console.WriteLine($"\nFraction 1 as double: {(double)fraction1}");
                Console.WriteLine($"Fraction 2 as double: {(double)fraction2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

    }
}
