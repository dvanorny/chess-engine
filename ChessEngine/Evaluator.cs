using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessEngine
{
    public class Evaluator
    {
        public double EvaluatePosition(Game game, bool checkForExtras = true)
        {
            double evaluation = 0;
            int whiteBishopCount = 0;
            int blackBishopCount = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var square = game.ChessBoard[i, j];
                    if (square != null)
                    {
                        if (square.Color == Color.White)
                        {
                            evaluation += square.PieceValue();
                            //Look for developed Pieces.
                            if (j != 0 && square.Name != Piece.King)
                            {
                                evaluation += 0.1;
                            }
                            else if (j != 0) {
                                evaluation -= 0.75;
                            }
                        }
                        else
                        {
                            evaluation -= square.PieceValue();
                            if (j != 7 && square.Name != Piece.King)
                            {
                                evaluation -= 0.1;
                            }
                            else if (j != 7)
                            {
                                evaluation += 0.75;
                            }
                        }
                        if ((int)square.Name == 3)
                        {
                            if (square.Color == Color.White) { whiteBishopCount++; }
                            else if (square.Color == Color.Black) { blackBishopCount++; }
                        }
                    }
                }
            }

            //call extra functions
            if (checkForExtras)
            {
                //do fun stuff !!!!


                //extras
                if (whiteBishopCount == 2) { evaluation += 0.5; }
                if (blackBishopCount == 2) { evaluation -= 0.5; }
                evaluation += CheckForDoubledPawns(game);
            }

            return evaluation;
        }

        public double CheckForDoubledPawns(Game game)
        {
            var board = game.ChessBoard;
            var whitePawns = new List<int>();
            var blackPawns = new List<int>();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] != null)
                    {
                        if (board[i, j].Name == Piece.Pawn && board[i, j].Color == Color.White)
                        {
                            whitePawns.Add(i);
                        }
                        else if (board[i, j].Name == Piece.Pawn && board[i, j].Color == Color.Black)
                        {
                            blackPawns.Add(i);
                        }
                    }
                }
            }

            double score = 0;

            for (int i = 0; i < 8; i++)
            {
                if (whitePawns.Where(x => x == i).Count() > 0)
                {
                    score -= (whitePawns.Where(x => x == i).Count() - 1) * 0.33;
                }
                if(blackPawns.Where(x => x == i).Count() > 0) {
                    score += (blackPawns.Where(x => x == i).Count() - 1) * 0.33;
                }

            }

            return score;
        }       

    }
}
