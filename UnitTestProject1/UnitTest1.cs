using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int n = 3680;
            float result1 = ConsoleApp1.Program.converttomin(n);
            Assert.AreEqual(61,33, result1);

            float result2 = ConsoleApp1.Program.converttohours(n);
            Assert.AreEqual(1,02, result2);
        }
    }
}
