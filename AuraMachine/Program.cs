using System;
using System.IO;
using System.Text;

namespace AuraMachine
{
    class Program
    {
        static byte[] RAM;
        static ushort A, B, C, D;
        static ushort IP;
        static ushort SP;
        static bool Zero;
        static bool Carry;
        static bool Negative;
        static bool Overflow;

        static void Main(string[] args)
        {
            /*
            //Check if file name was passed
            if (args.Length == 0)
            {
                Console.WriteLine("No file name passed!");
                return;
            }

            //Check if file exists
            if (!File.Exists(args[0]))
            {
                Console.WriteLine("File not found!");
                return;
            }
            */

            AllocateRAM((int)Math.Pow(2, 16));

            string text = "Hello world!";
            byte[] bytes = Encoding.ASCII.GetBytes(text);

            //bytes.CopyTo(RAM, 0);

            Console.WriteLine(RAM.Length);

            Console.ReadKey();
        }

        static void AllocateRAM(int bytes)
        {
            RAM = new byte[bytes];
        }
    }
}
