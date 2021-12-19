using AutoMapper;
using System;
using Tourist.API.Dtos;
using Tourist.API.Dtos;
using Tourist.API.Models;

namespace Tourist.API.Profiles
{
    public class TouristRoutePictureProfile : Profile
    {
        public TouristRoutePictureProfile()
        {
            CreateMap<TouristRoutePicture, TouristRoutePictureDto>();

            CreateMap<TouristRoutePictureForCreationDto, TouristRoutePicture>();
        }
    }
}
