using System;

namespace aoc2016
{
    public class day9
    {
        private static int GetMarkerCloseIndex(string data, int index)
        {
            int closeIndex = 0;

            for (var i = index; i < data.Length - index; i++)
            {
                if (data[i] == ')')
                {
                    closeIndex = i;
                    break;
                }
            }

            return closeIndex;
        }
        private static string ApplyMarker(string data, int copyLength, int copyMultiplier, int markerCloseIndex)
        {
            string extendedData = "";

            for (var i = 0; i < copyMultiplier; i++)
            {
                extendedData += data.Substring(markerCloseIndex+1, copyLength);
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
                    int markerCloseIndex = GetMarkerCloseIndex(data, i);

                    if (markerCloseIndex != 0)
                    {
                        string marker = data.Substring(i + 1, markerCloseIndex - i - 1);

                        int copyLength = Convert.ToInt32(marker.Split('x')[0]);
                        int copyMultiplier = Convert.ToInt32(marker.Split('x')[1]);

                        string tempString = ApplyMarker(data, copyLength, copyMultiplier, markerCloseIndex);

                        for (var j = 0; j < tempString.Length; j++)
                        {
                            if (tempString[j] == '(')
                            {
                                unwrappedString += Unwrap(tempString);
                            }
                            else
                            {
                                unwrappedString += tempString[j];
                            }
                            Console.WriteLine(unwrappedString);
                        }

                        i = markerCloseIndex + copyLength;
                    }
                }
                else
                {
                    unwrappedString += data[i];
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
