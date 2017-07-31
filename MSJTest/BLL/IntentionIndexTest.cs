using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMVC.BLL;

namespace MSJTest.BLL
{
    [TestClass]
    public class IntentionIndexTest
    {
        IntentionIndex intentionIndex = new IntentionIndex();
        [TestMethod]
        public void TestMethod1()
        {
            var result = intentionIndex.Get();
            Assert.AreEqual(1, result.Count);
        }
    }
}
