using System;
using System.Linq;
using Xunit;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void TestMethod1()
        {
            string helloTest = "Hello Test!";
            Assert.Contains("Hello", helloTest);
        }

        public void LoggerInit()
        {
        }
    }
}
