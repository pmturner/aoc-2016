using System;
using System.Security.Cryptography;
using System.Text;

namespace aoc2016
{
    public class day5
    {
        public static void Main(string[] args)
        {
            string doorID = "ffykfhsq";
            string passwordA = "";
            string[] passwordB = new string[8] {"-","-","-","-","-","-","-","-"};
            int index = 0;

            using (MD5 md5Hash = MD5.Create())
            {   
                while (Array.IndexOf(passwordB, "-") > -1)
                {
                    string hash = GetMD5Hash(md5Hash, doorID + index.ToString());
                    
                    if (hash.Substring(0,5) == "00000")
                    {
                        if (passwordA.Length < 8)
                        {
                            passwordA += hash[5];
                        }

                        if (Char.IsNumber(hash[5]))
                        {
                            int hashPosition = Convert.ToInt32(hash[5].ToString());
                            
                            if (hashPosition < 8 && passwordB[hashPosition] == "-")
                            {
                                passwordB[hashPosition] = hash[6].ToString();
                            }
                        }
                    }
                    
                    index++;
                }
            }

            Console.WriteLine(passwordA);
            Console.WriteLine(string.Join("", passwordB));
        }
        // from mdsn
        private static string GetMD5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}