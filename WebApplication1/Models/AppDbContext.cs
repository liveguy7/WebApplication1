using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;

namespace WebApplication1.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            

        }

        public DbSet<Employee> empTarget { get; set; }


    }
}








