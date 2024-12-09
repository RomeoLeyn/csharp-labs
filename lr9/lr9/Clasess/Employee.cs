using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lr9.Clasess
{
    public class Employee : IComparable<Employee>, IEnumerable<Employee>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }

        public Employee(string name, int age, double salary)
        {
            Name = name;
            Age = age;
            Salary = salary;
        }

        public int CompareTo(Employee other)
        {
            return Age.CompareTo(other.Age);
        }

        private List<Employee> _employees = new List<Employee>();

        public void Add(Employee employee)
        {
            _employees.Add(employee);
        }

        public void PrintBySalary()
        {
            foreach (var emp in _employees.OrderBy(e => e.Salary))
            {
                Console.WriteLine($"Name: {emp.Name}, Age: {emp.Age}, Salary: {emp.Salary}");
            }
        }

        public IEnumerator<Employee> GetEnumerator()
        {
            return _employees.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
