using System;
using System.Collections;

namespace AuraAssembler
{
    class Program
    {
        static UInt32 curAdr; // Current address
        static Hashtable inst;
        static Hashtable reg;
        static Hashtable lbl;

        static void Main(string[] args)
        {
            Init();

            Parse("ok:");
            Parse("ok2:");
            Parse("MOV r1, ok2");

            Console.ReadKey();
        }

        static void Init()
        {
            inst = new Hashtable();
            reg = new Hashtable();
            lbl = new Hashtable();

            inst.Add("HALT", new Instruction(0, "HALT"));            // 
            inst.Add("SYS0", new Instruction(16, "SYS", 1));         // <reg>
            inst.Add("SYS1", new Instruction(17, "SYS", 1));         // <val>

            inst.Add("AND0", new Instruction(32, "ADD", 1, 1));      // <reg>, <reg>
            inst.Add("AND1", new Instruction(33, "ADD", 1, 4));      // <reg>, <val>
            inst.Add("OR0", new Instruction(34, "OR", 1, 1));        // <reg>, <reg>
            inst.Add("OR1", new Instruction(35, "OR", 1, 4));        // <reg>, <val>
            inst.Add("XOR0", new Instruction(36, "XOR", 1, 1));      // <reg>, <reg>
            inst.Add("XOR1", new Instruction(37, "XOR", 1, 4));      // <reg>, <val>
            inst.Add("NOT", new Instruction(38, "NOT", 1));          // <reg>

            inst.Add("ADD", new Instruction(40, "ADD", 1, 1));       // <reg>, <reg>
            inst.Add("SUB", new Instruction(41, "SUB", 1, 1));       // <reg>, <reg>
            inst.Add("MUL", new Instruction(42, "MUL", 1, 1));       // <reg>, <reg>
            inst.Add("DIV", new Instruction(43, "DIV", 1, 1));       // <reg>, <reg>

            inst.Add("MOV0", new Instruction(48, "MOV", 1, 1));      // <reg>, <reg>
            inst.Add("MOV1", new Instruction(49, "MOV", 1, 4));      // <reg>, <val>
            inst.Add("INC", new Instruction(50, "INC", 1));          // <reg>
            inst.Add("DEC", new Instruction(51, "DEC", 1));          // <reg>
            inst.Add("SHL0", new Instruction(52, "SHL", 1));         // <reg>
            inst.Add("SHL1", new Instruction(53, "SHL", 1, 1));      // <reg>, <reg> (Result goes into left operand)
            inst.Add("SHL2", new Instruction(54, "SHL", 1, 4));      // <reg>, <val> (Result goes into left operand)
            inst.Add("SHR0", new Instruction(55, "SHR", 1));         // <reg>
            inst.Add("SHR1", new Instruction(56, "SHR", 1, 1));      // <reg>, <reg> (Result goes into left operand)
            inst.Add("SHR2", new Instruction(57, "SHR", 1, 4));      // <reg>, <val> (Result goes into left operand)
            inst.Add("RB", new Instruction(64, "R8", 1, 4));         // <reg>, <mem>
            inst.Add("RS", new Instruction(65, "R16", 1, 4));        // <reg>, <mem>
            inst.Add("RL", new Instruction(66, "R32", 1, 4));        // <reg>, <mem>
            inst.Add("WB", new Instruction(67, "W8", 1, 4));         // <reg>, <mem>
            inst.Add("WS", new Instruction(68, "W16", 1, 4));        // <reg>, <mem>
            inst.Add("WL", new Instruction(69, "W32", 1, 4));        // <reg>, <mem>
            inst.Add("PUSH", new Instruction(70, "PUSH", 1));        // <reg>
            inst.Add("POP", new Instruction(71, "POP", 1));          // <reg>

            inst.Add("TEST0", new Instruction(80, "TEST", 1, 1));    // <reg> = <reg>
            inst.Add("TEST1", new Instruction(81, "TEST", 1, 4));    // <reg> = <val>
            inst.Add("TEST2", new Instruction(82, "TEST", 1, 1));    // <reg> < <reg>
            inst.Add("TEST3", new Instruction(83, "TEST", 1, 4));    // <reg> < <val>
            inst.Add("TEST4", new Instruction(84, "TEST", 1, 1));    // <reg> > <reg>
            inst.Add("TEST5", new Instruction(85, "TEST", 1, 4));    // <reg> > <val>
            inst.Add("TEST6", new Instruction(86, "TEST", 1, 1));    // <reg> <= <reg>
            inst.Add("TEST7", new Instruction(87, "TEST", 1, 4));    // <reg> <= <val>
            inst.Add("TEST8", new Instruction(88, "TEST", 1, 1));    // <reg> >= <reg>
            inst.Add("TEST9", new Instruction(89, "TEST", 1, 4));    // <reg> >= <val>

            inst.Add("JMP0", new Instruction(100, "JMP", 1));        // <reg>
            inst.Add("JMP1", new Instruction(101, "JMP", 4));        // <mem>
            inst.Add("JMP2", new Instruction(102, "JMP", 4));        // <val>
            inst.Add("JT0", new Instruction(103, "JT", 1));          // <reg>
            inst.Add("JT1", new Instruction(104, "JT", 4));          // <mem>
            inst.Add("JT2", new Instruction(105, "JT", 4));          // <val>
            inst.Add("JF0", new Instruction(106, "JF", 1));          // <reg>
            inst.Add("JF1", new Instruction(107, "JF", 4));          // <mem>
            inst.Add("JF2", new Instruction(108, "JF", 4));          // <val>

            inst.Add("RET", new Instruction(128, "RET"));            // 
            inst.Add("CALL0", new Instruction(129, "CALL", 1));      // <reg>
            inst.Add("CALL1", new Instruction(130, "CALL", 4));      // <mem>
            inst.Add("CALL2", new Instruction(131, "CALL", 4));      // <val>

            uint ii = 0;
            reg["r0"] = ii++;
            reg["r1"] = ii++;
            reg["r2"] = ii++;
            reg["r3"] = ii++;
            reg["r4"] = ii++;
            reg["r5"] = ii++;
            reg["r6"] = ii++;
            reg["r7"] = ii++;
            reg["r8"] = ii++;
            reg["r9"] = ii++;
            reg["r10"] = ii++;
            reg["r11"] = ii++;
            reg["BP"] = ii++;
            reg["SP"] = ii++;
            reg["CR"] = ii++;
            reg["IP"] = ii++;
        }

