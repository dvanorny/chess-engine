using System;

namespace ChessEngine
{
    public class MainCode
    {
        public double EvaluatePosition(ChessPiece[,] board)
        {
            double evaluation = 0;
            int whiteBishopCount = 0;
            int blackBishopCount = 0;
            int[] whitePawnFiles = new int[8];
            int[] blackPawnFiles = new int[8];
            int[] dummyArray = new int[8];
            int dummyVar = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var square = board[i, j];
                    if (square != null)
                    {
                        if (square.Color == Color.White)
                        {
                            evaluation += square.PieceValue();
                        }
                        else
                        {
                            evaluation -= square.PieceValue();
                        }
                        if ((int)square.Name == 3)
                        {
                            if (square.Color == Color.White) { whiteBishopCount++; }
                            else if (square.Color == Color.Black) { blackBishopCount++; }
                        }
                        if ((int)square.Name == 1)
                        {
                            if (square.Color == Color.White)
                            {
                                int index = 8;
                                for (var l = 0; l < 8; l++)
                                {
                                    if (whitePawnFiles[l] == 0) { index--; }
                                }
                                whitePawnFiles[index] = i;
                            }
                            else if (square.Color == Color.Black)
                            {
                                int index = 8;
                                for (var l = 0; l < 8; l++)
                                {
                                    if (blackPawnFiles[l] == 0) { index--; }
                                }
                                blackPawnFiles[index] = i;
                            }
                        }
                    }
                }
            }

            //extras
            if (whiteBishopCount == 2) { evaluation += 0.5; }
            if (blackBishopCount == 2) { evaluation -= 0.5; }
            for (var k = 0; k < 8; k++)
            {
                dummyArray = whitePawnFiles;
                dummyArray[k] = 0;
                dummyVar = whitePawnFiles[k];
                for (var i = 0; i < dummyArray.Length; i++) { Console.WriteLine(dummyArray[i]); }
                Console.WriteLine(Array.Exists(dummyArray, element => element == dummyVar));
                if (Array.Exists(dummyArray, element => element == dummyVar))
                {
                    evaluation -= 0.3;
                }

                dummyArray = blackPawnFiles;
                dummyArray[k] = 0;
                dummyVar = blackPawnFiles[k];
                if (Array.Exists(dummyArray, element => element == dummyVar))
                {
                    evaluation += 0.3;
                }
            }

            return evaluation;
        }


        public ChessPiece[,] SetUpBoard()
        {
            var chessBoard = new ChessPiece[8, 8];

            chessBoard[0, 7] = new ChessPiece(Piece.Rook, Color.Black);
            chessBoard[1, 7] = new ChessPiece(Piece.Knight, Color.Black);
            chessBoard[2, 7] = new ChessPiece(Piece.Bishop, Color.Black);
            chessBoard[3, 7] = new ChessPiece(Piece.Queen, Color.Black);
            chessBoard[4, 7] = new ChessPiece(Piece.King, Color.Black);
            chessBoard[5, 7] = new ChessPiece(Piece.Bishop, Color.Black);
            chessBoard[6, 7] = new ChessPiece(Piece.Knight, Color.Black);
            chessBoard[7, 7] = new ChessPiece(Piece.Rook, Color.Black);
            chessBoard[0, 0] = new ChessPiece(Piece.Rook, Color.White);
            chessBoard[1, 0] = new ChessPiece(Piece.Knight, Color.White);
            chessBoard[2, 0] = new ChessPiece(Piece.Bishop, Color.White);
            chessBoard[3, 0] = new ChessPiece(Piece.Queen, Color.White);
            chessBoard[4, 0] = new ChessPiece(Piece.King, Color.White);
            chessBoard[5, 0] = new ChessPiece(Piece.Bishop, Color.White);
            chessBoard[6, 0] = new ChessPiece(Piece.Knight, Color.White);
            chessBoard[7, 0] = new ChessPiece(Piece.Rook, Color.White);
            chessBoard[0, 6] = new ChessPiece(Piece.Pawn, Color.Black);
            chessBoard[1, 6] = new ChessPiece(Piece.Pawn, Color.Black);
            chessBoard[2, 6] = new ChessPiece(Piece.Pawn, Color.Black);
            chessBoard[3, 6] = new ChessPiece(Piece.Pawn, Color.Black);
            chessBoard[4, 6] = new ChessPiece(Piece.Pawn, Color.Black);
            chessBoard[5, 6] = new ChessPiece(Piece.Pawn, Color.Black);
            chessBoard[6, 6] = new ChessPiece(Piece.Pawn, Color.Black);
            chessBoard[7, 6] = new ChessPiece(Piece.Pawn, Color.Black);
            chessBoard[0, 1] = new ChessPiece(Piece.Pawn, Color.White);
            chessBoard[1, 1] = new ChessPiece(Piece.Pawn, Color.White);
            chessBoard[2, 1] = new ChessPiece(Piece.Pawn, Color.White);
            chessBoard[3, 1] = new ChessPiece(Piece.Pawn, Color.White);
            chessBoard[4, 1] = new ChessPiece(Piece.Pawn, Color.White);
            chessBoard[5, 1] = new ChessPiece(Piece.Pawn, Color.White);
            chessBoard[5, 2] = new ChessPiece(Piece.Pawn, Color.White);
            chessBoard[7, 1] = new ChessPiece(Piece.Pawn, Color.White);
            return chessBoard;
        }

    }
}
