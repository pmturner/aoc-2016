using System;
using System.Text;

namespace aoc2016
{
    public class day12
    {
        private static int GetRegisterOrIntegerValue(int[] registers, string breakValue)
        {
            char[] registerSet = new char[] {'a', 'b', 'c', 'd'};
            int integerValue = 0;

            if (int.TryParse(breakValue, out integerValue))
            {
                integerValue = Convert.ToInt32(breakValue);
            } else {
                for (var j = 0; j < registerSet.Length; j++)
                {
                    if (Char.ToString(registerSet[j]) == breakValue) 
                    {
                        integerValue = registers[j];
                    }
                }
            }

            return integerValue;
        }
        private static int GetRegisterIndex(string copyRegister)
        {
            char[] registerSet = new char[] {'a', 'b', 'c', 'd'};

            for (var j = 0; j < registerSet.Length; j++)
            {
                if (copyRegister == Char.ToString(registerSet[j]))
                {
                    return j;
                }
            }

            return Convert.ToInt32(copyRegister);
        }
        public static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"C:\home\projects\aoc-2016\day12\input.txt");
            int[] registers = new int[] {0,0,1,0};
            int registerIndex = 0;

            for (var i = 0; i < input.Length; i++) 
            {
                string[] instructionBreak = input[i].Split(' ');

                switch (instructionBreak[0])
                {
                    case "cpy":
                        int copyValue = GetRegisterOrIntegerValue(registers, instructionBreak[1]);
                        // Console.WriteLine(copyValue);
                        registerIndex = GetRegisterIndex(instructionBreak[2]);
                        registers[registerIndex] = copyValue;
                        break;
                    case "inc":
                        registerIndex = GetRegisterIndex(instructionBreak[1]);
                        registers[registerIndex]++;
                        break;
                    case "dec":
                        registerIndex = GetRegisterIndex(instructionBreak[1]);
                        registers[registerIndex]--;
                        break;
                    case "jnz":
                        registerIndex = GetRegisterIndex(instructionBreak[1]);
                        int movement = i + Convert.ToInt32(instructionBreak[2]);
                        if (registers[registerIndex] != 0 && movement < input.Length && movement > 0)
                        {
                            i = movement - 1;
                        }
                        break;
                }
            }

            Console.WriteLine(registers[0]);
        }
    }
}
