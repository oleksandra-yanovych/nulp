using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private static string FilePath = @"Data.json";
        [TestMethod]
        public static void TestMethod1()
        {
            var spam = JsonConvert.DeserializeObject<List<Spam>>(File.ReadAllText(FilePath));
            int res = _5Lab1.Program.AverageSpamSpD(spam);
        }
    }
}
