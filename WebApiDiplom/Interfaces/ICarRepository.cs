using WebApiDiplom.Dto;
using WebApiDiplom.Models;

namespace WebApiDiplom.Interfaces
{
    public interface ICarRepository
    {
        ICollection<Car> GetCars();
        Car GetCar(int id);
        ICollection<Car> GetCarByColor(int colorId);
        ICollection<Car> GetCarByCarModel(int carModelId);
        Color GetColorByCar(int id);
        CarModel GetCarModelByCar(int id);
        CarDetailDto GetCarDetail(int id);
        ICollection<CarDetailDto> GetNonRentedCarsDetail();
        bool CarExists(int id);
        bool CreateCar(Car car);
        bool UpdateCar(Car car);
        bool DeleteCar(Car car);
        bool Save();
    }
}
