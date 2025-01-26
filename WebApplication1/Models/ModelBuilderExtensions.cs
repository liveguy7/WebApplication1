using Microsoft.EntityFrameworkCore;
using System;

namespace WebApplication1.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    id = 1,
                    name = "Han",
                    department = Dept.HR,
                    email = "han@na.com"
                },
                new Employee
                {
                    id = 2,
                    name = "Jon",
                    department = Dept.HR,
                    email = "jon@na.com"
                }
              );

        }
    }
}
