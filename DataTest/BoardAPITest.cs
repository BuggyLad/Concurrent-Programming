using Data;

namespace DataTest
{
    [TestClass]
    public class BoardAPITest
    {
        [TestMethod]
        public void GetBoardTest()
        {
            BoardAPI boardAPI = BoardAPI.GetBoard();

            Assert.IsNotNull(boardAPI);
        }

        [TestMethod]
        public void CreateBallTest()
        {
            BoardAPI boardAPI = BoardAPI.GetBoard();

            Assert.AreEqual(0, boardAPI.GetBalls().Count);

            float x = 5;
            float y = 4;
            float xVelocity = 3;
            float yVelocity = 2;
            float radius = 1;

            boardAPI.CreateBall(x, y, xVelocity, yVelocity, radius);

            List<BallAPI> balls = boardAPI.GetBalls();

            Assert.AreEqual(1, balls.Count);

            BallAPI ball = balls[0];

            Assert.AreEqual(x, ball.GetCoordinates().X);
            Assert.AreEqual(y, ball.GetCoordinates().Y);
            Assert.AreEqual(xVelocity, ball.GetVelocity().X);
            Assert.AreEqual(yVelocity, ball.GetVelocity().Y);
            Assert.AreEqual(radius, ball.GetRadius());
        }

        [TestMethod]
        public void RemoveBallTest()
        {
            BoardAPI boardAPI = BoardAPI.GetBoard();

            boardAPI.CreateBall(1, 1, 1, 1, 1);

            Assert.AreEqual(1, boardAPI.GetBalls().Count);

            boardAPI.CreateBall(2, 2, 2, 2, 2);

            Assert.AreEqual(2, boardAPI.GetBalls().Count);

            boardAPI.RemoveBall();

            Assert.AreEqual(1, boardAPI.GetBalls().Count);
        }
    }
}
