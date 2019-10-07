using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.SQL;
using Infrastructure.SQL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OTSSCore.ApplicationServices;
using OTSSCore.ApplicationServices.Impl;
using OTSSCore.DomainServices;

namespace OnlineTShirtShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Environment = env;

        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ITShirtRepository, TShirtRepo>();
            services.AddScoped<ITShirtService, TShirtService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors();

            if (Environment.IsDevelopment())
            {
                // In-memory database:
                services.AddDbContext<OTSSContext>(opt => opt.UseSqlite("Data Source = OTSS.db"));
            }
            else
            {
                // Azure SQL database:
                services.AddDbContext<OTSSContext>(opt =>
                    opt.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
                if (Environment.IsDevelopment())
                {
                    var ctx = scope.ServiceProvider.GetService<OTSSContext>();
                    DbInitializer.SeedDB(ctx);
                }
                else
                {
                    var ctx = scope.ServiceProvider.GetService<OTSSContext>();
                    ctx.Database.EnsureCreated();
                    app.UseHsts();
                }

            app.UseHttpsRedirection();
            app.UseCors(monkey => monkey.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseMvc();
        }
    }
}
