using WebApiDiplom.Data;
using WebApiDiplom.Interfaces;
using WebApiDiplom.Models;

namespace WebApiDiplom.Repository
{
    public class BodyTypeRepository : IBodyTypeRepository
    {
        private readonly DataContext _context;

        public BodyTypeRepository(DataContext context)
        {
            _context = context;
        }

        public bool BodyTypeExists(int id)
        {
            return _context.BodyTypes.Any(t => t.Id == id);
        }

        public BodyType GetBodyType(int id)
        {
            return _context.BodyTypes.Where(t => t.Id == id).FirstOrDefault();
        }

        public BodyType GetBodyTypeByCarModel(int carModelId)
        {
            return _context.CarModels.Where(m => m.Id == carModelId)
                .Select(m => m.BodyType).FirstOrDefault();
        }

        public ICollection<BodyType> GetBodyTypes()
        {
            return _context.BodyTypes.OrderBy(t => t.Id).ToList();
        }

        public ICollection<CarModel> GetCarModelsByBodyType(int bodyTypeId)
        {
            return _context.CarModels.Where(m => m.BodyType.Id == bodyTypeId).ToList();
        }
    }
}
