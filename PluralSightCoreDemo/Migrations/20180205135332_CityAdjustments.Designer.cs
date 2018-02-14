﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using PluralSightCoreDemo.Data;
using PluralSightCoreDemo.Models;
using System;

namespace PluralSightCoreDemo.Migrations
{
    [DbContext(typeof(PluralSightDemoDbContext))]
    [Migration("20180205135332_CityAdjustments")]
    partial class CityAdjustments
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PluralSightCoreDemo.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Population");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("PluralSightCoreDemo.Models.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CityId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("TypeRestaurant");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Restourants");
                });

            modelBuilder.Entity("PluralSightCoreDemo.Models.Restaurant", b =>
                {
                    b.HasOne("PluralSightCoreDemo.Models.City")
                        .WithMany("Restaurants")
                        .HasForeignKey("CityId");
                });
#pragma warning restore 612, 618
        }
    }
}
