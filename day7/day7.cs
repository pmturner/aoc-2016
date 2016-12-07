using System;
using System.Collections.Generic;

namespace aoc2016
{
    public class day7
    {
        private static bool IsTLS(string IP)
        {
            bool isWithinBrackets = false;
            bool isABBA = false;
            char previousChar = ' ';

            for (var i = 0; i < IP.Length; i++)
            {
                if (IP[i] == previousChar && i-2 >= 0 && i+1 < IP.Length) 
                {
                    if (IP[i-2] == IP[i+1] && IP[i+1] != IP[i])
                    {   
                        if (isWithinBrackets)
                        {
                            isABBA = false;
                            break;
                        }
                        else
                        {
                            isABBA = true;
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

            return isABBA;
        }
        private static bool IsSSL(string IP)
        {
            bool isWithinBrackets = false;
            bool hasABA = false;
            char previousChar = ' ';
            List<string> possibleSupernetABAList = new List<string>();
            List<string> possibleHypernetABAList = new List<string>();

            for (var i = 0; i < IP.Length; i++)
            {
                if (i-2 >= 0)
                {
                    if (IP[i] == IP[i-2] && IP[i] != IP[i-1])
                    {
                        string ABA = IP[i-2].ToString() + IP[i-1].ToString() + IP[i].ToString();

                        if (isWithinBrackets)
                        {
                            possibleSupernetABAList.Add(ABA);
                        }
                        else
                        {
                            possibleHypernetABAList.Add(ABA);
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
            
            if (possibleHypernetABAList.Count > 0 && possibleSupernetABAList.Count > 0)
            {
                for (var i = 0; i < possibleHypernetABAList.Count; i++)
                {
                    for (var j = 0; j < possibleSupernetABAList.Count; j++)
                    {
                        if (possibleHypernetABAList[i][1] == possibleSupernetABAList[j][2] && possibleHypernetABAList[i][2] == possibleSupernetABAList[j][1])
                        {
                            hasABA = true;
                        }
                    }
                }
            }

            return hasABA;
        }
        public static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\home\projects\aoc-2016\day7\input.txt");
            int tlsCount = 0;
            int sslCount = 0;

            foreach (string line in lines)
            {
                if (IsTLS(line))
                {
                    tlsCount++;
                }
                if (IsSSL(line))
                {
                    sslCount++;
                }
            }

            Console.WriteLine(tlsCount);
            Console.WriteLine(sslCount);
        }
    }
}