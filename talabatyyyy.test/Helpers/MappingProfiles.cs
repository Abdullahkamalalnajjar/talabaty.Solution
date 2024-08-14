﻿using AutoMapper;
using talabatyyyy.Core.Entities;
using talabatyyyy.test.Dtos;

namespace talabatyyyy.test.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
                CreateMap<Product,ProductToReturnDto>().ForMember(dest=>dest.ProductBrand , opt=>opt.MapFrom(src=>src.ProductBrand.Name))
                                                       .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.ProductType.Name))
                                                       .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<ProductPictureUrlResolve>());  
        } 
    }
}
