using System;

namespace aoc2016
{
    public class day8
    {
        private static int[,] CreateScreen(int numberOfRows, int numberOfColumns)
        {
            return new int[numberOfRows, numberOfColumns];
        }
        private static int[,] TurnOnPixels(int[,] screen, int row, int column)
        {
            for (var i = 0; i < row; i++)
            {
                for (var j = 0; j < column; j++)
                {
                    screen[i,j] = 1;
                }
            }

            return screen;
        }
        private static int[,] CopyScreen(int[,] screen){
			int[,] array = new int[screen.GetLength(0),screen.GetLength(1)];

			for (int i = 0; i < screen.GetLength(0); i++) {
				for(int j = 0; j < screen.GetLength(1); j++){
					array [i, j] = screen[i, j];
				}
			}
			return array;
		}
        public static void Display(int[,] array)
        {
            // Loop over 2D int array and display it.
            for (int i = 0; i <= array.GetUpperBound(0); i++)
            {
                for (int x = 0; x <= array.GetUpperBound(1); x++)
                {
                Console.Write(array[i, x]);
                Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        private static int[,] RotateRowRight(int[,] screen, int row, int rotateValue)
        {
            int max = screen.GetLength(1);
            int[,] array = CopyScreen(screen);
            
            for (var i = 0; i < max; i++)
            {
                array[row, (i + rotateValue) % max] = screen[row, i];
            }

            return array;
        }
        private static int[,] RotateColumnDown(int[,] screen, int column, int rotateValue)
        {
            int max = screen.GetLength(0);
            int[,] array = CopyScreen(screen);

            for (var i = 0; i < max; i++)
            {
                array[(i + rotateValue) % max, column] = screen[i, column];
            }

            return array;
        }
        private static int GetNonZeroArrayElementCount(int[,] array)
        {
            int numberOfRows = array.GetLength(0);
            int numberOfColumns = array.GetLength(1);
            int count = 0;

            for (var i = 0; i < numberOfRows; i++)
            {
                for (var j = 0; j < numberOfColumns; j++)
                {
                    if (array[i,j] == 1)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
        public static void Main(string[] args)
        {
            int[,] screen = CreateScreen(6, 50);
            string[] instructions = System.IO.File.ReadAllLines(@"C:\home\projects\aoc-2016\day8\input.txt");

            foreach (string instruction in instructions)
            {
                string[] instructionWords = instruction.Split(' ');
                
                if (instructionWords[0] == "rect")
                {
                    string[] values = instructionWords[1].Split('x');
                    screen = TurnOnPixels(screen, Convert.ToInt32(values[1]), Convert.ToInt32(values[0]));
                }
                else
                {
                    if (instructionWords[1] == "row")
                    {
                        string[] values = {instructionWords[2].Split('=')[1], instructionWords[4]};
                        screen = RotateRowRight(screen, Convert.ToInt32(values[0]), Convert.ToInt32(values[1]));
                    }
                    else
                    {
                        string[] values = {instructionWords[2].Split('=')[1], instructionWords[4]};
                        screen = RotateColumnDown(screen, Convert.ToInt32(values[0]), Convert.ToInt32(values[1]));
                    }
                }
            }

            int pixelCount = GetNonZeroArrayElementCount(screen);

            Console.WriteLine(pixelCount);
            Display(screen);
        }
    }
}