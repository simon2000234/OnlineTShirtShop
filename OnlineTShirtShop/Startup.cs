using System;
using Infrastructure.SQL;
using Infrastructure.SQL.Helpers;
using Infrastructure.SQL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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
            // Create a byte array with random values. This byte array is used
            // to generate a key for signing JWT tokens.
            Byte[] secretBytes = new byte[40];
            Random rand = new Random();
            rand.NextBytes(secretBytes);

            // Add JWT based authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    //ValidAudience = "TodoApiClient",
                    ValidateIssuer = false,
                    //ValidIssuer = "TodoApi",
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
                    ValidateLifetime = true, //validate the expiration and not before values in the token
                    ClockSkew = TimeSpan.FromMinutes(10) //5 minute tolerance for the expiration date
                };
            });

            services.AddScoped<ITShirtRepository, TShirtRepo>();
            services.AddScoped<ITShirtService, TShirtService>();
            services.AddScoped<IUserRepository, UserRepo>();
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<IAuthenticationHelper>(new AuthenticationHelper(secretBytes));
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
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
