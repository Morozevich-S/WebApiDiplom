using AutoMapper;
using WebApiDiplom.Dto;
using WebApiDiplom.Models;

namespace WebApiDiplom.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<BodyType, BodyTypeDto>();
            CreateMap<BrandCar, BrandCarDto>();
            CreateMap<Car, CarDto>();
            CreateMap<CarModel, CarModelDto>();
            CreateMap<Color, ColorDto>();
            CreateMap<Client, ClientDto>();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<RentalContract, RentalContractDto>();
        }
    }
}
