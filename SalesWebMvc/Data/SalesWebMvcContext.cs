using SalesWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using System.Reflection.Emit;

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
        public void Configures(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, SeedingService seedingService)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                seedingService.Seed();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
                seedingService.Seed();
            }
        }

        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Seller> Seller { get; set; }
        public virtual DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
