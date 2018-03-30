using AutoMapper;
using PluralSightCoreDemo.Models;
using PluralSightCoreDemo.ViewModels;
using PluralSightCoreDemo.ViewModels.AccountViewModels;
using System;

namespace PluralSightCoreDemo.Infrastructure.Mapping
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<Image, ImageViewModel>()
                .ForMember(i => i.Image, cfg => cfg.MapFrom(i => i.ImageData));

            this.CreateMap<Restaurant, RestourantEditViewModel>().ReverseMap();
            this.CreateMap<City, CityIndexViewModel>().ReverseMap();

            this.CreateMap<User, RegisterViewModel>().ReverseMap();
            // .ForMember(x => x.Restaurants, cfg => cfg.MapFrom(x => x.Restaurants))); // if they are not with the same name
            
        }
    }
}
