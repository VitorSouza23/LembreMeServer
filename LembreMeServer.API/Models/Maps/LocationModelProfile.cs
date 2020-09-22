using AutoMapper;
using LembreMeServer.Domain.Entities;

namespace LembreMeServer.API.Models.Maps
{
    public class LocationModelProfile : Profile
    {
        public LocationModelProfile()
        {
            CreateMap<LocationModel, Location>()
                .ReverseMap();
        }
    }
}
