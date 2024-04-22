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
    }
}
