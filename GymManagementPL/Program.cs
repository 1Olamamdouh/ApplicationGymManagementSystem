using GymManagementDAL.Data.Context;
using GymManagementDAL.Entity;
using GymManagementDAL.Repository.implementation;
using GymManagementDAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymManagementPL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Register the GymDbContext with dependency injection
            builder.Services.AddDbContext<GymDbContext>(options =>
            {
                //options.UseSqlServer("Server=.;Database=GymManagementSystem;Trusted_Connection=true;TrustServerCertificate=true");
                options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings")["DefaultConnection"]);

            }); 

           builder.Services.AddScoped(typeof(IGenericRepository<Member>), typeof(GenericImplementation<Member>));
           builder.Services.AddScoped(typeof(IPlanRepository), typeof(PlanRepository));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
