using System;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace oadr_test.TestSet
{
    [TestClass]
    public class UnitTestConvertDuration
    {
        [TestMethod]
        public void testMS()
        {
            // int x = (int)XmlConvert.ToTimeSpan("PT5S").TotalMilliseconds;
            int x = (int)XmlConvert.ToTimeSpan("P5W").TotalMilliseconds;

            Assert.AreEqual(5, x);
        }
    }
}
