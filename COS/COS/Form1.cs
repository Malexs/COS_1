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
{  public partial class Form1 : Form
    {

        static Double pi = 3.14;
        static Int32[] ffi = { 45, 135, 120, 90, 60 };
        Boolean isCreated = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isCreated)
            {
                chart1.Series.RemoveAt(1);
                isCreated = false;
            }

            chart1.Series[0].Points.Clear();
            Double a = Double.Parse(comboBox1.Text),
                N = Double.Parse(comboBox4.Text);
            Double f = Double.Parse(comboBox2.Text),
                fi = Double.Parse(comboBox3.Text);

            chart1.Series[0].ChartType = SeriesChartType.Spline;
            for (int i = 1; i < N; i++)
            {
                Double x = a * Math.Sin(2 * Math.PI * f * i / N + (Double)(fi / 180 * Math.PI));
                chart1.Series[0].Points.AddXY(i,x);
            }
            chart1.ResetAutoValues();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Int32 a = 3,
                f = 0;
            if (isCreated)
            {
                chart1.Series.RemoveAt(1);
                isCreated = false;
            }
            chart1.Series[0].Points.Clear();
            Int32 N = int.Parse(comboBox4.Text);
            chart1.Series[0].ChartType = SeriesChartType.Spline;

            Double result = 0;

            for (int n = 0; n<N; n++ )
            {
                result = 0;
                for (int i = 1; i<=5; i++)
                {
                    result += 5 * a * Math.Sin((2*Math.PI*5*i*n)/N + 5*ffi[i-1]*Math.PI/180);
                }
                chart1.Series[0].Points.AddXY(n, result);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Int32 a = 3,
                f = 0;
            if (isCreated == false)
            {
                isCreated = true;
                chart1.Series.Add("20%");
                chart1.Series[1].ChartType = SeriesChartType.Spline;
            }
            chart1.Series[1].Points.Clear();
            Int32 N = int.Parse(comboBox4.Text);

            Double result = 0;

            for (int n = 0; n < N; n++)
            {
                result = 0;
                for (int i = 1; i <= 5; i++)
                {
                    f = i;
                    result += a*5 * (1 + (double)n / N / 5) * Math.Sin((2 * Math.PI *5* f * n) / N + 5*ffi[i - 1] * Math.PI / 180);
                }
                chart1.Series[1].Points.AddXY(n, result);
            }
        }
    }
}
