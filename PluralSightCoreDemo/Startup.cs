using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PluralSightCoreDemo.Services;
using Microsoft.EntityFrameworkCore;
using PluralSightCoreDemo.Data;
using Microsoft.Extensions.Logging;
using AutoMapper;
using PluralSightCoreDemo.Hub;
using PluralSightCoreDemo.Models;
using Microsoft.AspNetCore.Identity;
using System;

namespace PluralSightCoreDemo
{
    public class Startup
    {
        private IConfiguration _config;
        
        public Startup(IConfiguration config)
        {
            this._config = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreater,Greeter>();
            services.AddDbContext<PluralSightDemoDbContext>(options => options.UseSqlServer(_config.GetConnectionString("DefaultConnection")));
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<PluralSightDemoDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                //options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                //options.Lockout.MaxFailedAccessAttempts = 10;
                //options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                // If the LoginPath isn't set, ASP.NET Core defaults 
                // the path to /Account/Login.
                options.LoginPath = "/Account/Login";
                // If the AccessDeniedPath isn't set, ASP.NET Core defaults 
                // the path to /Account/AccessDenied.
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            services.AddScoped<IRestourantData, SqlRestorantData>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IImageData, ImageService>();

            services.AddAutoMapper(); // Inftrastructure/Mappring/AutoMapperProfile
            services.AddSignalR();
            services.AddMvc();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddDebug();

            if (!env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            
            app.UseNodeModules(env.ContentRootPath);

            app.UseSignalR(routes =>
            {
                routes.MapHub<ForumHub>("forum");
            });
            //AutoMapper.Mapper.Initialize(cfg =>
            //{
            //   // cfg.CreateMap<City, CityIndexViewModel>(); // comes from the other AutoMapper extension
            //    cfg.CreateMap<City, CityViewModel>();
            //    cfg.CreateMap<City, RestaurantCity>().ForMember(c => c.ReataurantId, conf => conf.Ignore());
            //    cfg.CreateMap<City, RestaurantCity>().ForMember(c => c.RestaurantData, conf => conf.Ignore());
            //    cfg.CreateMap<Restaurant, RestaurantCity>().ForMember(c => c.CityId, conf => conf.Ignore());
            //    cfg.CreateMap<Restaurant, RestaurantCity>().ForMember(c => c.CityData, conf => conf.Ignore());

            //});

            app.UseAuthentication();

            app.UseMvc(ConfigureRoutes);
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
