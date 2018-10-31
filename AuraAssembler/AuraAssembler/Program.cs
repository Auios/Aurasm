using System;
using System.Collections;
using System.Collections.Generic;

namespace AuraAssembler
{
    class Program
    {
        static UInt32 curAdr; // Current address
        static Hashtable instruction;
        static List<Label> labels;

        static void Main(string[] args)
        {
            Init();

            Parse("JMP start");

            Console.ReadKey();
        }

        static void Init()
        {
            labels = new List<Label>();
            instruction = new Hashtable();
            //System
            instruction.Add("HALT", 0); // 
            instruction.Add("SYS0", 16); // <reg>
            instruction.Add("SYS1", 17); // <val>
            //Logic
            instruction.Add("AND0", 32); // <reg>, <reg>
            instruction.Add("AND1", 33); // <reg>, <val>
            instruction.Add("OR0", 34); // <reg>, <reg>
            instruction.Add("OR1", 35); // <reg>, <val>
            instruction.Add("XOR0", 36); // <reg>, <reg>
            instruction.Add("XOR1", 37); // <reg>, <val>
            instruction.Add("NOT", 38); // <reg>
            //Math
            instruction.Add("ADD", 40); // <reg>, <reg>
            instruction.Add("SUB", 41); // <reg>, <reg>
            instruction.Add("MUL", 42); // <reg>, <reg>
            instruction.Add("DIV", 43); // <reg>, <reg>
            //Location
            instruction.Add("MOV0", 48); // <reg>, <reg>
            instruction.Add("MOV1", 49); // <reg>, <val>
            instruction.Add("INC", 50); // <reg>
            instruction.Add("DEC", 51); // <reg>
            instruction.Add("SHL0", 52); // <reg>
            instruction.Add("SHL1", 53); // <reg>, <reg> (Result goes into left operand)
            instruction.Add("SHL2", 54); // <reg>, <val> (Result goes into left operand)
            instruction.Add("SHR0", 55); // <reg>
            instruction.Add("SHR1", 56); // <reg>, <reg> (Result goes into left operand)
            instruction.Add("SHR2", 57); // <reg>, <val> (Result goes into left operand)
            instruction.Add("R8", 64); // <reg>, <mem>
            instruction.Add("R16", 65); // <reg>, <mem>
            instruction.Add("R32", 66); // <reg>, <mem>
            instruction.Add("W8", 67); // <reg>, <mem>
            instruction.Add("W16", 68); // <reg>, <mem>
            instruction.Add("W32", 69); // <reg>, <mem>
            instruction.Add("PUSH", 70); // <reg>
            instruction.Add("POP", 71); // <reg>
            //Tests
            instruction.Add("TEST0", 80); // <reg> = <reg>
            instruction.Add("TEST1", 81); // <reg> = <val>
            instruction.Add("TEST2", 82); // <reg> < <reg>
            instruction.Add("TEST3", 83); // <reg> < <val>
            instruction.Add("TEST4", 84); // <reg> > <reg>
            instruction.Add("TEST5", 85); // <reg> > <val>
            instruction.Add("TEST6", 86); // <reg> <= <reg>
            instruction.Add("TEST7", 87); // <reg> <= <val>
            instruction.Add("TEST8", 88); // <reg> >= <reg>
            instruction.Add("TEST9", 89); // <reg> >= <val>
            //System direction
            instruction.Add("JMP0", 100); // <reg>
            instruction.Add("JMP1", 101); // <mem>
            instruction.Add("JMP2", 102); // <val>
            instruction.Add("JT0", 103); // <reg>
            instruction.Add("JT1", 104); // <mem>
            instruction.Add("JT2", 105); // <val>
            instruction.Add("JF0", 106); // <reg>
            instruction.Add("JF1", 107); // <mem>
            instruction.Add("JF2", 108); // <val>
            
            instruction.Add("RET", 128); // 
            instruction.Add("CALL0", 129); // <reg>
            instruction.Add("CALL1", 130); // <mem>
            instruction.Add("CALL2", 131); // <val>
        }

        static void Parse(string line)
        {
            if(line.Length > 0)
            {
                line = line.Trim();
                string[] tokens = line.Split(' ');
                string cmd = tokens[0];

                foreach (string token in tokens)
                {
                    Console.WriteLine($"'{token}'");
                }
            }
        }
    }
}
