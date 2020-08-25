using System;
using System.Linq;
using DemoApp.DataAccess;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace DemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = Config.CreateServiceCollection().BuildServiceProvider();
            var serviceScopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();

            using (var serviceScope = serviceScopeFactory.CreateScope())
            {
                var provider = serviceScope.ServiceProvider;
                var runner = provider.GetRequiredService<IMigrationRunner>();
                runner.MigrateUp();

                var mainDbContext = provider.GetService<MainDbContext>();
                //init orgs
                var orgs = mainDbContext.Orgs.ToList();
                if (orgs.Count == 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        var index = (i + 1);
                        mainDbContext.Orgs.Add(new Org() { Id = index, Name = "Org" + index });
                    }
                    mainDbContext.SaveChanges();
                }

                //init users
                var userDbContext = serviceScope.ServiceProvider.GetService<UserDbContext>();
                var users = userDbContext.Users.ToList();
                if (users.Count == 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        var index = (i + 1);
                        userDbContext.Users.Add(new User() { Id = index, Name = "User" + index, Username = "user" + index });
                    }
                    userDbContext.SaveChanges();
                }

                //init sites
                var sites = mainDbContext.Sites.ToList();
                if (sites.Count == 0)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        var index = (i + 1);
                        mainDbContext.Sites.Add(new Site() { Id = index, Name = "Site" + index });
                    }
                    mainDbContext.SaveChanges();
                }
            }

            using (var serviceScope = serviceScopeFactory.CreateScope())
            {
                var provider = serviceScope.ServiceProvider;
                var mainDbContext = provider.GetService<MainDbContext>();
                var orgs = mainDbContext.Orgs.ToList();
                foreach (var org in orgs)
                {
                    Console.WriteLine("mainDbContext: {0}, {1}", org.Id, org.Name);
                }
                Console.WriteLine("------------");

                var userDbContext = provider.GetService<UserDbContext>();
                var users = userDbContext.Users.ToList();
                foreach (var user in users)
                {
                    Console.WriteLine("userDbContext: {0}, {1}", user.Id, user.Name);
                }

                var queryOrgs = userDbContext.Orgs.ToList();
                foreach (var org in queryOrgs)
                {
                    Console.WriteLine("userDbContext: {0}, {1}", org.Id, org.Name);
                }

                Console.WriteLine("------------");
                var querySites = userDbContext.Sites.ToList();
                foreach (var site in querySites)
                {
                    Console.WriteLine("userDbContext: {0}, {1}", site.Id, site.Name);
                }
            }

            Console.WriteLine("---- DEMO COMPLETE ----");
            Console.Read();
        }
    }
}
