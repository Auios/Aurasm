using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuraAssembler
{
    class Program
    {
        static UInt32 curAdr; // Current address
        static Hashtable instruction;

        static void Main(string[] args)
        {
            

            Parse("JMP start");

            Console.ReadKey();
        }

        static void SetupInstructionHashTable()
        {
            instruction = new Hashtable();
            instruction["HALT"] = 0;
            instruction["SYS0"] = 16;
            instruction["SYS1"] = 17;
            instruction["AND0"] = 32;
            instruction["AND1"] = 33;
            instruction["OR0"] = 34;
            instruction["OR1"] = 35;
            instruction["XOR0"] = 36;
            instruction["XOR1"] = 37;
            instruction["NOT"] = 38;
        }

        static void Parse(string line)
        {
            line = line.Trim();
            string[] symbols = line.Split(' ');

            foreach(string symbol in symbols)
            {
                Console.WriteLine($"'{symbol}'");
            }
        }
    }
}
