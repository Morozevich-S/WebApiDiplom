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
            CreateMap<BodyTypeDto, BodyType>();
            CreateMap<BrandCar, BrandCarDto>();
            CreateMap<BrandCarDto, BrandCar>();
            CreateMap<Car, CarDto>();
            CreateMap<CarDto, Car>();
            CreateMap<CarModel, CarModelDto>();
            CreateMap<CarModelDto, CarModel>();
            CreateMap<Color, ColorDto>();
            CreateMap<ColorDto, Color>();
            CreateMap<Client, ClientDto>();
            CreateMap<ClientDto, Client>();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Fine, FineDto>();
            CreateMap<FineDto, Fine>();
            CreateMap<JobTitle, JobTitleDto>();
            CreateMap<JobTitleDto, JobTitle>();
            CreateMap<RentalContract, RentalContractDto>();
            CreateMap<RentalContractDto, RentalContract>();
        }
    }
}
