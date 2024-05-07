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
            Assert.IsTrue(ball.Left >= radius);
            Assert.IsTrue(ball.Left <= LogicAbstractAPI.maxXCoordinate - radius);
            Assert.IsTrue(ball.Top >= radius);
            Assert.IsTrue(ball.Top <= LogicAbstractAPI.maxYCoordinate - radius);
            Assert.AreEqual(ball.Radius, radius);
            Assert.AreEqual(ball.Diameter, 2 * radius);


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