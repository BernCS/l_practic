using System;

namespace Exersise3_60e
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите x и y");
            double x;
            double y;
            try
            {
                x = double.Parse(Console.ReadLine());
                y = double.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Ошибка ввода");
                return;
            }
            double u = 0;

            if (y >= Math.Round(x * x, 9) && y <= Math.Pow(Math.E, -x) && y <= Math.Pow(Math.E, x))
                u = x + y;
            else
                u = x - y;

            Console.WriteLine(Math.Round(u, 9));
        }
    }
}
