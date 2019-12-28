using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAuth.Web.Identity.Context;
using CoreAuth.Web.Identity.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CoreAuth.Web.Identity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataBaseContext>(_ => _.UseInMemoryDatabase("secretMemory"));
            services.AddIdentity<IdentityUser,IdentityRole>(_ => {
                _.Password.RequiredLength = 4;
                _.Password.RequireUppercase = false;
                _.Password.RequireDigit = false;
                _.Password.RequireNonAlphanumeric = false;
                _.Password.RequireLowercase = false;
            })
                .AddEntityFrameworkStores<DataBaseContext>()
                .AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(_ => {
                _.Cookie.Name = "identity-cookie";
                _.LoginPath = "/Account/Login";
            });
            services.AddControllersWithViews();
        }

       public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseMiddleware<DoSomethingMiddleware>();
            app.UseDoSomething();
            logger.LogWarning($"done it is working here!");
            //app.Use(async (context,next) =>
            //{
            //    logger.LogWarning($"Use called er");
            //    await context.Response.WriteAsync($"Hello Rudra");
            //    await next.Invoke();
            //    logger.LogWarning($"Use called lt");
            //});
            //app.Run(async context =>
            //{
            //    logger.LogWarning($"Run called er");
            //    await context.Response.WriteAsync("Hello from 2nd delegate.");
            //    logger.LogWarning($"Run called lt");
            //});
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            //app.Map("/rud", RegisterMiddlewaresExtentions.Anything);
        }
    }
}
