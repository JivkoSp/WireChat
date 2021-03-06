using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Westwind.AspNetCore.LiveReload;
using Wire.AutomapperProfiles;
using Wire.Data;
using Wire.ExtensionMethods;
using Wire.Hubs;
using Wire.Middlewares;
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
                opt.SignIn.RequireConfirmedEmail = true;

            }).AddEntityFrameworkStores<WireChatDbContext>().AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(opt => {

                opt.Cookie.Name = "UserAuthCookie";
                opt.LoginPath = "/SignInPage/SignIn";
                opt.SlidingExpiration = true;
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(120);
            });

            services.AddMailKit(options => {
                options.UseMailKit(Configuration.GetSection("Email").Get<MailKitOptions>());
            });

            services.AddRepository();
            services.AddSignalR(opt => opt.EnableDetailedErrors = true);

            services.AddAntiforgery(config => config.HeaderName = "XSRF-TOKEN");

            services.AddAutoMapper(configAction => {
                configAction.AddProfile<GroupProfile>();
                configAction.AddProfile<FriendProfile>();
                configAction.AddProfile<PendingRequestProfile>();
                configAction.AddProfile<ActiveChatProfile>();
            });
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
            app.UseMiddleware<DeleteMessagesMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
                endpoints.MapHub<NotificationHub>("/notificationHub");
                endpoints.MapHub<ChatHub>("/chatHub");
            });
        }
    }
}
