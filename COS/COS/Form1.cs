using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows.Forms.DataVisualization.Charting;

//3 variant

namespace COS
{
    public partial class Form1 : Form
    {

        static Double pi = 3.14;
        static Int32[] ffi = { 45, 135, 120, 90, 60 };

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            Int32 a = int.Parse(comboBox1.Text),
                N = int.Parse(comboBox4.Text);
            Double f = Double.Parse(comboBox2.Text),
                fi = pi*Double.Parse(comboBox3.Text);

            chart1.Series[0].ChartType = SeriesChartType.Spline;
            for (int i = 1; i < N; i++)
            {
                Double x = a * Math.Sin(((2*pi*f*i)/N)+fi*Math.PI/180);
                chart1.Series[0].Points.AddXY(i,x);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Int32 a = 3,
                f = 0;
            chart1.Series[0].Points.Clear();
            Int32 N = int.Parse(comboBox4.Text);
            chart1.Series[0].ChartType = SeriesChartType.Spline;

            Double result = 0;

            for (int n = 0; n<N; n++ )
            {
                result = 0;
                for (int i = 1; i<=5; i++)
                {
                    f = i;
                    result += a * Math.Sin((2*Math.PI*f*n)/N + ffi[i-1]*Math.PI/180);
                }
                chart1.Series[0].Points.AddXY(n, result);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Int32 a = 3,
                f = 0;
            chart1.Series[0].Points.Clear();
            Int32 N = int.Parse(comboBox4.Text);
            //chart1.Series.Add("20%");
            chart1.Series[0].ChartType = SeriesChartType.Spline;

            Double result = 0;

            for (int n = 0; n < N; n++)
            {
                result = 0;
                for (int i = 1; i <= 5; i++)
                {
                    f = i;
                    result += a * (1 + (double)n / N / 5) * Math.Sin((2 * Math.PI * f * n) / N + ffi[i - 1] * Math.PI / 180);
                }
                chart1.Series[0].Points.AddXY(n, result);
            }
        }
    }
}
