using System;
using System.Collections.Generic;
using System.IO;

namespace Agent
{
    public class Pair : IComparable<Pair>
    {
        public int First { get; set; }
        public int Second { get; set; }

        public Pair(int first, int second)
        {
            First = first;
            Second = second;
        }

        public int CompareTo(Pair pair)
        {
            if (First > pair.First)
                return 1;
            else if (First < pair.First)
                return -1;
            else
                return 0;
        }
    }

    class Program
    {
        static string[] DeleteEmpty(string[] line)
        {
            string[] newLine = new string[0];
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] != "")
                {
                    Array.Resize(ref newLine, newLine.Length + 1);
                    newLine[newLine.Length - 1] = line[i];
                }
            }
            return newLine;
        }


        static void Main(string[] args)
        {
            StreamReader streamReader = new StreamReader("INPUT.TXT");
            StreamWriter streamWriter = new StreamWriter("OUTPUT.TXT");

            int n = Convert.ToInt32(streamReader.ReadLine());

            Pair[] agentInfos = new Pair[n];
            long[] dp = new long[10100];

            string[] line = streamReader.ReadLine().Split(new char[] { ' ' });

            if (n != line.Length / 2)
                line = DeleteEmpty(line);

            for (int i = 0; i < n; i++)
            {
                agentInfos[i] = new Pair(Convert.ToInt32(line[2 * i]), Convert.ToInt32(line[2 * i + 1]));
            }

            Array.Sort(agentInfos);

            dp[1] = agentInfos[1].Second;
            dp[2] = (n > 2) ? agentInfos[1].Second + agentInfos[2].Second : 0;
            dp[3] = (n > 3) ? agentInfos[1].Second + agentInfos[3].Second : 0;

            for (int i = 4; i < n; i++)
            {
                dp[i] = Math.Min(dp[i - 2] + agentInfos[i].Second, dp[i - 3] + agentInfos[i].Second + agentInfos[i - 1].Second);
            }

            streamWriter.WriteLine(dp[n - 1]);
            streamWriter.Close();
        }
    }
}