using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Task1
{
    public partial class Form1 : Form
    {
        private Graphics Graph;
        private Pen MyPen;
        private int N;
        private int L;
        private int N1;
        private int r;
        private int R;

        public Form1()
        {
            InitializeComponent();
            Graph = CreateGraphics();
            MyPen = new Pen(Color.Black);
        }
        
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                N = int.Parse(textBox.Text);
                if (N < 0)
                {
                    N = 0;
                }
            }
            catch (Exception)
            {
                N = 0;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                L = int.Parse(textBox1.Text);
                if (L < 0)
                {
                    L = 0;
                }
            }
            catch (Exception)
            {
                L = 0;
            }
        }
        
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                N1 = int.Parse(textBox3.Text);
                if (N1 < 0)
                {
                    N1 = 0;
                }
            }
            catch (Exception)
            {
                N1 = 0;
            }
        }
        
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                r = int.Parse(textBox2.Text);
                if (r < 0)
                {
                    r = 0;
                }
            }
            catch (Exception)
            {
                r = 0;
            }
        }
        
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                R = int.Parse(textBox4.Text);
                if (R < 0)
                {
                    R = 0;
                }
            }
            catch (Exception)
            {
                R = 0;
            }
        }
        
        private void paintButton_Click(object sender, EventArgs e)
        {
            if (N == 0 || L == 0)
            {
                return;
            }
            
            Graph.Clear(Color.White);
            
            List<Point> points = new List<Point>();
            int x0 = ClientSize.Width / 2;
            int y0 = ClientSize.Height / 2;
            double r = L / (2 * Math.Sin(Math.PI / N));
            for (double angle = 0.0; angle <= 2 * Math.PI; angle += 2 * Math.PI / N)
            {
                int x = (int)(r * Math.Cos(angle));
                int y = (int)(r * Math.Sin(angle));
                Graph.DrawLine(MyPen, x0, y0, x0 + x, y0 - y);
                points.Add(new Point(x0 +x,  y0 - y));
            }

            Graph.SmoothingMode = SmoothingMode.HighQuality;
            if (points.Count >= 3)
            {
                Graph.DrawPolygon(MyPen, points.ToArray());
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (N1 == 0 || r == 0 || R == 0)
            {
                return;
            }
            
            Graph.Clear(Color.White);
            
            List<Point> points = new List<Point>();
            int x0 = ClientSize.Width / 2;
            int y0 = ClientSize.Height / 2;
            double a = 0, da = Math.PI / N1, l;
            for (int k = 0; k < 2 * N1 + 1; k++)
            {
                l = k % 2 == 0 ? r : R;
                int x = (int)(l * Math.Cos(a));
                int y = (int)(l * Math.Sin(a));
                /*if (k > 1 && k % 2 == 1)
                {
                    Graph.DrawLine(MyPen, x0 + x, y0 + y, points[points.Count - 2].X, points[points.Count - 2].Y);
                }*/
                Graph.DrawLine(MyPen, x0, y0, x0 + x, y0 - y);
                points.Add(new Point(x0 + x, y0 + y));
                a += da;
            }

            //Graph.DrawLine(MyPen, points[points.Count - 2].X, points[points.Count - 2].Y, points[1].X, points[1].Y);
            Graph.SmoothingMode = SmoothingMode.HighQuality;
            Graph.DrawLines(MyPen, points.ToArray());
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MyPen.Dispose();
            Graph.Dispose();
        }
    }
}