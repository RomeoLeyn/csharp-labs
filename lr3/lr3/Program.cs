using System;
using System.Linq;

namespace lr3
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter array size - ");
            int size = int.Parse(Console.ReadLine());

            int line = int.Parse(Console.ReadLine());
            int column = int.Parse(Console.ReadLine());

            double[] randomArray = new double[size];
            double[,] randomTwoDimensionalArray = new double[line, column];

            FillRandomArray(randomArray, -2.9, 60.3);
            FindProduct(randomArray);
            SortArray(randomArray);
            FillTwoDinensionalArray(randomTwoDimensionalArray, -15.62, 53.36, line, column);
            int nonPositiveRowsCount = CountNonPositiveRows(randomTwoDimensionalArray);
            Console.WriteLine($"\nКількість рядків, які не містять жодного додатного елемента: {nonPositiveRowsCount}");

            SortColumnsByPositiveSumDescending(ref randomTwoDimensionalArray);
            Console.WriteLine("\nМасив після сортування стовпців за спаданням сум модулів додатних елементів:");
            PrintArray(randomTwoDimensionalArray);
        }


        static void PrintArray(double[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(array[i, j].ToString("F2") + "\t");
                }
                Console.WriteLine();
            }
        }

        static void FillRandomArray(double[] arr, double min, double max)
        {
            Random random = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.NextDouble() * (max - min) + min;
            }

            Console.WriteLine(arr[3]);
        }

        static void FillTwoDinensionalArray(double[,] array, double min, double max, int line, int column)
        {
            Random random = new Random();
            for(int i = 0; i < line; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    array[i, j] = min + random.NextDouble() * (max - min);
                }
            }
        }

        static int CountNonPositiveRows(double[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            int count = 0;

            for (int i = 0; i < rows; i++)
            {
                bool hasPositive = false;
                for (int j = 0; j < cols; j++)
                {
                    if (array[i, j] > 0)
                    {
                        hasPositive = true;
                        break;
                    }
                }
                if (!hasPositive)
                    count++;
            }
            return count;
        }

        static void SortColumnsByPositiveSumDescending(ref double[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            double[] columnSums = new double[cols];

            for (int j = 0; j < cols; j++)
            {
                double sum = 0;
                for (int i = 0; i < rows; i++)
                {
                    if (array[i, j] > 0)
                        sum += Math.Abs(array[i, j]);
                }
                columnSums[j] = sum;
            }

            for (int j = 0; j < cols - 1; j++)
            {
                for (int k = j + 1; k < cols; k++)
                {
                    if (columnSums[j] < columnSums[k])
                    {
                        double tempSum = columnSums[j];
                        columnSums[j] = columnSums[k];
                        columnSums[k] = tempSum;

                        for (int i = 0; i < rows; i++)
                        {
                            double temp = array[i, j];
                            array[i, j] = array[i, k];
                            array[i, k] = temp;
                        }
                    }
                }
            }
        }

        static void FindProduct(double[] array)
        {
            int minIndex = Array.IndexOf(array, array.Min());
            int maxIndex = Array.IndexOf(array, array.Max());

            if (minIndex > maxIndex)
            {
                int temp = minIndex;
                minIndex = maxIndex;
                maxIndex = temp;
            }

            int productOfIndexes = 1;
            for (int i = minIndex + 1; i < maxIndex; i++)
            {
                productOfIndexes *= i;
            }
            Console.WriteLine("Product: " + productOfIndexes);
        }

        static void SortArray(double[] array)
        {

            int minIndex = Array.IndexOf(array, array.Min());
            int maxIndex = Array.IndexOf(array, array.Max());

            double[] subArray = array.Skip(minIndex + 1).Take(maxIndex - minIndex - 1).OrderByDescending(x => x).ToArray();

            for (int i = 0; i < subArray.Length; i++)
            {
                array[minIndex + 1 + i] = subArray[i];
            }

            Console.WriteLine("Sorted array:");
            Console.WriteLine(string.Join(" ", array));
        }
    }
}
