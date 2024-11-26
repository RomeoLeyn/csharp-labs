using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lr_3_wpf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void generate_Click(object sender, EventArgs e)
        {
            if (int.TryParse(sizeArr.Text, out int size) &&
                double.TryParse(minValue.Text, out double min) &&
                double.TryParse(maxValue.Text, out double max) &&
                size > 0 && min < max)
            {

                double[] array = new double[size];
                FillRandomArray(array, min, max);


                listBox1.Items.Clear();
                foreach (var item in array)
                {
                    listBox1.Items.Add(item);
                }


                listBox2.Items.Clear();
                int product = FindProduct(array);
                listBox2.Items.Add("Product of indexes: " + product);


                listBox3.Items.Clear();
                SortArray(array);
                foreach (var item in array)
                {
                    listBox3.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Перевірте введені дані!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        static int FindProduct(double[] array)
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
            return productOfIndexes;
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
        }
    }
}
