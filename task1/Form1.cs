using System;
using System.Drawing;
using System.Windows.Forms;

namespace Task1
{
    public partial class Form1 : Form
    {
        private Graphics Graph;
        private Pen MyPen;

        public Form1()
        {
            InitializeComponent();
            Graph = CreateGraphics();
            MyPen = new Pen(Color.Black);
        }

        private void paintButton_Click(object sender, EventArgs e)
        {
            const double xMin = -5;
            const double xMax = 5;
            const double step = 0.01;
            
            Graph.Clear(Color.White);
            
            int x0 = ClientSize.Width / 2;
            int y0 = ClientSize.Height / 2;
            double t = xMin;
            double x = (t - Math.Sin(t));
            double y = (1 - Math.Cos(t));
            int x1 = (int)(x0 + x);
            int y1 = (int)(y0 - y);
            while (t < xMax)
            {
                t += step;
                x = (t - Math.Sin(t));
                y =(1 - Math.Cos(t));
                int x2 = (int)(x0 + x);
                int y2 = (int)(y0 - y);
                Graph.DrawLine(MyPen, x1, y1, x2, y2);
                x1 = x2;
                y1 = y2;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MyPen.Dispose();
            Graph.Dispose();
        }
    }
}