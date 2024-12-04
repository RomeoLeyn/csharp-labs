using System;

namespace lr4
{

    struct Money
    {
        int Cash;
        short Pennies;

        public Money(int cash, short pennies)
        {
            Cash = cash + pennies / 100;
            Pennies = (short)(pennies % 100);

            if (Pennies < 0)
            {
                Cash--;
                Pennies += 100;
            }
        }

        public override string ToString()
        {
            return $"{Cash},{Pennies:D2}";
        }

        public static Money operator +(Money a, Money b)
        {
            return new Money(a.Cash + b.Cash, (short)(a.Pennies + b.Pennies));
        }

        public static Money operator -(Money a, Money b)
        {
            return new Money(a.Cash - b.Cash, (short)(a.Pennies - b.Pennies));
        }

        public static bool operator ==(Money a, Money b)
        {
            return a.Cash == b.Cash && a.Pennies == b.Pennies;
        }

        public static bool operator !=(Money a, Money b)
        {
            return !(a == b);
        }

        public static bool operator >(Money a, Money b)
        {
            if (a.Cash > b.Cash) return true;
            if (a.Cash == b.Cash && a.Pennies > b.Pennies) return true;
            return false;
        }

        public static bool operator <(Money a, Money b)
        {
            return !(a > b) && a != b;
        }

        public static bool operator >=(Money a, Money b) => a > b || a == b;
        public static bool operator <=(Money a, Money b) => a < b || a == b;
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Money money1 = new Money(10, 150);
            //Money money2 = new Money(5, 75);

            //Money sum = money1 + money2;
            //Money difference = money1 - money2;

            //Console.WriteLine($"money1: {money1}");
            //Console.WriteLine($"money2: {money2}");
            //Console.WriteLine($"Sum: {sum}");
            //Console.WriteLine($"Difference: {difference}");

            Money[] moneyArray = ReadMoneyArray(); 
            PrintMoneyArray(moneyArray); 

            SortMoneyArray(moneyArray); 
            Console.WriteLine("\nSorted Money Array:");
            PrintMoneyArray(moneyArray);

            ModifyMoney(ref moneyArray[0]); 
            Console.WriteLine("\nModified First Element:");
            PrintMoney(moneyArray[0]);

            FindMinMax(moneyArray, out Money min, out Money max);
            Console.WriteLine($"\nMin: {min}, Max: {max}");
        }
        static Money[] ReadMoneyArray()
        {
            Console.Write("Enter the number of elements: ");
            int n = int.Parse(Console.ReadLine());

            Money[] array = new Money[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter cash for element {i + 1}: ");
                int cash = int.Parse(Console.ReadLine());

                Console.Write($"Enter pennies for element {i + 1}: ");
                short pennies = short.Parse(Console.ReadLine());

                array[i] = new Money(cash, pennies);
            }
            return array;
        }

        static void PrintMoney(Money money)
        {
            Console.WriteLine(money);
        }

        static void PrintMoneyArray(Money[] array)
        {
            foreach (var money in array)
            {
                Console.WriteLine(money);
            }
        }

        static void SortMoneyArray(Money[] array)
        {
            Array.Sort(array, (a, b) =>
            {
                if (a > b) return 1;
                if (a < b) return -1;
                return 0;
            });
        }

        static void ModifyMoney(ref Money money)
        {
            Console.Write("Enter new cash: ");
            int newCash = int.Parse(Console.ReadLine());

            Console.Write("Enter new pennies: ");
            short newPennies = short.Parse(Console.ReadLine());

            money = new Money(newCash, newPennies);
        }

        static void FindMinMax(Money[] array, out Money min, out Money max)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("Array cannot be empty.");
            }

            min = array[0];
            max = array[0];

            foreach (var money in array)
            {
                if (money < min) min = money;
                if (money > max) max = money;
            }
        }

    }
}
