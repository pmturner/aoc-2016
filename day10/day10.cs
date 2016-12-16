using System;

namespace aoc2016
{
    public class day10
    {
        public static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\home\projects\aoc-2016\day10\input.txt");
            int highValueTarget = 61;
            int lowValueTarget = 17;

            foreach(string line in lines)
            {
                string[] lineItem = line.Split(' ');
                
                if (lineItem[0] == "value")
                {
                    GiveValueToBot(lineItem[1], lineItem[5]);
                }
                else
                {
                    BotProcess(lineItem);;
                }
            }
        }
    }
}
