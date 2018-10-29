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
            instruction.Add("HALT", new Instruction("HALT")); // 
            instruction.Add("SYS0", new Instruction("SYS", 1)); // <reg>
            instruction.Add("SYS1", new Instruction("SYS", 1)); // <val>

            instruction.Add("AND0", new Instruction("ADD", 1, 1)); // <reg>, <reg>
            instruction.Add("AND1", new Instruction("ADD", 1, 4)); // <reg>, <val>
            instruction.Add("OR0", new Instruction("OR", 1, 1)); // <reg>, <reg>
            instruction.Add("OR1", new Instruction("OR", 1, 4)); // <reg>, <val>
            instruction.Add("XOR0", new Instruction("XOR", 1, 1)); // <reg>, <reg>
            instruction.Add("XOR1", new Instruction("XOR", 1, 4)); // <reg>, <val>
            instruction.Add("NOT", new Instruction("NOT", 1)); // <reg>

            instruction.Add("ADD", new Instruction("ADD", 1, 1)); // <reg>, <reg>
            instruction.Add("SUB", new Instruction("SUB", 1, 1)); // <reg>, <reg>
            instruction.Add("MUL", new Instruction("MUL", 1, 1)); // <reg>, <reg>
            instruction.Add("DIV", new Instruction("DIV", 1, 1)); // <reg>, <reg>

            instruction.Add("MOV0", new Instruction("MOV", 1, 1)); // <reg>, <reg>
            instruction.Add("MOV1", new Instruction("MOV", 1, 4)); // <reg>, <val>
            instruction.Add("INC", new Instruction("INC", 1)); // <reg>
            instruction.Add("DEC", new Instruction("DEC", 1)); // <reg>
            instruction.Add("SHL0", new Instruction("SHL", 1)); // <reg>
            instruction.Add("SHL1", new Instruction("SHL", 1, 1)); // <reg>, <reg> (Result goes into left operand)
            instruction.Add("SHL2", new Instruction("SHL", 1, 4)); // <reg>, <val> (Result goes into left operand)
            instruction.Add("SHR0", new Instruction("SHR", 1)); // <reg>
            instruction.Add("SHR1", new Instruction("SHR", 1, 1)); // <reg>, <reg> (Result goes into left operand)
            instruction.Add("SHR2", new Instruction("SHR", 1, 4)); // <reg>, <val> (Result goes into left operand)
            instruction.Add("R8", new Instruction("R8", 1, 4)); // <reg>, <mem>
            instruction.Add("R16", new Instruction("R16", 1, 4)); // <reg>, <mem>
            instruction.Add("R32", new Instruction("R32", 1, 4)); // <reg>, <mem>
            instruction.Add("W8", new Instruction("W8", 1, 4)); // <reg>, <mem>
            instruction.Add("W16", new Instruction("W16", 1, 4)); // <reg>, <mem>
            instruction.Add("W32", new Instruction("W32", 1, 4)); // <reg>, <mem>
            instruction.Add("PUSH", new Instruction("PUSH", 1)); // <reg>
            instruction.Add("POP", new Instruction("POP", 1)); // <reg>

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
