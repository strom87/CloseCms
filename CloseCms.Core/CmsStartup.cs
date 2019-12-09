using System;
using CloseCms.Data.Context;
using CloseCms.Data.Interfaces;
using CloseCms.Data.Migrations;
using CloseCms.Data.Repositories;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CloseCms.Core
{
    public static class CmsStartup
    {
        public static IServiceProvider ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:CloseCmsConnection"];
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("ConnectionString CloseCmsConnection is not set");
            }

            services.AddDbContext<CloseCmsContext>(options => options.UseSqlServer(connectionString));

            AddDependencies(services);
            SetupFluentMigrator(services, connectionString);

            var serviceProvider = services.BuildServiceProvider(false);

            RunUpMigrations(serviceProvider);

            return serviceProvider;
        }

        public static void Configure(IApplicationBuilder app, bool isDevelopmentEnv)
        {

        }

        private static void AddDependencies(IServiceCollection services)
        {
            services.AddScoped<IResourceRepository, ResourceRepository>();
        }
        
        private static void SetupFluentMigrator(IServiceCollection services, string connectionString)
        {
            services.AddFluentMigratorCore().ConfigureRunner(rb => rb
                .AddSqlServer2016()
                .WithGlobalConnectionString(connectionString)
                .ScanIn(typeof(InitMigration).Assembly).For.Migrations()
            );
        }

        private static void RunUpMigrations(IServiceProvider serviceProvider)
        {
            serviceProvider.GetRequiredService<IMigrationRunner>().MigrateUp();
        }
    }
}
