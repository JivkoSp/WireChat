using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Westwind.AspNetCore.LiveReload;
using Wire.Data;
using Wire.ExtensionMethods;
using Wire.Hubs;
using Wire.Models;

namespace Wire
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddControllersWithViews();
            services.AddLiveReload();

            services.AddDbContext<WireChatDbContext>(builder => {

                builder.UseSqlServer(Configuration.GetConnectionString("WireChatDbConnection"));
            });

            services.AddIdentity<AppUser, IdentityRole>(opt => {

                opt.Password.RequiredLength = 4;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.SignIn.RequireConfirmedAccount = true;

            }).AddEntityFrameworkStores<WireChatDbContext>();

            services.ConfigureApplicationCookie(opt => {

                opt.Cookie.Name = "UserAuthCookie";
                opt.LoginPath = "/SignInPage/SignIn";
                opt.SlidingExpiration = true;
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(120);
            });

            services.AddRepository();
            services.AddSignalR(opt => opt.EnableDetailedErrors = true);
            services.AddAntiforgery(config => config.HeaderName = "XSRF-TOKEN");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseLiveReload();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
                endpoints.MapHub<NotificationHub>("/notificationHub");
            });
        }
    }
}
