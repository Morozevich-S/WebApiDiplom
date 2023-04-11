using AutoMapper;
using WebApiDiplom.Dto;
using WebApiDiplom.Models;

namespace WebApiDiplom.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<CarModel, CarModelDto>();
        }
    }
}
