using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PluralSightCoreDemo.Services;
using Microsoft.EntityFrameworkCore;
using PluralSightCoreDemo.Data;
using Microsoft.Extensions.Logging;
using PluralSightCoreDemo.Models;
using PluralSightCoreDemo.ViewModels;
using AutoMapper;

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
            services.AddScoped<IRestourantData, SqlRestorantData>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IImageData, ImageService>();

            services.AddAutoMapper(); // Inftrastructure/Mappring/AutoMapperProfile

            services.AddMvc();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            
            app.UseNodeModules(env.ContentRootPath);

            //AutoMapper.Mapper.Initialize(cfg =>
            //{
            //   // cfg.CreateMap<City, CityIndexViewModel>(); // comes from the other AutoMapper extension
            //    cfg.CreateMap<City, CityViewModel>();
            //    cfg.CreateMap<City, RestaurantCity>().ForMember(c => c.ReataurantId, conf => conf.Ignore());
            //    cfg.CreateMap<City, RestaurantCity>().ForMember(c => c.RestaurantData, conf => conf.Ignore());
            //    cfg.CreateMap<Restaurant, RestaurantCity>().ForMember(c => c.CityId, conf => conf.Ignore());
            //    cfg.CreateMap<Restaurant, RestaurantCity>().ForMember(c => c.CityData, conf => conf.Ignore());

            //});
            app.UseMvc(ConfigureRoutes);
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
