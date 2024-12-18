using lr9.Clasess;
using System;
using System.Collections.Generic;

namespace lr9
{
    class Program
    {
        static void Main(string[] args)
        {
            Transport car = new Car();
            Transport plane = new Plane();
            Transport train = new Train();

            Console.WriteLine($"Car Distance at Speed 100: {car.GetDistance(100)}");
            Console.WriteLine($"Plane Distance at Speed 100: {plane.GetDistance(100)}");
            Console.WriteLine($"Train Distance at Speed 100: {train.GetDistance(100)}");

            Employee employeeManager = new Employee("Manager", 40, 60000);

            employeeManager.Add(new Employee("John", 28, 40000));
            employeeManager.Add(new Employee("Anna", 35, 55000));
            employeeManager.Add(new Employee("Steve", 25, 45000));

            Console.WriteLine("Employees sorted by Salary:");
            employeeManager.PrintBySalary();
        }
    }
}
