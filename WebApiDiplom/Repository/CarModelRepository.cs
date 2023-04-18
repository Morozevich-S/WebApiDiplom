using WebApiDiplom.Data;
using WebApiDiplom.Interfaces;
using WebApiDiplom.Models;

namespace WebApiDiplom.Repository
{
    public class CarModelRepository : ICarModelRepository
    {
        private readonly DataContext _context;
        public CarModelRepository(DataContext context)
        {
            _context = context;
        }

        public CarModel GetCarModel(int id)
        {
            return _context.CarModels.Where(cm => cm.Id == id).FirstOrDefault();
        }

        public CarModel GetCarModel(string name)
        {
            return _context.CarModels.Where(cm => cm.Name == name).FirstOrDefault();
        }

        public int GetCarModelCapacity(int modelId)
        {
            return _context.CarModels.Where(cm => cm.Id == modelId).FirstOrDefault().Capacity;
        }

        public ICollection<CarModel> GetCarModels()
        {
            return _context.CarModels.OrderBy(cm => cm.Id).ToList();
        }

        public bool CarModelExists(int modelId)
        {
            return _context.CarModels.Any(cm => cm.Id == modelId);
        }

        public bool CreateCarModel(CarModel carModel)
        {
            _context.CarModels.Add(carModel);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCarModel(CarModel carModel)
        {
            _context.Update(carModel);
            return Save();
        }
    }
}
