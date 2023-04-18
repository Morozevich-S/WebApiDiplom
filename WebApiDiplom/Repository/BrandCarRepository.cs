using WebApiDiplom.Data;
using WebApiDiplom.Interfaces;
using WebApiDiplom.Models;

namespace WebApiDiplom.Repository
{
    public class BrandCarRepository : IBrandCarRepository
    {
        private readonly DataContext _context;

        public BrandCarRepository(DataContext context)
        {
            _context = context;
        }

        public bool BrandCarExists(int id)
        {
            return _context.BrandCars.Any(b => b.Id == id);
        }

        public bool CreateBrandCar(BrandCar brandCar)
        {
            _context.BrandCars.Add(brandCar);
            return Save();
        }

        public BrandCar GetBrandCar(int id)
        {
            return _context.BrandCars.Where(b => b.Id == id).FirstOrDefault();
        }

        public ICollection<BrandCar> GetBrandCars()
        {
            return _context.BrandCars.OrderBy(b => b.Id).ToList();
        }

        public ICollection<CarModel> GetCarModelByBrendCar(int id)
        {
            return _context.CarModels.Where(m => m.BrandCar.Id == id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateBrandCar(BrandCar brandCar)
        {
            _context.Update(brandCar);
            return Save();
        }
    }
}
