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
        uint parameters;
        uint size;

        public Instruction(string name, uint parameters, uint size)
        {
            this.name = name;
            this.parameters = parameters;
            this.size = size;
        }
    }
}
