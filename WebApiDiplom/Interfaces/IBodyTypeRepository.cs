using WebApiDiplom.Models;

namespace WebApiDiplom.Interfaces
{
    public interface IBodyTypeRepository
    {
        ICollection<BodyType> GetBodyTypes();
        BodyType GetBodyType(int id);
        BodyType GetBodyTypeByCarModel(int carModelId);
        ICollection<CarModel> GetCarModelsByBodyType(int bodyTypeId);
        bool BodyTypeExists(int id);
        bool CreateBodyType(BodyType bodyType);
        bool UpdateBodyType(BodyType bodyType);
        bool Save();
    }
}
