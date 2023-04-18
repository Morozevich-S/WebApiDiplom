using WebApiDiplom.Data;
using WebApiDiplom.Interfaces;
using WebApiDiplom.Models;

namespace WebApiDiplom.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly DataContext _context;

        public CarRepository(DataContext context)
        {
            _context = context;
        }

        public bool CarExists(int id)
        {
            return _context.Cars.Any(c => c.Id == id);
        }

        public bool CreateCar(Car car)
        {
            _context.Cars.Add(car);
            return Save();
        }

        public Car GetCar(int id)
        {
            return _context.Cars.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<Car> GetCarByCarModel(int carModelId)
        {
            return _context.Cars.Where(c => c.CarModel.Id == carModelId).ToList();
        }

        public ICollection<Car> GetCarByColor(int colorId)
        {
            return _context.Cars.Where(c => c.Color.Id == colorId).ToList();
        }

        public CarModel GetCarModelByCar(int id)
        {
            return _context.Cars.Where(c => c.Id == id).
                Select(c => c.CarModel).FirstOrDefault();
        }

        public ICollection<Car> GetCars()
        {
            return _context.Cars.OrderBy(c => c.Id).ToList();
        }

        public Color GetColorByCar(int id)
        {
            return _context.Cars.Where(c => c.Id == id).
               Select(c => c.Color).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCar(Car car)
        {
            _context.Update(car);
            return Save();
        }
    }
}
