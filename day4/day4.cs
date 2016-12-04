using System;

namespace aoc2016
{
    public class day4
    {
        public static void Main(string[] args)
        {
            string[] encryptedLines = System.IO.File.ReadAllLines(@"C:\home\projects\aoc-2016\day4\input.txt");
            int sectorIDSum = 0;

            foreach (string line in encryptedLines)
            {
                string checksum = line.Substring(line.Length - 6, 5);
                bool isReal = true;

                // dummy values
                int previousCount = 100;
                decimal previousLetter = 65;

                for (var i = 0; i < 5; i++)
                {
                    int count = line.Split(checksum[i]).Length - 2;
                    decimal currentLetter = System.Convert.ToDecimal(checksum[i]);

                    if (count == 0 || count > previousCount)
                    {
                        isReal = false;
                    }

                    if (count == previousCount)
                    {
                        // not alphabetical order
                        if (currentLetter < previousLetter)
                        {
                            isReal = false;
                        }
                    }

                    previousCount = count;
                    previousLetter = currentLetter;
                }


                if (isReal)
                {
                    int IDFrom = line.LastIndexOf("-") + "-".Length;
                    int IDTo = line.LastIndexOf("[");
                    int sectorID = Int32.Parse(line.Substring(IDFrom, IDTo - IDFrom));
                    
                    sectorIDSum += sectorID;
                    
                    string decryptedMessage = "";

                    for (var i = 0; i < line.Length; i++)
                    {
                        if (Char.IsLetter(line[i]))
                        {
                            decryptedMessage += DecryptLetter(line[i], sectorID);
                        }
                        else if (!Char.IsLetterOrDigit(line[i]))
                        {
                            decryptedMessage += " ";
                        }
                        else if (Char.IsNumber(line[i]))
                        {
                            break;
                        }
                    }

                    if (decryptedMessage.Contains("object"))
                    {
                        Console.WriteLine(decryptedMessage + System.Convert.ToString(sectorID));
                    }
                }
                
            }

            Console.WriteLine(sectorIDSum);
        }
        private static char DecryptLetter(char letter, int shiftValue)
        {
            var alphabet = "abcdefghijklmnopqrstuvwxyz";
            return alphabet[(alphabet.IndexOf(letter) + shiftValue) % 26];
        }
    }
}