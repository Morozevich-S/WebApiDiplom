using WebApiDiplom.Models;

namespace WebApiDiplom.Interfaces
{
    public interface ICarModelRepository
    {
        ICollection<CarModel> GetCarModels();
        CarModel GetCarModel(int id);
        CarModel GetCarModel(string modelName);
        int GetCarModelCapacity(int modelId);
        bool CarModelExists(int modelId);
        bool CreateCarModel(CarModel carModel);
        bool UpdateCarModel(CarModel carModel);
        bool Save();
    }
}
