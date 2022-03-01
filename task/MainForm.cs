using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace task
{
    public partial class MainForm : Form
    {
        private Graphics Graph;
        private Pen MyPen;
        
        public MainForm()
        {
            InitializeComponent();
            Graph = CreateGraphics();
            Graph.SmoothingMode = SmoothingMode.HighQuality;
            MyPen = new Pen(Color.Black);
        }

        private void paintButton_Click(object sender, EventArgs e)
        {
            Graph.Clear(Color.White);
            
            var x0 = ClientSize.Width / 2;
            var y0 = ClientSize.Height / 2;
            
            var kX = 1;
            var kY = 1;
            
            switch (figureSwitch.SelectedIndex)
            {
                case 0:
                    PaintPolygonWithAdditionalSegments(8, 200, x0, y0, kX, kY);
                    break;
                case 1:
                    PaintStarWithAdditionalSegmentsIn(5, 150, 300, x0, y0, kX, kY);
                    break;
                case 2:
                    PaintStarWithAdditionalSegmentsOut(5, 150, 300, x0, y0, kX, kY);
                    break;
                case 3:
                    kX = 2;
                    PaintPolygonWithAdditionalSegments(8, 200, x0, y0, kX, kY);
                    break;
                case 4:
                    kY = 2;
                    PaintPolygonWithAdditionalSegments(8, 200, x0, y0, kX, kY);
                    break;
                case 5:
                    kX = 2;
                    PaintStarWithAdditionalSegmentsIn(5, 150, 300, x0, y0, kX, kY);
                    break;
                case 6:
                    kY = 2;
                    PaintStarWithAdditionalSegmentsIn(5, 150, 300, x0, y0, kX, kY);
                    break;
                case 7:
                    PaintOrnamentA();
                    break;
                case 8:
                    PaintOrnamentB();
                    break;
                case 9:
                    PaintOrnamentC();
                    break;
                case 10:
                    PaintOrnamentD();
                    break;
                case 11:
                    PaintNEvenStar(8, x0, y0);
                    break;
                case 12:
                    PaintNUnEvenStar(9, x0, y0);
                    break;
            }
        }

        private static List<Point> CreatePolygon(int n, int l, int x0, int y0, int kX, int kY)
        {
            var points = new List<Point>();
            
            var r = l / (2 * Math.Sin(Math.PI / n));
            for (var angle = 0.0; angle <= 2 * Math.PI; angle += 2 * Math.PI / n)
            {
                var x = (int)(r * Math.Cos(angle)) * kX;
                var y = (int)(r * Math.Sin(angle)) * kY;
                points.Add(new Point(x0 +x,  y0 - y));
            }

            return points;
        }
        
        private static List<Point> CreatePolygon(int n, int l, int x0, int y0, int kX, int kY, double startAngle)
        {
            var points = new List<Point>();
            
            var r = l / (2 * Math.Sin(Math.PI / n));
            var currentAngle = startAngle;
            var stepAngle = 2 * Math.PI / n;
            for (var i = 0; i < n; i++)
            {
                var x = (int)(r * Math.Cos(currentAngle)) * kX;
                var y = (int)(r * Math.Sin(currentAngle)) * kY;
                currentAngle += stepAngle;
                points.Add(new Point(x0 +x,  y0 - y));
            }

            return points;
        }
        
        private void PaintPolygon(int n, int l, int x0, int y0, int kX, int kY)
        {
            var points = CreatePolygon(n, l, x0, y0, kX, kY);
            Graph.DrawPolygon(MyPen, points.ToArray());
        }
        
        private void PaintPolygon(int n, int l, int x0, int y0, int kX, int kY, double startAngle)
        {
            var points = CreatePolygon(n, l, x0, y0, kX, kY, startAngle);
            Graph.DrawPolygon(MyPen, points.ToArray());
        }

        private void PaintPolygonWithAdditionalSegments(int n, int l, int x0, int y0, int kX, int kY)
        {
            var points = CreatePolygon(n, l, x0, y0, kX, kY);

            foreach (var point in points)
            {
                Graph.DrawLine(MyPen, x0, y0, point.X, point.Y);
            }

            Graph.DrawPolygon(MyPen, points.ToArray());
        }
        
        private static List<Point> CreateStar(int n, int r, int R, int x0, int y0, int kX, int kY)
        {
            var points = new List<Point>();
            
            double a = 0;
            var da = Math.PI / n;
            for (var i = 0; i < 2 * n + 1; i++)
            {
                double l = i % 2 == 0 ? R : r;
                var x = (int)(l * Math.Cos(a)) * kX;
                var y = (int)(l * Math.Sin(a)) * kY;
                a += da;
                points.Add(new Point(x0 + x, y0 + y));
            }

            return points;
        }
        
        private void PaintStar(int n, int r, int R, int x0, int y0, int kX, int kY)
        {
            var points = CreateStar(n, r, R, x0, y0, kX, kY);
            Graph.DrawLines(MyPen, points.ToArray());
        }
        
        private void PaintStarWithAdditionalSegmentsIn(int n, int r, int R, int x0, int y0, int kX, int kY)
        {
            var points = CreateStar(n, r, R, x0, y0, kX, kY);

            foreach (var point in points)
            {
                Graph.DrawLine(MyPen, x0, y0, point.X, point.Y);
            }

            Graph.DrawLines(MyPen, points.ToArray());
        }
        
        private void PaintStarWithAdditionalSegmentsOut(int n, int r, int R, int x0, int y0, int kX, int kY)
        {
            var points = CreateStar(n, r, R, x0, y0, kX, kY);

            for (var i = 0; i < points.Count - 2; i += 2)
            {
                Graph.DrawLine(MyPen, points[i].X, points[i].Y, points[i + 2].X, points[i + 2].Y);
            }

            Graph.DrawLines(MyPen, points.ToArray());
        }
        
        private void PaintOrnamentA()
        {
            const int n = 8;
            const int l = 100;
            const int count = 9;
            
            for (var i = 1; i <= Math.Sqrt(count); i++)
            {
                for (var j = 1; j <= Math.Sqrt(count); j++)
                {
                    var r = (int)(l / (2 * Math.Sin(Math.PI / n)));
                    var center = new Point(2 * r * i + 4 * r,  2 * r * j);
                    PaintPolygon(n, l, center.X, center.Y, 1, 1);
                }
            }
        }
        
        private void PaintOrnamentB()
        {
            const int nPolygon = 8;
            const int l = 100;
            const int nStar = 4;
            const int r = 50;
            const int count = 9;

            for (var i = 1; i <= Math.Sqrt(count); i++)
            {
                for (var j = 1; j <= Math.Sqrt(count); j++)
                {
                    var rPolygon = (int)(l / (2 * Math.Sin(Math.PI / nPolygon)));
                    var center = new Point(2 * rPolygon * i + 4 * rPolygon,  2 * rPolygon * j);
                    PaintPolygon(nPolygon, l, center.X, center.Y, 1, 1);
                    PaintStar(nStar, r, rPolygon, center.X, center.Y, 1, 1);
                }
            }
        }
        
        private void PaintOrnamentC()
        {
            const int n = 6;
            const int l = 100;
            const int count = 16;
            
            var r = (int)(l / (2 * Math.Sin(Math.PI / n)));
            var centers = CreateCentersOfFigures(n, r, count);
            
            var cnt = 0;
            for (var i = 1; i <= Math.Sqrt(count); i++)
            {
                for (var j = 1; j <= Math.Sqrt(count); j++)
                {
                    PaintPolygon(n, l, centers[cnt].X, centers[cnt].Y, 1, 1);
                    cnt++;
                }
            }
        }
        
        private void PaintOrnamentD()
        {
            const int n = 6;
            const int r = 50;
            const int R = 100;
            const int count = 16;
            
            var centers = CreateCentersOfFigures(n, R, count);
            
            var cnt = 0;
            for (var i = 1; i <= Math.Sqrt(count); i++)
            {
                for (var j = 1; j <= Math.Sqrt(count); j++)
                {
                    PaintStar(n, r, R, centers[cnt].X, centers[cnt].Y, 1, 1);
                    cnt++;
                }
            }
        }
        
        private static List<Point> CreateCentersOfFigures(int n, int r, int count)
        {
            var points = new List<Point>();
            
            var angleC = (float)Math.Cos(2 * Math.PI / (2 * n));
            var angleS = (float)Math.Sin(2 * Math.PI / (2 * n));
            var h = (float)(r * Math.Cos(2 * Math.PI / (2 * n)));
            var stepX = (int)(angleC * 2 * h);
            var stepY = (int)(angleS * 2 * h);
            var countInRow = (int)Math.Sqrt(count);
            
            for (var i = 0; i < Math.Sqrt(count); i++)
            {
                points.Add(new Point((int)(2 * h) + 6 * r, (int)(2 * h * (i + 1))));
                for (var j = 0; j < Math.Sqrt(count) - 1; j++)
                {
                    points.Add(j % 2 == 0
                        ? new Point(points[i * countInRow + j].X + stepX,
                            points[i * countInRow + j].Y + stepY)
                        : new Point(points[i * countInRow + j].X + stepX,
                            points[i * countInRow + j].Y - stepY));
                }
            }
            
            return points;
        }
        
        private void PaintNEvenStar(int n, int x0, int y0)
        {
            const int l = 400;
            const int countAngle = 4;
            
            double currentAngle = 0;
            for (var i = 0; i < n / 4; i++)
            {
                PaintPolygon(countAngle, l, x0, y0, 1, 1, currentAngle);
                currentAngle += 2 * Math.PI / n;
            }
        }
        
        private void PaintNUnEvenStar(int n, int x0, int y0)
        {
            const int l = 400;
            const int countAngle = 3;
            
            var currentAngle = -Math.PI / 6;
            for (var i = 0; i < n / 3; i++)
            {
                PaintPolygon(countAngle, l, x0, y0, 1, 1, currentAngle);
                currentAngle += 2 * Math.PI / n;
            }
        }
    }
}