using AutoMapper;
using BusinessLayer.Models;
using BusinessLayer.Models.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Profiles
{
    public class ProductProfile :Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductEntity, ProductAddDto>()
            .ForMember(
                dest => dest.CategoryId,
                opt => opt.MapFrom(src => src.CategoryEntityId))
                .ReverseMap();

            CreateMap<ProductEntity, ProductUpdateDto>().ForMember(
                dest => dest.CategoryId,
                opt => opt.MapFrom(src => src.CategoryEntityId))
                .ReverseMap();
        }
    }
}
