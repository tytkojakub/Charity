using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charity.Context;
using Charity.Models.DbModels;
using Charity.Services;
using Charity.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Charity_1
{
    public class Startup
    {
        public Startup()
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");
            Configuration = configurationBuilder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<CharityContext>(builder =>
            {
                var config = Configuration["ConnectionStrings:DefaultConnection"];
                builder.UseSqlServer(config);
            });
            services.AddMvc();
            services.AddScoped<IDonationService, DonationService>();
            services.AddScoped<IInstitutionService, InstitutionService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddIdentityCore<AspNetUser>().AddEntityFrameworkStores<CharityContext>();
            services.AddIdentity<AspNetUser, IdentityRole>().AddEntityFrameworkStores<CharityContext>()
                .AddEntityFrameworkStores<CharityContext>();
            services.AddScoped<IUserManagerService, UserManagerService>();
            services.AddScoped<UserManager<AspNetUser>>();
            services.AddScoped<SignInManager<AspNetUser>>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
