using System;
using System.IO;

namespace Exersise11_838
{
    class Program
    {
        static void Rotate90(int count, ref int[,] matrix)
        {
            int[,] newMatrix = new int[10, 10];
            for (int k = 0; k < count; k++)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        newMatrix[j, 9 - i] = matrix[i, j];
                    }
                }
            }

            matrix = newMatrix;
        }

        static string[] DivideWord(string word, int count)
        {
            string[] words = new string[count * 4];
            int temp = word.Length / count / 4;
            for (int i = 0; i < count * 4; i++)
            {
                if (i != count * 4 - 1)
                {
                    words[i] = word.Substring(0, temp);
                    word = word.Substring(temp);
                }
                else
                {
                    words[i] = word;
                }
            }
            return words;
        }

        static string[,] Crypt(string word, int[,] key)
        {
            int zeroCount = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    zeroCount = zeroCount + (key[i, j] == 0 ? 1 : 0);
                }
            }

            string[] words = DivideWord(word, zeroCount);
            string[,] cryptedMatrix = new string[10, 10];
            int wordIndex = 0;

            for (int k = 0; k < 4; k++)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (key[i, j] == 0)
                        {
                            cryptedMatrix[i, j] = words[wordIndex];
                            wordIndex++;
                        }
                    }
                }
                Rotate90(1, ref key);
            }

            return cryptedMatrix;
        }

        static string DeCrypt(string[,] cryptedMatrix, int[,] key)
        {
            string word = "";

            for (int k = 0; k < 4; k++)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (key[i, j] == 0)
                        {
                            word += cryptedMatrix[i, j];
                        }
                    }
                }
                Rotate90(1, ref key);
            }

            return word;
        }

        static void Main(string[] args)
        {
            int[,] matrix = new int[10, 10];
            string[,] cryptedMatrix = new string[10, 10];
            string word;

            StreamReader streamReader = new StreamReader("input.txt");
            try
            {
                word = streamReader.ReadLine();
                if (word.Length != 100)
                {
                    Console.WriteLine("Ошибка ввода");
                    return;
                }

                for (int i = 0; i < 10; i++)
                {
                    string[] line = streamReader.ReadLine().Split(new char[] { ' ' });
                    for (int j = 0; j < 10; j++)
                    {
                        matrix[i, j] = Convert.ToInt32(line[j]);
                        if (matrix[i, j] != 0 && matrix[i, j] != 1)
                        {
                            Console.WriteLine("Ошибка ввода");
                            return;
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Ошибка ввода");
                return;
            }

            cryptedMatrix = Crypt(word, matrix);

            Console.WriteLine("Зашифрованное слово: ");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (cryptedMatrix[i, j] != null)
                    {
                        Console.Write(cryptedMatrix[i, j] + " ");
                    }
                    else
                    {
                        Console.Write("_ ");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("Расшифрованное слово: " + DeCrypt(cryptedMatrix, matrix));

            /*matrix = Rotate90(1, matrix);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }*/

        }
    }
}
