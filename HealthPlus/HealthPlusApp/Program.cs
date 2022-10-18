using HealthPlus.DataBase;
using HealthPlus.DataBase.Entities;
using HealthPlus.Business.Services;
using HealthPlus.Core.Abstractions;
using HealthPlus.Data.Abstractions;
using HealthPlus.Data.Abstractions.Repositories;
using HealthPlus.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Events;

namespace HealthPlusApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options => //CookieAuthenticationOptions
        {
            options.LoginPath = new PathString("/Account/Login");
        });

            var connectionString = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<HealthPlusContext>(
                optionsBuilder => optionsBuilder.UseSqlServer(connectionString));
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddScoped<IUserRoleService, UserRoleService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IRepository<UserRole>, Repository<UserRole>>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IRepository<User>, Repository<User>>();
            var app = builder.Build();

            //// Configure the HTTP request pipeline.
            //if (!app.Environment.IsDevelopment())
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            
            app.Run();
        }
    }
}