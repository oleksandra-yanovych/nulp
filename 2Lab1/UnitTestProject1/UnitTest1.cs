using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] Ar = new int[] { -1, -2, 0, 1, 5, 10, -5, 1 };
            int res = _2Lab1.Program.Negative(Ar.Length, Ar);
            Assert.AreEqual(res, -8);
        }
    }
}
