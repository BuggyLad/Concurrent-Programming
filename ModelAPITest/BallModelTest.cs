using Presentation.Model;

namespace ModelAPITest
{
    [TestClass]
    public class BallModelTest
    {
        [TestMethod]
        public void Test()
        {
            ModelAbstractAPI api = ModelAbstractAPI.CreateAPI();

            api.CreateBall();

            System.Collections.ObjectModel.ObservableCollection<object> balls = api.GetBalls();

            Assert.AreEqual(1, balls.Count);
        }
    }
}
