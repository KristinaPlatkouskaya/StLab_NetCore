using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using task3.Domain.Entities;

namespace task3.Domain.EF
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                FilmsStoreDbContext context = serviceScope.ServiceProvider.GetService<FilmsStoreDbContext>();
                if (!context.Films.Any())
                {
                    context.Films.Add(new Film { Name = "The Lake House", Country = "United States", Year = 2006, Producer = "Doug Davison" });
                    context.Films.Add(new Film { Name = "Lucky Number Slevin", Country = "Germany, Canada, United Kingdom, United States", Year = 2006, Producer = "Chris Roberts" });
                    context.Films.Add(new Film { Name = "Catch Me If You Can", Country = "United States", Year = 2002, Producer = "Steven Spielberg" });
                    context.Films.Add(new Film { Name = "The Social Network", Country = "United States", Year = 2010, Producer = "Scott Rudin" });
                    context.SaveChanges();
                }
                context.SaveChanges();
            }
        }
    }
}
