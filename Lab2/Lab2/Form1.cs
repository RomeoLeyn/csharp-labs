using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            double x, y, z;

            if (double.TryParse(textBox1.Text, out x) &&
            double.TryParse(textBox2.Text, out y) &&
            double.TryParse(textBox3.Text, out z))
            {

                double s = 2 * Math.Cos(Math.Pow(x, 2)) - 1 / Math.Sqrt(2) + Math.Pow(Math.E, 2) /
                2 / 3 + Math.Sin(Math.Pow(y, 2 - z));
                label5.Text = s.ToString();
            }  
            else
            {
                MessageBox.Show("Некоректні дані!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
