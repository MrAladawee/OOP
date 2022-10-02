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

    public void print_dot(dots z)
    {
        Console.WriteLine("({0},{1},{2})", z.Ox, z.Oy, z.Oz);
    }

    public void dist_task1(dots z1, dots z2)
    {
        Console.WriteLine("Расстояние между z1 и z2 = {0}", Math.Sqrt(Math.Pow((z2.Ox - z1.Ox), 2) + Math.Pow((z2.Oy - z1.Oy), 2) + Math.Pow((z2.Oz - z1.Oz), 2)));
    }

    public void line_task2(dots z1, dots z2)
    {
        Console.WriteLine("x - {0} / {1} == y - {2} / {3} == z - {4} / {5}", z1.Ox, z2.Ox - z1.Ox, z1.Oy, z2.Oy - z1.Oy, z1.Oz, z2.Oz - z1.Oz);
    }

    public void plot_task3(dots z1, dots z2, dots z3)
    {
        Console.WriteLine("{1}*x + {3}*y + {5}*z + ( (-1)*({0}*{1} + {2}*{3} + {4}*{5}) ) = 0", z1.Ox, (z2.Oy - z1.Oy) * (z3.Oz - z1.Oz) - (z2.Oz - z1.Oz) * (z3.Oy - z1.Oy),
            z1.Oy, (-1) * (z2.Ox - z1.Ox) * (z3.Oz - z1.Oz) - (z2.Oz - z1.Oz) * (z3.Ox - z1.Ox),
            z1.Oz, (z2.Ox - z1.Ox) * (z2.Oy - z1.Oy) - (z3.Oz - z1.Oz) * (z3.Ox - z1.Ox));
    }

    public void dist_task4(dots z1)
    {
        Console.WriteLine("Расстояние между z1 и (0,0,0) = {0}", Math.Sqrt(Math.Pow((z1.Ox), 2) + Math.Pow((z1.Oy), 2) + Math.Pow((z1.Oz), 2)));
    }

    public dots sumvec_task5(dots z1, dots z2)
    {
        dots z3 = new dots();
        z3.Ox = z1.Ox + z2.Ox;
        z3.Oy = z1.Oy + z2.Oy;
        z3.Oz = z1.Oz + z2.Oz;
        return z3;
    }

    public double scalar_task6(dots p1, dots p2)
    {
        return p1.Ox*p2.Ox + p1.Oy*p2.Oy + p1.Oz*p2.Oz;
    }

    public void vector_task6(dots p1, dots p2)
    {
        double coef_1 = p1.Oy * p2.Oz - p2.Oy * p1.Oz;
        double coef_2 = p1.Ox * p2.Oz - p2.Ox * p1.Oz;
        double coef_3 = p1.Ox * p2.Oy - p2.Ox * p1.Oy;

        Console.WriteLine("p1 x p2 = {0}*i - {1}*j + {2}*k", coef_1, coef_2, coef_3);

    }

}
