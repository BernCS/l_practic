using System;

namespace Dates
{
    class Date
    {
        private int[] lengthMonths = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        private string[] daysOfWeek = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        private int year, month, day;
        private int dayOfWeek;

        public Date()
        {
            year = 2008;
            dayOfWeek = 1;
            month = 0;
            day = 1;
        }

        public void Inc()
        {
            dayOfWeek = (dayOfWeek + 1) % 7;
            day++;
            if (year % 4 == 0 && month == 1)
            {
                if (day > lengthMonths[month] + 1)
                {
                    day = 1;
                    month++;
                }
            }
            else
            {
                if (day > lengthMonths[month])
                {
                    day = 1;
                    month++;
                }
            }
            if (month > 11)
            {
                year++;
                month = 0;
            }
        }

        public void Print()
        {
            Console.Write(daysOfWeek[dayOfWeek] + ", ");
            if (day < 10)
                Console.Write("0" + day);
            else
                Console.Write(day);

            if (month < 9)
                Console.Write(".0" + (month + 1));
            else
                Console.Write("." + (month + 1));
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Date date = new Date();

            for (int i = 0; i < num; i++)
            {
                date.Inc();
            }

            date.Print();
        }
    }
}
