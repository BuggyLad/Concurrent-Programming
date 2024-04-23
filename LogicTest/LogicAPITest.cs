using Logic;

namespace LogicTest
{
    [TestClass]
    public class LogicAPITest
    {
        [TestMethod]
        public void CreateBallTest()
        {
            LogicAbstractAPI api = LogicAbstractAPI.CreateAPI();

            Assert.AreEqual(0, api.GetBalls().Count);

            float radius = 3;

            api.CreateBall(radius, false);

            List<BallLogicAbstractAPI> balls = api.GetBalls();

            Assert.AreEqual(1, balls.Count);

            BallLogicAbstractAPI ball = balls[0];

            Assert.AreEqual(radius, ball.Radius);
            Assert.IsTrue(ball.X >= radius);
            Assert.IsTrue(ball.X <= LogicAbstractAPI.maxXCoordinate - radius);
            Assert.IsTrue(ball.Y >= radius);
            Assert.IsTrue(ball.Y <= LogicAbstractAPI.maxYCoordinate - radius);
            Assert.AreNotEqual(0, ball.XVelocity);
            Assert.AreNotEqual(0, ball.YVelocity);
        }

        [TestMethod]
        public void RemoveBallTest()
        {
            LogicAbstractAPI api = LogicAbstractAPI.CreateAPI();

            float radius = 1;

            api.CreateBall(radius, false);

            Assert.AreEqual(1, api.GetBalls().Count);

            api.CreateBall(radius, false);

            Assert.AreEqual(2, api.GetBalls().Count);

            api.RemoveBall();

            Assert.AreEqual(1, api.GetBalls().Count);
        }
    }
}