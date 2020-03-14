using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProjectArcher_Backend.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Archer_UnitTests.Util
{
    public class DatabaseFixture : IDisposable
    {
        public postgresContext dbContext { get; private set; }

        public DatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<postgresContext>()
                .UseInMemoryDatabase(databaseName: "archerPostgresDatabase")
                .Options;

            dbContext = new postgresContext(options);

            InitCompanyTable(dbContext);
            dbContext.SaveChanges();
        }

        private void InitCompanyTable(postgresContext context)
        {
            var json = File.ReadAllText(".\\TestData\\company_data.json");
            List<Company> model = JsonConvert.DeserializeObject<List<Company>>(json);
            context.AddRange(model);
            context.SaveChanges();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
