using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SalesWebMvcContext") ?? throw new InvalidOperationException("Connection string 'DefaultConnection not found.");

builder.Services.AddDbContext<SalesWebMvcContext>(options =>
options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Add services to the container. 
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<SeedingService>();

var app = builder.Build();

void Configures(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, SeedingService seedingService)
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
    }
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
