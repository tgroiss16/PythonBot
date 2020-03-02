using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Unit_Tests
{
    public class ExampleTest
    {
        [Fact]
        public void Test_Example()
        {
            Assert.True("Example" == "Example", "This test is richtig, spezi");
        }
    }
}
