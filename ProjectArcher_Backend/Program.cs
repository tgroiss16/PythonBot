using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ProjectArcher_Backend.Models;
using ProjectArcher_Backend.Services;

namespace ProjectArcher_Backend
{
    public class Program
    {
        private static postgresContext db = new postgresContext();
        private static ContactService c = new ContactService(db);
        private static CompanyService comp = new CompanyService(db);
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
            FillDataBase();
        }

        private static void FillDataBase()
        {
            db.Contact.AddRange(c.ReadContactCSV("Contact.csv"));
            db.Company.AddRange(comp.ReadCompanyCSV("Companies.csv"));
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
