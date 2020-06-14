using System;

namespace Exersise10_15
{
    public class Node
    {
        public int Data;
        public Node Next;
        public Node Previous;
        public bool isRemoved = false;

        public Node(int data, Node previous)
        {
            Data = data;
            Next = null;
            Previous = previous;
        }

        public Node(Node previous)
        {
            Data = default(int);
            Next = null;
            Previous = previous;
        }

        private Node Head()
        {
            if (Previous == null)
                return this;
            return Previous.Head();
        }

        public void MakeNode(int curData, int n)
        {
            if (curData == n)
            {
                Node head = Head();
                head.Previous = this;
                this.Next = head;
                this.Data = curData;
                return;
            }

            Data = curData;
            Next = new Node(this);
            Next.MakeNode(curData + 1, n);
        }

        public void Ex(int n, int m)
        {
            Node curNode = this.Previous;
            for (int i = 0; i < n; i++)
            {
                int j = 0;
                while (j < m)
                {
                    if (!curNode.Next.isRemoved)
                    {
                        curNode = curNode.Next;
                        j++;
                    }
                    else
                    {
                        curNode = curNode.Next;
                    }
                }
                curNode.isRemoved = true;
            }
            Console.WriteLine(curNode.Data);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Node node = new Node(null);
                Console.WriteLine("Введите кол-во людей: ");
                int n = int.Parse(Console.ReadLine());
                if (n <= 0)
                {
                    Console.WriteLine("Ошибка ввода");
                    return;
                }
                node.MakeNode(1, n);

                Console.WriteLine("Введите кол-во людей: ");
                int m = int.Parse(Console.ReadLine());
                if (m <= 0)
                {
                    Console.WriteLine("Ошибка ввода");
                    return;
                }
                node.Ex(n, m);
            }
            catch
            {
                Console.WriteLine("Ошибка ввода");
                return;
            }
        }
    }
}
