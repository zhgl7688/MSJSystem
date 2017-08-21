using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSJTest.BLL
{
    [TestClass]
    public class ThirdPPTTest:BaseTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var result = thirdPPT.GetPPTList();

        }
    }
}
