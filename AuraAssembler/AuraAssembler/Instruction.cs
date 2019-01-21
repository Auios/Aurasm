namespace AuraAssembler
{
    class Instruction
    {
        byte ID;
        string name;
        uint p1Size, p2Size;

        public Instruction(byte ID, string name, uint p1Size = 0, uint p2Size = 0)
        {
            this.ID = ID;
            this.name = name;
            this.p1Size = p1Size;
            this.p2Size = p2Size;
        }

        public byte GetID()
        {
            return ID;
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
