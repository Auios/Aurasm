using System;
using System.IO;

namespace aurac
{
    class Program
    {
        static void Main(string[] args)
        {
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

            string[] file = File.ReadAllLines(args[0]);
            for(int i = 0; i < file.Length; i++)
            {
                Console.WriteLine(file[i]);
            }

            Console.ReadKey();
        }
    }
}
