using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dots_class;

public class dots
{
    private double ox;
    private double oy;
    private double oz;

    public double Ox
    { get => ox; set { ox = value; } }

    public double Oy
    { get => oy; set { oy = value; } }

    public double Oz
    { get => oz; set { oz = value; } }

    public dots()
    {
        this.ox = 0;
        this.oy = 0;
        this.oz = 0;
    }

    public dots(double Ox, double Oy, double Oz)
    {
        this.ox = Ox;
        this.oy = Oy;
        this.oz = Oz;
    }

    public static dots operator +(dots A, dots B)
    {
        return new(A.ox + B.ox, A.oy + B.oy, A.oz + B.oz);
    }
    public static dots operator -(dots A, dots B)
    {
        return new(A.ox - B.ox, A.oy - B.oy, A.oz - B.oz);
    }
    public static bool operator /(dots A, dots B)
    {
        return A.ox / B.ox >= 0 && A.oy / B.oy >= 0;
    }
    public static double operator *(dots A, dots B)
    {
        return A.ox * B.ox + A.oy * B.oy + A.oz * B.oz;
    }

    public void printDot(dots z)
    {
        Console.WriteLine("({0},{1},{2})", z.Ox, z.Oy, z.Oz);
    }

    public static double Dist(dots z1, dots z2)
    {
        return Math.Sqrt(Math.Pow((z2.Ox - z1.Ox), 2) + Math.Pow((z2.Oy - z1.Oy), 2) + Math.Pow((z2.Oz - z1.Oz), 2));
    }

    public static double convRad(int x)
    {
        return (x * Math.PI) / 180;
    }
    public static double convGrad(double x)
    {
        return (x * 180) / Math.PI;
    }

    public static void Line3D(dots z1, dots z2)
    {
        Console.WriteLine("x - {0} / {1} == y - {2} / {3} == z - {4} / {5}", z1.Ox, z2.Ox - z1.Ox, z1.Oy, z2.Oy - z1.Oy, z1.Oz, z2.Oz - z1.Oz);
    }
    
    public static double[] Line2Dcoef(dots A, dots B)
    {
        double[] result = new double[3];
        result[0] = B.oy - A.oy;
        result[1] = (B.ox - A.ox) * (-1);
        result[2] = A.oy*B.ox - B.oy*A.ox;
        return result;
    }

    public static bool Intersection2D(double[] Line1, double[] Line2)
    {

        if (Line1[0]/Line2[0] == Line1[1]/Line2[1])
        {
            return false; // parallel
        }

        else if (Line1[0]*Line2[1] - Line2[0]*Line1[1] == 0 && Line2[2]*Line1[1] - Line1[2]*Line2[1] == 0)
        {
            return false; // including
        }

        return true;
    }

    public static double IntersectionLine2D(double[] Line1, double[] Line2)
    {
        double ResultOx;

        ResultOx = (Line1[2]*Line2[1] - Line2[2]*Line1[1]) / (Line2[0]*Line1[1] - Line1[0]*Line2[1]);

        return ResultOx;
    }

    public static bool IntersectionSegments2D(dots A1, dots A2, dots B1, dots B2)
    {
        double[] line1 = Line2Dcoef(A1, A2);
        double[] line2 = Line2Dcoef(B1, B2);

        if (Intersection2D(line1, line2) == true)
        {

            double intersectionOx = IntersectionLine2D(line1, line2);

            if (((intersectionOx < A2.ox && intersectionOx > A1.ox) || (intersectionOx < A1.ox && intersectionOx > A2.ox)) &&
                ((intersectionOx < B2.ox && intersectionOx > B1.ox) || (intersectionOx < B1.ox && intersectionOx > B2.ox)))
            {
                return true;
            }

            return false;
        }

        return false;
    }

    public static void Plot(dots z1, dots z2, dots z3)
    {
        Console.WriteLine("{1}*x + {3}*y + {5}*z + ( (-1)*({0}*{1} + {2}*{3} + {4}*{5}) ) = 0", z1.Ox, (z2.Oy - z1.Oy) * (z3.Oz - z1.Oz) - (z2.Oz - z1.Oz) * (z3.Oy - z1.Oy),
            z1.Oy, (-1) * (z2.Ox - z1.Ox) * (z3.Oz - z1.Oz) - (z2.Oz - z1.Oz) * (z3.Ox - z1.Ox),
            z1.Oz, (z2.Ox - z1.Ox) * (z2.Oy - z1.Oy) - (z3.Oz - z1.Oz) * (z3.Ox - z1.Ox));
    }

    public static double distStart(dots z1)
    {
        return Math.Sqrt(Math.Pow((z1.Ox), 2) + Math.Pow((z1.Oy), 2) + Math.Pow((z1.Oz), 2));
    }

    public dots SumVec(dots z1, dots z2)
    {
        dots z3 = new dots();
        z3.Ox = z1.Ox + z2.Ox;
        z3.Oy = z1.Oy + z2.Oy;
        z3.Oz = z1.Oz + z2.Oz;
        return z3;
    }

    public static double Scalar(dots p1, dots p2)
    {
        return p1.Ox * p2.Ox + p1.Oy * p2.Oy + p1.Oz * p2.Oz;
    }

    public static void printVector(dots p1, dots p2)
    {
        double coef_1 = p1.Oy * p2.Oz - p2.Oy * p1.Oz;
        double coef_2 = p1.Ox * p2.Oz - p2.Ox * p1.Oz;
        double coef_3 = p1.Ox * p2.Oy - p2.Ox * p1.Oy;

        Console.WriteLine("p1 x p2 = {0}*i - {1}*j + {2}*k", coef_1, coef_2, coef_3);

    }

    public static dots Vector(dots A, dots B)
    {
        dots Vec = new dots();
        Vec.Ox = B.Ox - A.Ox;
        Vec.Oy = B.Oy - A.Oy;
        Vec.Oz = B.Oz - A.Oz;
        return Vec;
    }

    public static bool Equasion(dots A, dots B, dots C, dots D)
    {
        return ((D.ox - A.ox) * ((B.oy - A.oy) * (C.oz - A.oz) - (C.oy - A.oy) * (B.oz - A.oz))
            - (D.oy - A.oy) * ((B.ox - A.ox) * (C.oz - A.oz) - (B.oz - A.oz) * (C.ox - A.ox))
            + (D.oz - A.oz) * ((B.ox - A.ox) * (C.oy - A.oy) - (B.oy - A.oy) * (C.ox - A.ox)) == 0);
    }

    public static double Angle(dots A, dots B)
    {
        double chis = A.ox * B.ox + A.oy * B.oy + A.oz * B.oz;
        double znam = Math.Sqrt(Math.Pow(A.ox, 2) + Math.Pow(A.oy, 2) + Math.Pow(A.oz, 2)) * Math.Sqrt(Math.Pow(B.ox, 2) + Math.Pow(B.oy, 2) + Math.Pow(B.oz, 2));
        return Math.Acos(chis / znam);
    }

    public static double VectorMlp(dots A, dots B)
    {
        return (A.ox * B.oy - B.ox * A.oy);
    }

}
