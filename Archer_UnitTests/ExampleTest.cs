using Archer_UnitTests.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Unit_Tests
{
    [Collection("DatabaseSetup")]
    public class ExampleTest
    {
        DatabaseFixture database;

        public ExampleTest(DatabaseFixture fixture)
        {
            this.database = fixture;
        }

        [Fact]
        public void Test_Example()
        {
            Assert.True("Example" == "Example", "This test is richtig, spezi");
            Assert.True(database.dbContext.Company.Count() > 0);
        }
    }
}
