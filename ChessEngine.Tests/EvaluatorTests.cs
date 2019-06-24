using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessEngine.Tests
{
    [TestClass]
    public class EvaluatorTests
    {
        Evaluator eval;
        Game game;

        [TestInitialize]
        public void TestInitialize()
        {
            game = new Game();
            eval = new Evaluator();
        }

        [TestMethod]
        public void Test_start_of_game()
        {
            var currentScore = eval.EvaluatePosition(game);
            Assert.AreEqual(0, currentScore);
        }

        [TestMethod]
        public void Test_score_with_endgame_example()
        {
            var board = game.ChessBoard;

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

            Assert.AreEqual(-1.5, eval.EvaluatePosition(game));
        }

        [TestMethod]
        public void Test_scores_with_removal_of_pieces()
        {
            var board = game.ChessBoard;

            board[0, 0] = null;
            Assert.AreEqual(-5, eval.EvaluatePosition(game), "White Rook");

            game.ResetBoard();
            board[0, 7] = null;
            Assert.AreEqual(5, eval.EvaluatePosition(game), "Black Rook");

            game.ResetBoard();
            board[0, 1] = null;
            Assert.AreEqual(-1, eval.EvaluatePosition(game), "White Pawn");

            game.ResetBoard();
            board[0, 6] = null;
            Assert.AreEqual(1, eval.EvaluatePosition(game), "Black Pawn");

            game.ResetBoard();
            board[2, 0] = null;
            Assert.AreEqual(-3.5, eval.EvaluatePosition(game), "White Bishop");

            game.ResetBoard();
            board[2, 7] = null;
            Assert.AreEqual(3.5, eval.EvaluatePosition(game), "Black Bishop");

            game.ResetBoard();
            board[1, 0] = null;
            Assert.AreEqual(-3, eval.EvaluatePosition(game), "White Knight");

            game.ResetBoard();
            board[1, 7] = null;
            Assert.AreEqual(3, eval.EvaluatePosition(game), "Black Knight");

            game.ResetBoard();
            board[3, 0] = null;
            Assert.AreEqual(-9, eval.EvaluatePosition(game), "White Queen");

            game.ResetBoard();
            board[3, 7] = null;
            Assert.AreEqual(9, eval.EvaluatePosition(game), "Black Queen");
        }
    }
}

