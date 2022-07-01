using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = double.Parse(textBoxA.Text);
            double b = double.Parse(textBoxB.Text);
            double h = double.Parse(textBoxH.Text);
            double k = double.Parse(textBox_b.Text);
            if (a > b) { (a, b) = (b, a); }
            int count = (int)Math.Ceiling((b - a) / h) + 1;
            double[] x = new double[count];
            double[] y1 = new double[count];
            double[] y2 = new double[count];
            for(int i=0;i<count;i++)
            {
                x[i] = a + h * i;
                y1[i] = 0.0025 * k * Math.Pow(x[i], 3) + Math.Sqrt(x[i] + Math.Pow(Math.E, 0.82));
                y2[i] = k * Math.Cos(x[i]);
            }
            chart1.ChartAreas[0].AxisX.Minimum = a;
            chart1.ChartAreas[0].AxisX.Maximum = b;
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = h;
            chart1.Series[0].Points.DataBindXY(x, y1);
            chart1.Series[1].Points.DataBindXY(x, y2);
        }
    }
}
