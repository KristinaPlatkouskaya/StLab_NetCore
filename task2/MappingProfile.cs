using System;
using AutoMapper;
using task2.Models;

namespace task2
{
    internal class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ApiDataModel, StarShipsModel>();
            CreateMap<StarShipsModel, ApiDataModel>();
        }
    }
}