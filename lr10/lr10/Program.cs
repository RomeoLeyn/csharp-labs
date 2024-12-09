using System;
using System.Collections.Generic;

namespace lr10
{
    class Program
    {
        static void Main()
        {
            DemonstrateQueue();

            DemonstrateDictionary();
        }

        static void DemonstrateQueue()
        {
            Console.WriteLine("Queue Demo ");

            Queue<object> queue = new Queue<object>();

            queue.Enqueue("Hello, world!"); 
            queue.Enqueue(42);              
            queue.Enqueue(3.14);            

            Console.WriteLine("Queue after enqueue operations:");
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Dequeued element: {queue.Dequeue()}");

            Console.WriteLine("Queue contains 42: " + queue.Contains(42));

            Console.WriteLine("Number of elements in queue: " + queue.Count);

            queue.Clear();
            Console.WriteLine("Queue cleared.");
            Console.WriteLine("Number of elements in queue: " + queue.Count);
        }

        static void DemonstrateDictionary()
        {
            Console.WriteLine("\nDictionary Demo");

            Dictionary<int, Airplane> airplanes = new Dictionary<int, Airplane>();

            airplanes.Add(1, new Airplane("Kyiv", "Lviv",
                new Date(2024, "December", "9", 10, 0),
                new Date(2024, "December", "9", 12, 0)));
            airplanes.Add(2, new Airplane("Odesa", "Kharkiv",
                new Date(2024, "December", "10", 15, 30),
                new Date(2024, "December", "10", 17, 45)));

            Console.WriteLine("Airplanes in dictionary:");
            foreach (var entry in airplanes)
            {
                Console.WriteLine($"ID: {entry.Key}, Airplane: {entry.Value}");
            }

            int searchId = 1;
            if (airplanes.TryGetValue(searchId, out Airplane foundAirplane))
            {
                Console.WriteLine($"Found airplane with ID {searchId}: {foundAirplane}");
            }
            else
            {
                Console.WriteLine($"Airplane with ID {searchId} not found.");
            }

            Console.WriteLine("Number of airplanes in dictionary: " + airplanes.Count);

            airplanes.Remove(1);
            Console.WriteLine("Airplane with ID 1 removed.");

            airplanes.Clear();
            Console.WriteLine("Dictionary cleared.");
            Console.WriteLine("Number of airplanes in dictionary: " + airplanes.Count);
        }

    }
}
