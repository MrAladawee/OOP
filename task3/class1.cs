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

    public static dots operator + (dots A, dots B)
    {
        return new(A.ox + B.ox, A.oy + B.oy, A.oz + B.oz);
    }
    public static dots operator - (dots A, dots B)
    {
        return new(A.ox - B.ox, A.oy - B.oy, A.oz - B.oz);
    }
    public static bool operator / (dots A, dots B)
    {
        return A.ox / B.ox >= 0 && A.oy / B.oy >= 0;
    }
    public static double operator * (dots A, dots B)
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

    public static void Line(dots z1, dots z2)
    {
        Console.WriteLine("x - {0} / {1} == y - {2} / {3} == z - {4} / {5}", z1.Ox, z2.Ox - z1.Ox, z1.Oy, z2.Oy - z1.Oy, z1.Oz, z2.Oz - z1.Oz);
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

    public static double scalar(dots p1, dots p2)
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

    public static bool Equasion3D(dots A, dots B, dots C, dots D)
    {
        return ((D.ox - A.ox) * ((B.oy - A.oy) * (C.oz - A.oz) - (C.oy - A.oy) * (B.oz - A.oz))
            - (D.oy - A.oy) * ((B.ox - A.ox) * (C.oz - A.oz) - (B.oz - A.oz) * (C.ox - A.ox))
            + (D.oz - A.oz) * ((B.ox - A.ox) * (C.oy - A.oy) - (B.oy - A.oy) * (C.ox - A.ox)) == 0);
    }

    public static double Angle(dots A, dots B)
    {
        double numerator = A.ox * B.ox + A.oy * B.oy + A.oz * B.oz;
        double denominator = Math.Sqrt(Math.Pow(A.ox, 2) + Math.Pow(A.oy, 2) + Math.Pow(A.oz, 2)) * Math.Sqrt(Math.Pow(B.ox, 2) + Math.Pow(B.oy, 2) + Math.Pow(B.oz, 2));
        return Math.Acos(numerator / denominator);
    }

}
