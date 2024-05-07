using Data;

namespace DataTest
{
    [TestClass]
    public class DataAPITest
    {
        [TestMethod]
        public void CreateAPITest()
        {
            DataAbstractAPI api = DataAbstractAPI.CreateAPI();

            Assert.IsNotNull(api);
        }

        [TestMethod]
        public void GetBallTest()
        {
            float x = 21;
            float y = 13;
            float xVelocity = 8;
            float yVelocity = 5;
            float radius = 3;

            DataAbstractAPI api = DataAbstractAPI.CreateAPI();

            BallDataAbstractAPI ball = api.CreateBall(x, y, xVelocity, yVelocity, radius, false);

            Assert.AreEqual(x, ball.X);
            Assert.AreEqual(y, ball.Y);
            Assert.AreEqual(xVelocity, ball.XVelocity);
            Assert.AreEqual(yVelocity, ball.YVelocity);
            Assert.AreEqual(radius, ball.Radius);
        }
    }
}
