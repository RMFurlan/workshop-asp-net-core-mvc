using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SalesWebMvc.Models
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<SalesWebMvcContext>
    {
        public SalesWebMvcContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SalesWebMvcContext>();
            //optionsBuilder.UseSqlServer("");

            return new SalesWebMvcContext(optionsBuilder.Options);
        }
    }

    public class SalesWebMvcContext : DbContext
    {
        public SalesWebMvcContext (DbContextOptions<SalesWebMvcContext> options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "server=localhost;User Id=developer;Password=Rafael804637;database=saleswebmvcappdb";
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }

        public DbSet<SalesWebMvc.Models.Department> Department { get; set; }
    }
}
