using System;
using System.IO;
using DemoApp.DataAccess;
using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DemoApp
{
    public static class Config
    {
        public static IServiceCollection CreateServiceCollection()
        {
            string dbFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AllInOneContext.db");
            string connectionString = string.Format("Data Source={0}", dbFilePath);

            var services = new ServiceCollection();
                services
                    .AddDbContext<MainDbContext>(options => options.UseSqlite(connectionString))
                    .AddDbContext<UserDbContext>(options => options.UseSqlite(connectionString))
                    .AddMigrate(connectionString)
                .BuildServiceProvider();
            return services;
        }

        private static IServiceCollection AddMigrate(this IServiceCollection services, string connString)
        {
            services.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSQLite()
                    .WithGlobalConnectionString(connString)
                    .ScanIn(typeof(Config).Assembly)
                    .For.Migrations());
                    //.AddLogging(lb => lb.AddFluentMigratorConsole());

            return services;
        }
    }
}
