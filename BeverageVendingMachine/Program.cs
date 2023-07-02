using AutoMapper;
using BeverageVendingMachine.Models.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace BeverageVendingMachine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddDbContext<ApplicationContext>(opt =>
            {
                var connectionString = builder.Configuration.GetConnectionString("Database");
                connectionString = connectionString!.Replace("%CONTENTROOTPATH%", builder.Environment.ContentRootPath);

                opt.UseSqlServer(connectionString);
            });

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=WendingMachine}/{action=Index}");

            app.Run();
        }
    }
}