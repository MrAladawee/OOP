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
            if (dots.Equasion(A, B, C, D))
            {
                this.A = A;
                this.B = B;
                this.C = C;
                this.D = D;
            }
            else
            {
                Console.WriteLine("They do not lie in the same plane. Not a quadrilateral.");
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

            double area = Math.Sqrt(container - a * b * c * d * Math.Pow(Math.Cos((angle1 + angle2) / 2), 2));

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
            if (Math.Sign(VectorMlp(Qr.A - Qr.B, Qr.D - Qr.B) / VectorMlp(Qr.D - Qr.B, Qr.C - Qr.B)) ==
                Math.Sign(VectorMlp(Qr.B - Qr.A, Qr.C - Qr.A) / VectorMlp(Qr.C - Qr.A, Qr.D - Qr.A)))
            {
                return true;
            }

            return false;
        }

        public static bool Сonvexity2(_4dots Qr)
        {
            if (!((Qr.A - Qr.B) / (Qr.A - Qr.C))) { return false; }
            if (!((Qr.B - Qr.C) / (Qr.B - Qr.D))) { return false; }
            if (!((Qr.C - Qr.D) / (Qr.C - Qr.A))) { return false; }
            return true;
        }

        public static bool IdSquare(_4dots Qr)
        {
            if (Dist(Qr.A, Qr.B) == Dist(Qr.B, Qr.C) && (Dist(Qr.C, Qr.D) == Dist(Qr.D, Qr.A))
                && (Dist(Qr.B, Qr.C) == Dist(Qr.D, Qr.C)) &&
                convGrad(Angle(Vector(Qr.A, Qr.B), Vector(Qr.A,Qr.D))) == 90 &&
                convGrad(Angle(Vector(Qr.C, Qr.D), Vector(Qr.A, Qr.D))) == 90 )
            {
                return true;
            }
            return false;
        }

        public static bool IdRectangle(_4dots Qr)
        {
            if (Dist(Qr.A, Qr.B) == Dist(Qr.D,Qr.C) && Dist(Qr.B, Qr.C) == Dist(Qr.A, Qr.D) &&
                Dist(Qr.A,Qr.B) != Dist(Qr.A,Qr.D) &&
                convGrad(Angle(Vector(Qr.A, Qr.B), Vector(Qr.A, Qr.D))) == 90 &&
                convGrad(Angle(Vector(Qr.C, Qr.D), Vector(Qr.A, Qr.D))) == 90)
            {
                return true;
            }
            return false;
        }
        public static bool IdParallelogram(_4dots Qr)
        {
            if (Dist(Qr.A, Qr.B) == Dist(Qr.D, Qr.C) && Dist(Qr.B, Qr.C) == Dist(Qr.A, Qr.D) &&
                Dist(Qr.A, Qr.B) != Dist(Qr.A, Qr.D) )
            {
                dots AB = Vector(Qr.A, Qr.B);
                dots CD = Vector(Qr.D, Qr.C);

                // Checking by a vector product. If zero => are parallel
                if (AB.Oy * CD.Oz - AB.Oz * CD.Oy == 0 &&
                    AB.Oz * CD.Ox - AB.Ox * CD.Oz == 0 &&
                    AB.Ox * CD.Oy - AB.Oy * CD.Ox == 0)
                {
                    return true;
                }
                
                return false;

            }

            return false;
        }

        public static bool IdRhombus(_4dots Qr)
        {
            if (Dist(Qr.A, Qr.B) == Dist(Qr.B, Qr.C) && (Dist(Qr.C, Qr.D) == Dist(Qr.D, Qr.A))
                && (Dist(Qr.B, Qr.C) == Dist(Qr.D, Qr.C)))
            {
                dots AB = Vector(Qr.A, Qr.B);
                dots CD = Vector(Qr.D, Qr.C);

                // Checking by a vector product. If zero => are parallel
                if (AB.Oy * CD.Oz - AB.Oz * CD.Oy == 0 &&
                    AB.Oz * CD.Ox - AB.Ox * CD.Oz == 0 &&
                    AB.Ox * CD.Oy - AB.Oy * CD.Ox == 0)
                {
                    return true;
                }

                return false;

            }

            return false;

        }

        public static bool IdTrapeze(_4dots Qr)
        {

            dots AB = Vector(Qr.A, Qr.B);
            dots CD = Vector(Qr.D, Qr.C);
            dots BC = Vector(Qr.B, Qr.C);
            dots AD = Vector(Qr.A, Qr.D);

            // Checking by a vector product. If zero => are parallel
            if (AB.Oy * CD.Oz - AB.Oz * CD.Oy == 0 &&
                AB.Oz * CD.Ox - AB.Ox * CD.Oz == 0 &&
                AB.Ox * CD.Oy - AB.Oy * CD.Ox == 0)
            {
                // Checking by a vector product.If != zero => not parallel
                if (BC.Oy * AD.Oz - BC.Oz * AD.Oy != 0 ||
                BC.Oz * AD.Ox - BC.Ox * AD.Oz != 0 ||
                BC.Ox * AD.Oy - BC.Oy * AD.Ox != 0)
                {
                    return true;
                }

                return false;

            }

            else
            {
                if (BC.Oy * AD.Oz - BC.Oz * AD.Oy == 0 &&
                BC.Oz * AD.Ox - BC.Ox * AD.Oz == 0 &&
                BC.Ox * AD.Oy - BC.Oy * AD.Ox == 0)
                {

                    if (AB.Oy * CD.Oz - AB.Oz * CD.Oy != 0 ||
                        AB.Oz * CD.Ox - AB.Ox * CD.Oz != 0 ||
                        AB.Ox * CD.Oy - AB.Oy * CD.Ox != 0)
                    {
                        return true;
                    }

                    return false;

                }
            }
                return false;
        }

        public static bool Intersection2D(_4dots Qr1, _4dots Qr2)
        {

            // AB1 with another
            if (
            dots.IntersectionBool2D(Qr1.A, Qr1.B, Qr2.A, Qr2.B) == true ||
            dots.IntersectionBool2D(Qr1.A, Qr1.B, Qr2.B, Qr2.C) == true ||
            dots.IntersectionBool2D(Qr1.A, Qr1.B, Qr2.C, Qr2.D) == true ||
            dots.IntersectionBool2D(Qr1.A, Qr1.B, Qr2.D, Qr2.A) == true
            )
            {
                return true;
            }

            // BC1 with another
            if (
            dots.IntersectionBool2D(Qr1.B, Qr1.C, Qr2.A, Qr2.B) == true ||
            dots.IntersectionBool2D(Qr1.B, Qr1.C, Qr2.B, Qr2.C) == true ||
            dots.IntersectionBool2D(Qr1.B, Qr1.C, Qr2.C, Qr2.D) == true ||
            dots.IntersectionBool2D(Qr1.B, Qr1.C, Qr2.D, Qr2.A) == true
            )
            {
                return true;
            }

            // CD1 with another
            if (
            dots.IntersectionBool2D(Qr1.C, Qr1.D, Qr2.A, Qr2.B) == true ||
            dots.IntersectionBool2D(Qr1.C, Qr1.D, Qr2.B, Qr2.C) == true ||
            dots.IntersectionBool2D(Qr1.C, Qr1.D, Qr2.C, Qr2.D) == true ||
            dots.IntersectionBool2D(Qr1.C, Qr1.D, Qr2.D, Qr2.A) == true
            )
            {
                return true;
            }

            // DA1 with another
            if (
            dots.IntersectionBool2D(Qr1.D, Qr1.A, Qr2.A, Qr2.B) == true ||
            dots.IntersectionBool2D(Qr1.D, Qr1.A, Qr2.B, Qr2.C) == true ||
            dots.IntersectionBool2D(Qr1.D, Qr1.A, Qr2.C, Qr2.D) == true ||
            dots.IntersectionBool2D(Qr1.D, Qr1.A, Qr2.D, Qr2.A) == true
            )
            {
                return true;
            }

            return false;
        }

        public static bool Including2D(_4dots Qr1, _4dots Qr2)
        {
            double[] Ox1 = new double[4] { Qr1.A.Ox, Qr1.B.Ox, Qr1.C.Ox, Qr1.D.Ox };
            double[] Ox2 = new double[4] { Qr2.A.Ox, Qr2.B.Ox, Qr2.C.Ox, Qr2.D.Ox };
            
            double[] Oy1 = new double[4] { Qr1.A.Oy, Qr1.B.Oy, Qr1.C.Oy, Qr1.D.Oy };
            double[] Oy2 = new double[4] { Qr2.A.Oy, Qr2.B.Oy, Qr2.C.Oy, Qr2.D.Oy };

            double minOx1 = Ox1.Min(); double maxOy1 = Oy1.Max();
            double minOx2 = Ox2.Min(); double maxOy2 = Oy2.Max();
            double maxOx1 = Ox1.Max(); double minOy1 = Oy1.Min();
            double maxOx2 = Ox2.Max(); double minOy2 = Oy2.Min();

            if (
                (((minOx1 > minOx2 && minOx1 < maxOx2) && (maxOx1 > minOx2 && maxOx1 < maxOx2)) &&
                ((minOy1 > minOy2 && minOy1 < maxOy2) && (maxOy1 > minOy2 && maxOy1 < maxOy2)))
                ||
                (((minOx2 > minOx1 && minOx2 < maxOx1) && (maxOx2 > minOx1 && maxOx2 < maxOx1)) &&
                ((minOy2 > minOy1 && minOy2 < maxOy1) && (maxOy2 > minOy1 && maxOy2 < maxOy1)))
                &&
                Intersection2D(Qr1, Qr2) == false
                )
            {
                return true;
            }
            
            return false;

        }

    }
}
