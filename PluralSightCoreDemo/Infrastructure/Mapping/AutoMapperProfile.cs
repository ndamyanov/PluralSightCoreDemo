using AutoMapper;
using PluralSightCoreDemo.Models;
using PluralSightCoreDemo.ViewModels;
using System;

namespace PluralSightCoreDemo.Infrastructure.Mapping
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<Image, ImageViewModel>()
                .ForMember(i => i.Image, cfg => cfg.MapFrom(i => i.ImageData));

            this.CreateMap<Restaurant, RestourantEditViewModel>();
            this.CreateMap<RestourantEditViewModel, Restaurant>();
            this.CreateMap<City, CityIndexViewModel>();
            // .ForMember(x => x.Restaurants, cfg => cfg.MapFrom(x => x.Restaurants))); // if they are not with the same name
            
        }
    }
}
