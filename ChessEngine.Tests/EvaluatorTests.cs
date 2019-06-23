using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessEngine.Tests
{
    [TestClass]
    public class EvaluatorTests
    {
        [TestMethod]
        public void Test_Start_Of_Game()
        {
            var code = new MainCode();
            var board = code.SetUpBoard();
            var currentScore = code.EvaluatePosition(board);
            Assert.AreEqual(0, currentScore);
        }
    }
}
