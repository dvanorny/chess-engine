using System;

namespace chess_engine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to chess-engine!");
            Console.WriteLine("Type 0=white or 1=black:");
            var playerColor = Console.ReadLine();

            Console.WriteLine("Press enter to end...");
            Console.ReadLine();
        }
    }
}
