using System;

namespace Exersise5_397b
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[10, 10];
            int max = int.MinValue;
            bool isFound = false;

            try
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        matrix[i, j] = int.Parse(Console.ReadLine());
                    }
                }
            }
            catch
            {
                Console.WriteLine("Ошибка ввода");
                return;
            }
            for (int i = 0; i < 10; i++)
            {
                if (matrix[i, i] < 0)
                {
                    isFound = true;
                    max = int.MinValue;
                    for (int j = 0; j < 10; j++)
                    {
                        max = Math.Max(max, matrix[i, j]);
                    }
                    Console.WriteLine("В строке " + (i + 1) + " максимум равен: " + max);
                }
            }

            if (!isFound)
            {
                Console.WriteLine("Подходящих строк не найдено");
            }
        }
    }
}
