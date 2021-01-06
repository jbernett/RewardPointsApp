using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RewardPointsApp.Models;
using RewardPointsApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RewardPointsApp.Data
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RewardPointsDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<RewardPointsDbContext>>()))
            {
                if (context.Customers.Any())
                {
                    return;
                }

                var customerOneGuid = new Guid("bdf70d60-d58a-4498-a427-4cae60964bc3");
                var customerTwoGuid = new Guid("0cf698f8-b2b0-42a9-9b45-c5d1ede21e3e");

                context.Customers.AddRange(
                    new Customer
                    {
                        Guid = customerOneGuid,
                        Rewards = 0

                    },
                    new Customer
                    {
                        Guid = customerTwoGuid,
                        Rewards = 0

                    });                   

                context.Invoices.AddRange(
                    new Invoice { Guid = Guid.NewGuid(), CustomerGuid = customerOneGuid, Total = 20M, Date = DateTimeOffset.Now },
                    new Invoice { Guid = Guid.NewGuid(), CustomerGuid = customerOneGuid, Total = 100M, Date = DateTimeOffset.Now },
                    new Invoice { Guid = Guid.NewGuid(), CustomerGuid = customerOneGuid, Total = 204M, Date = DateTimeOffset.MinValue },
                    new Invoice { Guid = Guid.NewGuid(), CustomerGuid = customerOneGuid, Total = 260M, Date = DateTimeOffset.Now },
                    new Invoice { Guid = Guid.NewGuid(), CustomerGuid = customerOneGuid, Total = 820M, Date = DateTimeOffset.Now },
                    new Invoice { Guid = Guid.NewGuid(), CustomerGuid = customerOneGuid, Total = 360M, Date = DateTimeOffset.Now },
                    new Invoice { Guid = Guid.NewGuid(), CustomerGuid = customerOneGuid, Total = 230M, Date = DateTimeOffset.Now },
                    new Invoice { Guid = Guid.NewGuid(), CustomerGuid = customerOneGuid, Total = 9020M, Date = DateTimeOffset.MinValue },
                    new Invoice { Guid = Guid.NewGuid(), CustomerGuid = customerOneGuid, Total = 10M, Date = DateTimeOffset.Now },
                    new Invoice { Guid = Guid.NewGuid(), CustomerGuid = customerOneGuid, Total = 520M, Date = DateTimeOffset.Now },
                    new Invoice { Guid = Guid.NewGuid(), CustomerGuid = customerOneGuid, Total = 1020M, Date = DateTimeOffset.Now },
                    new Invoice { Guid = Guid.NewGuid(), CustomerGuid = customerOneGuid, Total = 920M, Date = DateTimeOffset.Now },
                    new Invoice { Guid = Guid.NewGuid(), CustomerGuid = customerOneGuid, Total = 670M, Date = DateTimeOffset.MinValue },
                    new Invoice { Guid = Guid.NewGuid(), CustomerGuid = customerOneGuid, Total = 98M, Date = DateTimeOffset.Now },
                    new Invoice { Guid = Guid.NewGuid(), CustomerGuid = customerOneGuid, Total = 450M, Date = DateTimeOffset.Now },
                    new Invoice { Guid = Guid.NewGuid(), CustomerGuid = customerOneGuid, Total = 280M, Date = DateTimeOffset.Now },
                    new Invoice { Guid = Guid.NewGuid(), CustomerGuid = customerOneGuid, Total = 62M, Date = DateTimeOffset.Now },
                    new Invoice { Guid = Guid.NewGuid(), CustomerGuid = customerTwoGuid, Total = 400M, Date = DateTimeOffset.Now },
                    new Invoice { Guid = Guid.NewGuid(), CustomerGuid = customerTwoGuid, Total = 35M, Date = DateTimeOffset.Now },
                    new Invoice { Guid = Guid.NewGuid(), CustomerGuid = customerTwoGuid, Total = 730M, Date = DateTimeOffset.Now },
                    new Invoice { Guid = Guid.NewGuid(), CustomerGuid = customerTwoGuid, Total = 10020M, Date = DateTimeOffset.MinValue },
                    new Invoice { Guid = Guid.NewGuid(), CustomerGuid = customerTwoGuid, Total = 42M, Date = DateTimeOffset.Now }
                    );

                context.SaveChanges();
            }
        }
    }
}
