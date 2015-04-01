using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer;

namespace Test
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void SqlConnector_NewInstance()
        {
            Assert.IsInstanceOfType(SqlConnector.GetInstance, typeof(SqlConnector));
        }
    }
}
