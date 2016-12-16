using System;
using System.Collections.Generic;

namespace aoc2016
{
    public class day15
    {
        public static void Main(string[] args)
        {
            string[] discs = System.IO.File.ReadAllLines(@"C:\home\projects\aoc-2016\day15\input.txt");
            List<int> positions = new List<int>();
            List<int> initialPositions = new List<int>();

            foreach (string disc in discs)
            {
                string[] discBreak = disc.Split(' ');

                positions.Add(Convert.ToInt32(discBreak[3].TrimEnd('.')));
                initialPositions.Add(Convert.ToInt32(discBreak[11].TrimEnd('.')));
            }

            var timer = 0;

            for (var i = 0; i < discs.Length; i++) {
                
            }
        }
    }
}
