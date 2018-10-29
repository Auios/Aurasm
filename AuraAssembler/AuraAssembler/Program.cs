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

            instruction.Add("HALT", new Instruction(0, "HALT")); // 
            instruction.Add("SYS0", new Instruction(16, "SYS", 1)); // <reg>
            instruction.Add("SYS1", new Instruction(17, "SYS", 1)); // <val>

            instruction.Add("AND0", new Instruction(32, "ADD", 1, 1)); // <reg>, <reg>
            instruction.Add("AND1", new Instruction(33, "ADD", 1, 4)); // <reg>, <val>
            instruction.Add("OR0", new Instruction(34, "OR", 1, 1)); // <reg>, <reg>
            instruction.Add("OR1", new Instruction(35, "OR", 1, 4)); // <reg>, <val>
            instruction.Add("XOR0", new Instruction(36, "XOR", 1, 1)); // <reg>, <reg>
            instruction.Add("XOR1", new Instruction(37, "XOR", 1, 4)); // <reg>, <val>
            instruction.Add("NOT", new Instruction(38, "NOT", 1)); // <reg>

            instruction.Add("ADD", new Instruction(40, "ADD", 1, 1)); // <reg>, <reg>
            instruction.Add("SUB", new Instruction(41, "SUB", 1, 1)); // <reg>, <reg>
            instruction.Add("MUL", new Instruction(42, "MUL", 1, 1)); // <reg>, <reg>
            instruction.Add("DIV", new Instruction(43, "DIV", 1, 1)); // <reg>, <reg>

            instruction.Add("MOV0", new Instruction(48, "MOV", 1, 1)); // <reg>, <reg>
            instruction.Add("MOV1", new Instruction(49, "MOV", 1, 4)); // <reg>, <val>
            instruction.Add("INC", new Instruction(50, "INC", 1)); // <reg>
            instruction.Add("DEC", new Instruction(51, "DEC", 1)); // <reg>
            instruction.Add("SHL0", new Instruction(52, "SHL", 1)); // <reg>
            instruction.Add("SHL1", new Instruction(53, "SHL", 1, 1)); // <reg>, <reg> (Result goes into left operand)
            instruction.Add("SHL2", new Instruction(54, "SHL", 1, 4)); // <reg>, <val> (Result goes into left operand)
            instruction.Add("SHR0", new Instruction(55, "SHR", 1)); // <reg>
            instruction.Add("SHR1", new Instruction(56, "SHR", 1, 1)); // <reg>, <reg> (Result goes into left operand)
            instruction.Add("SHR2", new Instruction(57, "SHR", 1, 4)); // <reg>, <val> (Result goes into left operand)
            instruction.Add("RB", new Instruction(64, "R8", 1, 4)); // <reg>, <mem>
            instruction.Add("RS", new Instruction(65, "R16", 1, 4)); // <reg>, <mem>
            instruction.Add("RL", new Instruction(66, "R32", 1, 4)); // <reg>, <mem>
            instruction.Add("WB", new Instruction(67, "W8", 1, 4)); // <reg>, <mem>
            instruction.Add("WS", new Instruction(68, "W16", 1, 4)); // <reg>, <mem>
            instruction.Add("WL", new Instruction(69, "W32", 1, 4)); // <reg>, <mem>
            instruction.Add("PUSH", new Instruction(70, "PUSH", 1)); // <reg>
            instruction.Add("POP", new Instruction(71, "POP", 1)); // <reg>

            instruction.Add("TEST0", new Instruction(80, "TEST", 1, 1)); // <reg> = <reg>
            instruction.Add("TEST1", new Instruction(81, "TEST", 1, 4)); // <reg> = <val>
            instruction.Add("TEST2", new Instruction(82, "TEST", 1, 1)); // <reg> < <reg>
            instruction.Add("TEST3", new Instruction(83, "TEST", 1, 4)); // <reg> < <val>
            instruction.Add("TEST4", new Instruction(84, "TEST", 1, 1)); // <reg> > <reg>
            instruction.Add("TEST5", new Instruction(85, "TEST", 1, 4)); // <reg> > <val>
            instruction.Add("TEST6", new Instruction(86, "TEST", 1, 1)); // <reg> <= <reg>
            instruction.Add("TEST7", new Instruction(87, "TEST", 1, 4)); // <reg> <= <val>
            instruction.Add("TEST8", new Instruction(88, "TEST", 1, 1)); // <reg> >= <reg>
            instruction.Add("TEST9", new Instruction(89, "TEST", 1, 4)); // <reg> >= <val>

            instruction.Add("JMP0", new Instruction(100, "JMP", 1)); // <reg>
            instruction.Add("JMP1", new Instruction(101, "JMP", 4)); // <mem>
            instruction.Add("JMP2", new Instruction(102, "JMP", 4)); // <val>
            instruction.Add("JT0", new Instruction(103, "JT", 1)); // <reg>
            instruction.Add("JT1", new Instruction(104, "JT", 4)); // <mem>
            instruction.Add("JT2", new Instruction(105, "JT", 4)); // <val>
            instruction.Add("JF0", new Instruction(106, "JF", 1)); // <reg>
            instruction.Add("JF1", new Instruction(107, "JF", 4)); // <mem>
            instruction.Add("JF2", new Instruction(108, "JF", 4)); // <val>

            instruction.Add("RET", new Instruction(128, "RET")); // 
            instruction.Add("CALL0", new Instruction(129, "CALL", 1)); // <reg>
            instruction.Add("CALL1", new Instruction(130, "CALL", 4)); // <mem>
            instruction.Add("CALL2", new Instruction(131, "CALL", 4)); // <val>
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
