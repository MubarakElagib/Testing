using AutoMapper;
using Demo.Backend.Dtos;
using Demo.Backend.Models;

namespace Demo.Backend.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
             CreateMap<ProductForCreationDto, Product>();
        }
    }
}