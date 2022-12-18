using EduHomeBack.DAL;
using EduHomeBack.Interfaces;
using EduHomeBack.Models;
using EduHomeBack.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace EduHomeBack
{
    public class Startup
    {
        private IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<ILayoutService, LayoutService>();
            services.AddIdentity<AppUser, IdentityRole>(options =>
         {
             options.Password.RequireDigit = true;
             options.Password.RequiredLength = 8;
             options.Password.RequireLowercase = true;
             options.Password.RequireUppercase = true;
             options.Password.RequireNonAlphanumeric = false;

             options.User.RequireUniqueEmail = true;

             options.Lockout.AllowedForNewUsers = true;
             options.Lockout.MaxFailedAccessAttempts = 10;
             options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(20);
         }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area:exists}/{controller=DashBoard}/{action=Index}/{id?}"
                    );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=home}/{action=index}/{id?}"
                    );
            });
        }
    }
}
