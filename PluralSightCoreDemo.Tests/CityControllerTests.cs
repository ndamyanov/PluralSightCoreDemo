using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PluralSightCoreDemo.Controllers;
using PluralSightCoreDemo.Data;
using PluralSightCoreDemo.Infrastructure.Mapping;
using PluralSightCoreDemo.Models;
using PluralSightCoreDemo.Services;
using PluralSightCoreDemo.ViewModels;
using System;
using System.Collections.Generic;
using Xunit;

namespace PluralSightCoreDemo.Tests
{
    public class CityControllerTests
    {

        static CityControllerTests()
        {
            Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());
        }
        private PluralSightDemoDbContext Context
        {
            get
            {
                var dbOptions = new DbContextOptionsBuilder<PluralSightDemoDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;
                return new PluralSightDemoDbContext(dbOptions);
            }
        }

        private IEnumerable<City> TestData()
        {
            return new List<City>()
            {
                new City() {Id = 1, Name = "test City 1"},
                new City() {Id = 2, Name = "test City 2", Population = 3000},
                new City() {Id = 3, Name = "test City 3", Population = 4500}
            };
        }

        [Fact]
        public void CityControllerIndexShould_ReturnOkStatusCode()
        {
            var context = this.Context;
            context.Cities.AddRange(this.TestData());
            context.SaveChanges();

            var cityRepo = new CityRepository(context);


            var cityController = new CityController(cityRepo);

            Assert.IsType<ViewResult>(cityController.Index());
        }
    }
}
