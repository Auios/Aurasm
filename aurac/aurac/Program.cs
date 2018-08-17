using System;

namespace aurac
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            foreach(string arg in args)
            {
                Console.WriteLine(arg);
            }
            Console.WriteLine("End");
            Console.ReadKey();
        }
    }
}
