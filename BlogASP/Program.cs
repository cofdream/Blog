using BlogASP.Data;
using BlogASP.Data.FileManager;
using BlogASP.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogASP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;
            // Add services to the container.
            services.AddControllersWithViews();

            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });

            services.AddTransient<IRepository, Repository>();
            services.AddTransient<IFileManager, FileManager>();


            //Êý¾Ý¿â
            services.AddDbContext<AppDbContext>((options) => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 6;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();


            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Auth/Login";
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            var scope = app.Services.CreateScope();

            var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            appDbContext.Database.EnsureCreated();

            var adminRole = new IdentityRole("Admin");
            if (appDbContext.Roles.Any() == false)
            {
                roleManager.CreateAsync(adminRole).GetAwaiter().GetResult();
            }

            if (appDbContext.Users.Any(user => user.UserName == "admin") == false)
            {
                var adminUser = new IdentityUser("admin")
                {
                    Email = "cofdream@sina.com",
                };

                userManager.CreateAsync(adminUser, "Qaz000..").GetAwaiter().GetResult();

                userManager.AddToRoleAsync(adminUser, adminUser.UserName).GetAwaiter().GetResult();
            }

            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
