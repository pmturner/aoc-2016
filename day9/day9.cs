using System;

namespace aoc2016
{
    public class day9
    {
        private static string ApplyMarker(string data, int copyLength, int copyMultiplier, int index, int intMarkerLength)
        {
            string extendedData = "";

            for (var i = 0; i < copyMultiplier; i++)
            {
                extendedData += data.Substring(index + intMarkerLength, copyLength);
            }

            return extendedData;
        }
        private static string Unwrap(string data)
        {
            string unwrappedString = "";

            for (var i = 0; i < data.Length; i++)
            {
                if (data[i] == '(')
                {
                    int copyLength = Convert.ToInt32(data.Substring(i + 1, data.IndexOf('x', i) - i - 1));
                    int copyMultiplier = Convert.ToInt32(data.Substring(data.IndexOf('x', i) + 1, data.IndexOf(')', i) - data.IndexOf('x', i) - 1));
                    
                    int markerLength = copyMultiplier.ToString().Length + copyLength.ToString().Length + 3;
                    
                    unwrappedString += ApplyMarker(data, copyLength, copyMultiplier, i, markerLength);

                    i += markerLength + copyLength - 1;
                }
            }

            return unwrappedString;
        }
        public static void Main(string[] args)
        {
            string data = System.IO.File.ReadAllText(@"C:\home\projects\aoc-2016\day9\input.txt");
            string decompressedData = Unwrap(data);

            Console.WriteLine(decompressedData.Length);
        }
    }
}