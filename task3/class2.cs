using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace dots_class
{
    class _4dots : dots
    {
        private dots A;
        private dots B;
        private dots C;
        private dots D;

        public _4dots(dots A, dots B, dots C, dots D)
        {
            if (dots.Equasion3D(A, B, C, D))
            {
                this.A = A;
                this.B = B;
                this.C = C;
                this.D = D;
            }
            else
            {
                this.A = new dots(0, 0, 0);
                this.B = new dots(0, 0, 0);
                this.C = new dots(0, 0, 0);
                this.D = new dots(0, 0, 0);
            }
        }

        public static double Area(_4dots Qr)
        {
            double a = Dist(Qr.A, Qr.B);
            double b = Dist(Qr.B, Qr.C);
            double c = Dist(Qr.C, Qr.D);
            double d = Dist(Qr.C, Qr.D);

            double angle1 = Angle(Vector(Qr.A, Qr.B), Vector(Qr.B, Qr.C));
            double angle2 = Angle(Vector(Qr.C, Qr.D), Vector(Qr.A, Qr.D));
            
            double p = (a + b + c + d) / 2; // half of perimeter
            double container = (p - a) * (p - b) * (p - c) * (p - d);

            double area = Math.Sqrt(container - a*b*c*d * Math.Pow(Math.Cos((angle1 + angle2) / 2), 2));

            return area;

        }

        public static double Perimeter(_4dots Qr)
        {
            double Pm = Dist(Qr.A, Qr.B) + Dist(Qr.B, Qr.C) + Dist(Qr.C, Qr.D) + Dist(Qr.D, Qr.A);
            return Pm;
        }

        public static double[] Diagonale(_4dots Qr)
        {
            double diag_1 = Dist(Qr.A, Qr.C);
            double diag_2 = Dist(Qr.B, Qr.D);

            double[] Diagonales = new double[2] { diag_1, diag_2 };
            return Diagonales;
        }

        public static bool Сonvexity(_4dots Qr)
        {
            if (!((Qr.B - Qr.C) / (Qr.B - Qr.D))) { return false; }
            if (!((Qr.C - Qr.D) / (Qr.C - Qr.A))) { return false; }
            if (!((Qr.A - Qr.B) / (Qr.A - Qr.C))) { return false; }
            
            return true;
        }

    }
}
