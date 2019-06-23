using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessEngine.Tests
{
    [TestClass]
    public class EvaluatorTests
    {
        MainCode code;

        [TestInitialize]
        public void TestInitialize()
        {
            code = new MainCode();
        }

        [TestMethod]
        public void Test_start_of_game()
        {
            var board = code.SetUpBoard();
            var currentScore = code.EvaluatePosition(board);
            Assert.AreEqual(0, currentScore);
        }

        [TestMethod]
        public void Test_score_with_endgame_example()
        {
            var board = new ChessPiece[8, 8];

            //Following is taken from move 23 in game: https://www.chess.com/live/game/3804992877

            //Black pieces
            board[0, 7] = new ChessPiece(Piece.Rook, Color.Black);
            board[0, 6] = new ChessPiece(Piece.Pawn, Color.Black);
            board[1, 6] = new ChessPiece(Piece.Pawn, Color.Black);
            board[2, 4] = new ChessPiece(Piece.Knight, Color.Black);
            board[4, 7] = new ChessPiece(Piece.King, Color.Black);
            board[5, 2] = new ChessPiece(Piece.Rook, Color.Black);

            //White pieces
            board[0, 0] = new ChessPiece(Piece.Rook, Color.White);
            board[0, 2] = new ChessPiece(Piece.Pawn, Color.White);
            board[2, 6] = new ChessPiece(Piece.Bishop, Color.White);
            board[2, 2] = new ChessPiece(Piece.King, Color.White);
            board[3, 2] = new ChessPiece(Piece.Pawn, Color.White);
            board[4, 5] = new ChessPiece(Piece.Bishop, Color.White);

            Assert.AreEqual(-1.5, code.EvaluatePosition(board));
        }

        [TestMethod]
        public void Test_scores_with_removal_of_pieces()
        {
            var board = code.SetUpBoard();

            board[0, 0] = null;
            Assert.AreEqual(-5, code.EvaluatePosition(board), "White Rook");

            board = code.SetUpBoard();
            board[0, 7] = null;
            Assert.AreEqual(5, code.EvaluatePosition(board), "Black Rook");

            board = code.SetUpBoard();
            board[0, 1] = null;
            Assert.AreEqual(-1, code.EvaluatePosition(board), "White Pawn");

            board = code.SetUpBoard();
            board[0, 6] = null;
            Assert.AreEqual(1, code.EvaluatePosition(board), "Black Pawn");

            board = code.SetUpBoard();
            board[2, 0] = null;
            Assert.AreEqual(-3.5, code.EvaluatePosition(board), "White Bishop");

            board = code.SetUpBoard();
            board[2, 7] = null;
            Assert.AreEqual(3.5, code.EvaluatePosition(board), "Black Bishop");

            board = code.SetUpBoard();
            board[1, 0] = null;
            Assert.AreEqual(-3, code.EvaluatePosition(board), "White Knight");

            board = code.SetUpBoard();
            board[1, 7] = null;
            Assert.AreEqual(3, code.EvaluatePosition(board), "Black Knight");

            board = code.SetUpBoard();
            board[3, 0] = null;
            Assert.AreEqual(-9, code.EvaluatePosition(board), "White Queen");

            board = code.SetUpBoard();
            board[3, 7] = null;
            Assert.AreEqual(9, code.EvaluatePosition(board), "Black Queen");
        }
    }
}

