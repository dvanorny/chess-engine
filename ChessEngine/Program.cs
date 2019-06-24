using System;

namespace ChessEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to chess-engine!");

            var game = new Game();

            var code = new Evaluator();
            Console.WriteLine(code.EvaluatePosition(game));

            Console.ReadLine();
        }
    }
}