        static void Parse(string line)
        {
            if(line.Length > 0)
            {
                line = line.Trim();
                string[] tokens = line.Split(' ', ',');
                string cmd = tokens[0];

                if(tokens[0].EndsWith(":"))
                {
                    string labelName = tokens[0].TrimEnd(':');
                    Console.WriteLine($"Label: '{labelName}'");
                    lbl[labelName] = 0;
                    return;
                }
                else
                {
                    Console.WriteLine($"Instruction: '{tokens[0]}'");
                }

                for (int i = 1; i < tokens.Length; i++)
                {
                    string token = tokens[i];

                    if (token.Length <= 0)
                        continue;

                    // Register check
                    if (token[0] == 'r')
                    {
                        Console.WriteLine($"Register: '{token}'");
                        continue;
                    }

                    // Address check
                    if (token[0] == '@')
                    {
                        Console.WriteLine($"Address: '{token}'");
                        continue;
                    }

                    // Label check
                    string lToken = token.TrimEnd(':');
                    if (lbl[lToken] != null)
                    {
                        Console.WriteLine($"Label: '{lbl[lToken]}'");
                        continue;
                    }

                    // Other register check
                    switch (token)
                    {
                        case "BP":
                            Console.WriteLine($"Base Pointer: '{token}'");
                            continue;
                        case "SP":
                            Console.WriteLine($"Stack Pointer: '{token}'");
                            continue;
                        case "CR":
                            Console.WriteLine($"Control Register: '{token}'");
                            continue;
                        case "IP":
                            Console.WriteLine($"Instruction Pointer: '{token}'");
                            continue;
                        default:
                            break;
                    }

                    // Number check
                    try
                    {
                        uint value = uint.Parse(token);
                        Console.WriteLine($"Value: '{value}'");
                        continue;
                    }
                    catch
                    {
                        Console.WriteLine($"'{token}' not recognized");
                        continue;
                    }
                }
            }
        }
    }
}
