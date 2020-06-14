using System;

namespace Exersise4_725e
{

    class Program
    {
        static double e = 1e-3;

        static double F(double x)
        {
            return Math.Pow(x, 4.0) + 0.8 * Math.Pow(x, 3.0) - 0.4 * Math.Pow(x, 2.0) - 1.4 * x - 1.2;
        }

        static double FindClosest(double left, double right)
        {
            if (right - left < e)
            {
                return right;
            }

            double midRight = F((3 * right + left) / 4);
            double midLeft = F((right + 3 * left) / 4);

            if (Math.Abs(midLeft) < Math.Abs(midRight))
                return FindClosest(left, (right + left) / 2);
            else
                return FindClosest((right + left) / 2, right);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите погрешность: ");
            try
            {
                e = double.Parse(Console.ReadLine());
                if (e <= 0)
                {
                    Console.WriteLine("Ошибка ввода");
                    return;
                }
            }
            catch 
            {
                Console.WriteLine("Ошибка ввода");
                return;
            }
            double ans = FindClosest(-1.2, -0.5);
            Console.WriteLine(ans);
        }
    }
}
