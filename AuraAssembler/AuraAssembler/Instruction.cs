using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuraAssembler
{
    class Instruction
    {
        string name;
        uint p1Size, p2Size;

        public Instruction(string name, uint p1Size = 0, uint p2Size = 0)
        {
            this.name = name;
            this.p1Size = p1Size;
            this.p2Size = p2Size;
        }

        public string GetName()
        {
            return name;
        }

        public uint GetSize()
        {
            return 1 + p1Size + p2Size;
        }
    }
}
