using Data;
using System.Numerics;

namespace DataTest
{
    [TestClass]
    public class BallAPITest
    {
        [TestMethod]
        public void GetBallTest()
        {
            float x = 21;
            float y = 13;
            float xVelocity = 8;
            float yVelocity = 5;
            float radius = 3;

            BallAPI ballAPI = BallAPI.GetBall(x, y, xVelocity, yVelocity, radius);

            Assert.AreEqual(x, ballAPI.GetCoordinates().X);
            Assert.AreEqual(y, ballAPI.GetCoordinates().Y);
            Assert.AreEqual(xVelocity, ballAPI.GetVelocity().X);
            Assert.AreEqual(yVelocity, ballAPI.GetVelocity().Y);
            Assert.AreEqual(radius, ballAPI.GetRadius());
        }

        [TestMethod]
        public void MoveTest()
        {
            float radius = 3;
            float maxX = BallAPI.maxCoordinates.X;
            float maxY = BallAPI.maxCoordinates.Y;


            // x = 0
            BallAPI ballAPI1 = BallAPI.GetBall(radius, radius, -1, 0, radius);

            ballAPI1.Move();

            Assert.AreEqual(ballAPI1.GetCoordinates(), new Vector2(radius + 1, radius));

            // y = 0
            BallAPI ballAPI2 = BallAPI.GetBall(radius, radius, 0, -1, radius);

            ballAPI2.Move();

            Assert.AreEqual(ballAPI2.GetCoordinates(), new Vector2(radius, radius + 1));

            // maximal x
            BallAPI ballAPI3 = BallAPI.GetBall(maxX - radius, maxY - radius, 1, 0, radius);

            ballAPI3.Move();

            Assert.AreEqual(ballAPI3.GetCoordinates(), new Vector2(maxX - radius - 1, maxY - radius));

            // maximal y
            BallAPI ballAPI4 = BallAPI.GetBall(maxX - radius, maxY - radius, 0, 1, radius);

            ballAPI4.Move();

            Assert.AreEqual(ballAPI4.GetCoordinates(), new Vector2(maxX - radius, maxY - radius - 1));
        }
    }
}