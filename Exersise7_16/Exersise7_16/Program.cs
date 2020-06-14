using System;

namespace Exersise7_16
{
    class Program
    {
        static int n, k;
        static int[] nums = new int[0];
        static int[] ans = new int[0];
        static bool[] used = new bool[0];

        static void Rec(int j)
        {
            if (j == k)
            {
                for (int i = 0; i < k; i++)
                {
                    Console.Write(ans[i] + " ");
                }
                Console.WriteLine();
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    ans[j] = nums[i];
                    Rec(j + 1);
                    used[i] = false;
                }
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите кол-во элементов: ");
                n = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите размер сочетания: ");
                k = int.Parse(Console.ReadLine());

                if (k <= 0 || n <= 0)
                {
                    Console.WriteLine("Ошибка ввода.");
                    return;
                }
            }
            catch
            {
                Console.WriteLine("Ошибка ввода.");
                return;
            }

            if (k > n)
            {
                Console.WriteLine("Ошибка ввода.");
                return;
            }

            nums = new int[n];
            used = new bool[n];
            ans = new int[k];

            Console.WriteLine($"Введите {n} элементов: ");
            for (int i = 0; i < n; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
            }

            Rec(0);
        }
    }
}
