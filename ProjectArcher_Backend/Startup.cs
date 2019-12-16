using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectArcher_Backend.Models;
using ProjectArcher_Backend.Services;

namespace ProjectArcher_Backend
{
    public class Startup
    {
        public IHostingEnvironment HostingEnvironment { get; private set; }
        public IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            this.HostingEnvironment = env;
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICompanyTimelineService, CompanyTimelineService>();
            services.AddScoped<IContactTimelineService, ContactTimelineService>();
            services.AddScoped<IKeywordService, KeywordService>();

            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddDbContext<postgresContext>(opt => opt.UseNpgsql(Configuration.GetValue<string>("DataBaseConnectionString")));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //Comment this out to redirect to https
            //app.UseHttpsRedirection();

            app.UseMvc();
        }
    }
}
