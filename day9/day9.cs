using System;

namespace aoc2016
{
    public class day9
    {
        public static void Main(string[] args)
        {
            string data = System.IO.File.ReadAllText(@"C:\home\projects\aoc-2016\day9\input.txt");
            string decompressedData = "";

            for (var i = 0; i < data.Length; i++)
            {
                if (data[i] != "(")
                {
                    decompressedData += data[i];
                }
                else
                {
                    
                }
            }
            Console.WriteLine(data);
        }
    }
}
