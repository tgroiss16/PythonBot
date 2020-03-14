using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Archer_UnitTests.Util
{
    [CollectionDefinition("DatabaseSetup")]
    public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
    {
        
    }
}
