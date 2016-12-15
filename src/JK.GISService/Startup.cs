using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DataAccessManager;
using Microsoft.EntityFrameworkCore;
using DataAccessProvider;
using DomainModel;
using MySQL.Data.Entity.Extensions;

namespace JK.GISService
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            string sqlConnectionString = null;
           string connType =  Configuration.GetSection("connType").Value;
            if ("mysql" == connType)
            {
                sqlConnectionString = Configuration.GetSection("ConnectionStrings:DataAccessMySqlProvider").Value;
                services.AddDbContext<DomainModelContext>(options =>
                        options.UseMySQL(
                            sqlConnectionString,
                            b => b.MigrationsAssembly("JK.GISService")
                        )
                     );

            }
            else {
                sqlConnectionString = Configuration.GetSection("ConnectionStrings:DataAccessMsSqlServerProvider").Value;
                services.AddDbContext<DomainModelContext>(options =>
                    options.UseSqlServer(
                        sqlConnectionString
                    ) );
               
            }

            services.AddScoped<IDataAccessProvider, DataAccessMssqlProvider>();




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
