using System;
using System.Collections.Generic;

namespace aoc2016
{
    public class day7
    {
        private static bool IsABBA(string IP)
        {
            bool isWithinBrackets = false;
            bool hasTLS = false;
            char previousChar = ' ';

            for (var i = 0; i < IP.Length; i++)
            {
                if (IP[i] == previousChar) 
                {
                    if (i-2 >= 0 && i+1 < IP.Length)
                    {   
                        if (IP[i-2] == IP[i+1] && IP[i+1] != IP[i])
                        {   
                            if (isWithinBrackets)
                            {
                                hasTLS = false;
                                break;
                            }
                            else
                            {
                                hasTLS = true;
                            }
                        }
                    }
                }

                if (IP[i].ToString() == "[")
                {
                    isWithinBrackets = true;
                }
                if (IP[i].ToString() == "]")
                {
                    isWithinBrackets = false;
                }

                previousChar = IP[i];
            }

            return hasTLS;
        }
        private static bool IsSSL(string IP)
        {
            bool isWithinBrackets = false;
            bool hasSSL = false;
            char previousChar = ' ';
            List<string> possibleSupernetABAs = new List<string>();
            List<string> possibleHypernetABAs = new List<string>();

            for (var i = 0; i < IP.Length; i++)
            {
                if (i-2 >= 0)
                {
                    if (IP[i] == IP[i-2] && IP[i] != IP[i-1])
                    {
                        string ABA = IP[i-2].ToString() + IP[i-1].ToString() + IP[i].ToString();

                        if (isWithinBrackets)
                        {
                            possibleSupernetABAs.Add(ABA);
                        }
                        else
                        {
                            possibleHypernetABAs.Add(ABA);
                        }
                    }
                }

                if (IP[i].ToString() == "[")
                {
                    isWithinBrackets = true;
                }
                if (IP[i].ToString() == "]")
                {
                    isWithinBrackets = false;
                }

                previousChar = IP[i];
            }
            
            if (possibleHypernetABAs.Count > 0 && possibleSupernetABAs.Count > 0)
            {
                for (var i = 0; i < possibleHypernetABAs.Count; i++)
                {
                    for (var j = 0; j < possibleSupernetABAs.Count; j++)
                    {
                        if (possibleHypernetABAs[i][1] == possibleSupernetABAs[j][2] && possibleHypernetABAs[i][2] == possibleSupernetABAs[j][1])
                        {
                            hasSSL = true;
                        }
                    }
                }
            }

            return hasSSL;
        }
        public static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\home\projects\aoc-2016\day7\input.txt");
            int abbaCount = 0;
            int sslCount = 0;

            foreach (string line in lines)
            {
                if (IsABBA(line))
                {
                    abbaCount++;
                }
                if (IsSSL(line))
                {
                    sslCount++;
                }
            }

            Console.WriteLine(abbaCount);
            Console.WriteLine(sslCount);
        }
    }
}