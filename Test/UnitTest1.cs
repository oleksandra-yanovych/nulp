using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int n = 3680;
            float result1 = Lab.Program.converttomin(n);
            Assert.AreEqual(61, 33, result1);

            float result2 = Lab.Program.converttohours(n);
            Assert.AreEqual(1, 02, result2);
        }
    }
}
