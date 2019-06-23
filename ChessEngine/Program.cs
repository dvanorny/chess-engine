using System;

namespace ChessEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to chess-engine!");

            var code = new MainCode();
            var board = code.SetUpBoard();
            Console.WriteLine(code.EvaluatePosition(board));

            Console.ReadLine();
        }
    }
}
