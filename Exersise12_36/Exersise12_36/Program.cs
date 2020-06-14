using System;

namespace Exersise12_36
{
    class Program
    {
        static void InsertionSort(ref int[] array)
        {
            int compares = 0, swaps = 0;

            for (int i = 1; i < array.Length; i++)
            {
                int cur = array[i];
                int j = i;
                while (j > 0 && cur < array[j - 1])
                {
                    array[j] = array[j - 1];
                    j--;

                    compares++;
                    swaps++;
                }
                array[j] = cur;

                swaps++;
            }

            Console.WriteLine("Сортировка вставками завершена с количеством сравненений элементов равным " + compares + " и с кол-вом перестановок равным " + swaps);
        }

        static void CountingSort(ref int[] array)
        {
            int compares = 0, swaps = 0;
            int max = int.MinValue, min = int.MaxValue;
            for (int i = 0; i < array.Length; i++)
            {
                max = Math.Max(max, array[i]);
                min = Math.Min(min, array[i]);
            }

            int[] data = new int[max - min + 1];

            for (int i = 0; i < array.Length; i++)
            {
                data[array[i] - min]++;
            }

            array = new int[0];
            for (int i = 0; i <= max - min; i++)
            {
                compares++;
                if (data[i] > 0)
                {
                    for (int j = 0; j < data[i]; j++)
                    {
                        Array.Resize(ref array, array.Length + 1);
                        array[array.Length - 1] = i + min;
                        swaps++;
                    }
                }
            }

            Console.WriteLine($"Сортировка подсчетом завершена с {compares} количеством сравненений элементов и с кол-вом перестановок равным " + swaps);
        }

        static void PrintArr(ref int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int[] arrayUp = new int[] {-20, -1, 1, 2, 4, 6, 7, 10, 11, 12, 13, 100};
            int[] arrayDown = new int[] { 100, 13, 12, 11, 10, 7, 6, 4, 2, 1, -1, -20 };
            int[] arrayRandom = new int[] { 0, 20, 1, -3, 170, 11, 2, 1, 40, 41, 2, 1 };
            int[] array;

            Console.WriteLine("Сортировка вставками для массива упорядоченного по возрастанию.");
            array = arrayUp;
            InsertionSort(ref array);

            Console.WriteLine("Сортировка вставками для массива упорядоченного по убыванию.");
            array = arrayDown;
            InsertionSort(ref array);

            Console.WriteLine("Сортировка вставками для массива неупорядоченного.");
            array = arrayRandom;
            InsertionSort(ref array);

            Console.WriteLine("Сортировка подсчетом для массива упорядоченного по возрастанию.");
            array = arrayUp;
            CountingSort(ref array);

            Console.WriteLine("Сортировка подсчетом для массива упорядоченного по убыванию.");
            array = arrayDown;
            CountingSort(ref array);

            Console.WriteLine("Сортировка подсчетом для массива неупорядоченного.");
            array = arrayRandom;
            CountingSort(ref array);
        }
    }
}
