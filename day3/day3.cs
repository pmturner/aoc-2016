using System;

namespace aoc2016
{
    public class day3
    {
        private static bool isValidTriangle(int[] triangle)
        {
            return (triangle[0] + triangle[1] > triangle[2] && triangle[1] + triangle[2] > triangle[0] && triangle[0] + triangle[2] > triangle[1]);
        }
        public static void Main(string[] args)
        {
            string[] triangles = System.IO.File.ReadAllLines(@"C:\home\projects\aoc-2016\day3\input.txt");
            int counterA = 0;

            // Part 1
            foreach (string triangle in triangles)
            {
                int sideA = Int32.Parse(triangle.Substring(0, 5));
                int sideB = Int32.Parse(triangle.Substring(5, 5));
                int sideC = Int32.Parse(triangle.Substring(10, 5));

                int[] maybeTriangle = new int[3] {sideA, sideB, sideC};

                if (isValidTriangle(maybeTriangle))
                {
                    counterA++;
                }

            }

            Console.WriteLine(counterA);

            // Part 2
            int counterB = 0;
            int sideCount = 0;
            int[] vertTriangle = new int[3];
    
            for (int i = 0; i < 3; i++)
            {
                foreach (string triangle in triangles)
                {
                    string[] oldTriangle = triangle.Split(" ".ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries);

                    vertTriangle[sideCount] = int.Parse(oldTriangle[i]);
                    sideCount++;

                    if (sideCount == 3)
                    {
                        if (isValidTriangle(vertTriangle))
                        {
                            counterB++;
                        }
                        
                        sideCount = 0;
                    }

                }
            }
            
            Console.WriteLine(counterB);
        }
    }
}
