namespace AuraAssembler
{
    class Label
    {
        string name;
        uint address;

        public Label(string name, uint address = 0)
        {
            this.name = name;
            this.address = address;
        }
    }
}
