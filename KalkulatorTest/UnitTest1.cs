namespace KalkulatorTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAdd()
        {
            KalkulatorNamespace.Kalkulator kalk = new KalkulatorNamespace.Kalkulator();

            int par1 = new Random().Next();
            int wynik = kalk.Add(par1, 0);

            Assert.AreEqual(wynik, wynik);
        }
    }
}