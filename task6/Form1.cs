using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Dictionary<double, double> coord = new Dictionary<double, double>();

        // Вычисление значения Oy в конкретной точке
        public static double Interpolation(double[] Ox, double[] Oy, double xval) 
        {
            double yval = 0;
            double prod = Oy[0];
            for (int i = 0; i < Ox.Length; i++)
            {
                prod = Oy[i];
                for (int j = 0; j < Ox.Length; j++)
                {
                    if (i != j)
                    {
                        prod *= (xval - Ox[j]) / (Ox[i] - Ox[j]);
                    }
                }
                yval += prod;
            }
            return yval;
        }

        // Общее вычисление значений Oy во всем множестве точек
        public static double[] Interpolation(double[] Ox, double[] Oy, int[] xvals)
        {
            double[] yvals = new double[xvals.Length];

            for (int i = 0; i < xvals.Length; i++)
                yvals[i] = Interpolation(Ox, Oy, xvals[i]);

            return yvals;
        }

        private void Form1_MouseClick_1(object sender, MouseEventArgs e)
        {
            Point[] points = new Point[Width]; // задание всех точек по пикселям

            Point point = e.Location;
            Graphics g = CreateGraphics();
            g.Clear(Color.White);

            Pen axis = new Pen(Color.Black); // оси
            Pen graph = new Pen(Color.Blue); // график
            Pen dot = new Pen(Color.Red); // график

            int radius = 4;

            // Необхдимо перерисовать, так как после события оси пропадают
            g.DrawLine(axis, Width / 2, 0, Width / 2, Height);
            g.DrawLine(axis, 0, Height / 2, Width, Height / 2);

            coord.TryAdd(e.X, e.Y);

            int[] xvals = new int[Width];
            double[] x = new double[coord.Count];
            double[] y = new double[coord.Count];

            int count = 0;
            foreach (var part in coord)
            {
                // Отрисовка точки нажатия
                g.DrawEllipse(dot, Convert.ToInt32(part.Key) - radius, Convert.ToInt32(part.Value) - radius, 2 * radius, 2 * radius);

                x[count] = part.Key;
                y[count] = part.Value;

                count++;
            }
            
            for (int i = 0; i < Width; i++)
            {
                xvals[i] = i;
            }

            double[] yvals = Interpolation(x, y, xvals);

            for (int i = 0; i <= points.Length - 1; i++)
            {
                points[i].X = xvals[i];
                points[i].Y = Convert.ToInt32(yvals[i]);
            }

            g.DrawLines(graph, points);
        }

        private void Form1_Shown_1(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            Pen axis = new Pen(Color.Black);

            g.DrawLine(axis, Width / 2, 0, Width / 2, Height);
            g.DrawLine(axis, 0, Height / 2, Width, Height / 2);
        }
    }
}
