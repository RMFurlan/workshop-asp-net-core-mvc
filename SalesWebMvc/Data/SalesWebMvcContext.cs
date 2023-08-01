using SalesWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using System.Reflection.Emit;
using static System.Net.Mime.MediaTypeNames;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Models
{
    public class SalesWebMvcContext : DbContext
    {
        public SalesWebMvcContext()
        {
        }

        public SalesWebMvcContext(DbContextOptions<SalesWebMvcContext> options)
            : base(options)
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
        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}

