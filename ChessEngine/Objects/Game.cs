
namespace ChessEngine
{
    public class Game
    {
        public ChessPiece[,] ChessBoard { get; }
        public Color PlayerTurn { get; set; }

        public Game()
        {
            ChessBoard = new ChessPiece[8,8];
            SetUpBoard();
        }

        public void ResetBoard()
        {
            //First clear out all the squares
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    ChessBoard[i, j] = null;
                }
            }

            SetUpBoard();
        }

        public void SetUpBoard()
        {          

            ChessBoard[0, 7] = new ChessPiece(Piece.Rook, Color.Black);
            ChessBoard[1, 7] = new ChessPiece(Piece.Knight, Color.Black);
            ChessBoard[2, 7] = new ChessPiece(Piece.Bishop, Color.Black);
            ChessBoard[3, 7] = new ChessPiece(Piece.Queen, Color.Black);
            ChessBoard[4, 7] = new ChessPiece(Piece.King, Color.Black);
            ChessBoard[5, 7] = new ChessPiece(Piece.Bishop, Color.Black);
            ChessBoard[6, 7] = new ChessPiece(Piece.Knight, Color.Black);
            ChessBoard[7, 7] = new ChessPiece(Piece.Rook, Color.Black);
            ChessBoard[0, 0] = new ChessPiece(Piece.Rook, Color.White);
            ChessBoard[1, 0] = new ChessPiece(Piece.Knight, Color.White);
            ChessBoard[2, 0] = new ChessPiece(Piece.Bishop, Color.White);
            ChessBoard[3, 0] = new ChessPiece(Piece.Queen, Color.White);
            ChessBoard[4, 0] = new ChessPiece(Piece.King, Color.White);
            ChessBoard[5, 0] = new ChessPiece(Piece.Bishop, Color.White);
            ChessBoard[6, 0] = new ChessPiece(Piece.Knight, Color.White);
            ChessBoard[7, 0] = new ChessPiece(Piece.Rook, Color.White);
            ChessBoard[0, 6] = new ChessPiece(Piece.Pawn, Color.Black);
            ChessBoard[1, 6] = new ChessPiece(Piece.Pawn, Color.Black);
            ChessBoard[2, 6] = new ChessPiece(Piece.Pawn, Color.Black);
            ChessBoard[3, 6] = new ChessPiece(Piece.Pawn, Color.Black);
            ChessBoard[4, 6] = new ChessPiece(Piece.Pawn, Color.Black);
            ChessBoard[5, 6] = new ChessPiece(Piece.Pawn, Color.Black);
            ChessBoard[6, 6] = new ChessPiece(Piece.Pawn, Color.Black);
            ChessBoard[7, 6] = new ChessPiece(Piece.Pawn, Color.Black);
            ChessBoard[0, 1] = new ChessPiece(Piece.Pawn, Color.White);
            ChessBoard[1, 1] = new ChessPiece(Piece.Pawn, Color.White);
            ChessBoard[2, 1] = new ChessPiece(Piece.Pawn, Color.White);
            ChessBoard[3, 1] = new ChessPiece(Piece.Pawn, Color.White);
            ChessBoard[4, 1] = new ChessPiece(Piece.Pawn, Color.White);
            ChessBoard[5, 1] = new ChessPiece(Piece.Pawn, Color.White);
            ChessBoard[6, 1] = new ChessPiece(Piece.Pawn, Color.White);
            ChessBoard[7, 1] = new ChessPiece(Piece.Pawn, Color.White);
        }
    }
}
