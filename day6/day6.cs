using System;

namespace aoc2016
{
    public class day6
    {
        private static char GetMostFrequentChar(string column)
        {
            int mostFrequent = 0;
            char mostFrequentChar = ' ';

            foreach (char letter in column)
            {
                int count = 0;
                foreach (char match in column)
                {
                    if (letter == match)
                    {
                        count++;
                    }
                }
                if (mostFrequent < count)
                {
                    mostFrequent = count;
                    mostFrequentChar = letter;
                }
            }

            return mostFrequentChar;
        }
        private static char GetLeastFrequentChar(string column)
        {
            int leastFrequent = 1000;
            char leastFrequentChar = ' ';

            foreach (char letter in column)
            {
                int count = 0;
                foreach (char match in column)
                {
                    if (letter == match)
                    {
                        count++;
                    }
                }
                if (leastFrequent > count)
                {
                    leastFrequent = count;
                    leastFrequentChar = letter;
                }
            }

            return leastFrequentChar;
        }
        public static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\home\projects\aoc-2016\day6\input.txt");
            string correctedMessageA = "";
            string correctedMessageB = "";
            
            for (var i = 0; i < 8; i++)
            {
                string column = "";

                foreach (string line in lines)
                {
                    column += line[i];
                }

                correctedMessageA += GetMostFrequentChar(column);
                correctedMessageB += GetLeastFrequentChar(column);
            }

            Console.WriteLine(correctedMessageA);
            Console.WriteLine(correctedMessageB);
            
        }
    }
}