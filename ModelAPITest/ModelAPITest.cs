using Presentation.Model;

namespace ModelAPITest
{
    [TestClass]
    public class ModelAPITest
    {
        [TestMethod]
        public void BallOperationTest()
        {
            ModelAbstractAPI api = ModelAbstractAPI.CreateAPI();

            Assert.AreEqual(0, api.GetBalls().Count);

            api.CreateBall();

            Assert.AreEqual(1, api.GetBalls().Count);

            api.CreateBall();

            Assert.AreEqual(2, api.GetBalls().Count);

            api.RemoveBall();

            Assert.AreEqual(1, api.GetBalls().Count);
        }
    }
}