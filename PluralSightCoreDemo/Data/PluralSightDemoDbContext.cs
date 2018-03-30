using AutoMapper;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PluralSightCoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PluralSightCoreDemo.Data
{
    public class PluralSightDemoDbContext : IdentityDbContext<User>
    {
        public PluralSightDemoDbContext(DbContextOptions<PluralSightDemoDbContext> options) : base(options)
        {

        }

        public DbSet<Restaurant> Restourants { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           

            modelBuilder.Entity<RestaurantCity>()
                .HasKey(x => new { x.CityId, x.ReataurantId });

            modelBuilder.Entity<RestaurantCity>()
                .HasOne(x => x.RestaurantData)
                .WithMany(e => e.Cities)
                .HasForeignKey(x => x.ReataurantId);


            modelBuilder.Entity<RestaurantCity>()
                .HasOne(x => x.CityData)
                .WithMany(e => e.Restaurants)
                .HasForeignKey(x => x.CityId);

        }
    }
}
