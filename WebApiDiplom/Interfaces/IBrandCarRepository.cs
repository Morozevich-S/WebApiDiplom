using WebApiDiplom.Models;

namespace WebApiDiplom.Interfaces
{
    public interface IBrandCarRepository
    {
        ICollection<BrandCar> GetBrandCars();
        BrandCar GetBrandCar(int id);
        ICollection<CarModel> GetCarModelByBrendCar(int id);
        bool BrandCarExists(int id);
        bool CreateBrandCar(BrandCar brandCar);
        bool UpdateBrandCar(BrandCar brandCar);
        bool Save();
    }
}
