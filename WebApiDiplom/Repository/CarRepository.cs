using WebApiDiplom.Data;
using WebApiDiplom.Dto;
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

        public bool DeleteCar(Car car)
        {
            _context.Remove(car);
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

        public CarDetailDto GetCarDetail(int id)
        {
            var result = from c in _context.Cars
                         join m in _context.CarModels
                         on c.CarModelId equals m.Id
                         join b in _context.BrandCars
                         on m.BrandCarId equals b.Id
                         join t in _context.BodyTypes
                         on m.BodyTypeId equals t.Id
                         join cl in _context.Colors
                         on c.ColorId equals cl.Id
                         where c.Id == id
                         select new CarDetailDto
                         {
                             Id = c.Id,
                             BrandCarName = b.Name,
                             CarModelName = m.Name,
                             ColorName = cl.ColorName,
                             Capacity = m.Capacity,
                             Mileage = c.Mileage,
                             YearOfIssue = c.YearOfIssue,
                             BodyTypeName = t.Type,
                             Rented = c.Rented
                         };
            return result.FirstOrDefault();
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

        public ICollection<CarDetailDto> GetNonRentedCarsDetail()
        {
            var result = from c in _context.Cars
                         join m in _context.CarModels
                         on c.CarModelId equals m.Id
                         join b in _context.BrandCars
                         on m.BrandCarId equals b.Id
                         join t in _context.BodyTypes
                         on m.BodyTypeId equals t.Id
                         join cl in _context.Colors
                         on c.ColorId equals cl.Id
                         where c.Rented == false
                         select new CarDetailDto
                         {
                             Id = c.Id,
                             BrandCarName = b.Name,
                             CarModelName = m.Name,
                             ColorName = cl.ColorName,
                             Capacity = m.Capacity,
                             Mileage = c.Mileage,
                             YearOfIssue = c.YearOfIssue,
                             BodyTypeName = t.Type,
                             Rented = c.Rented
                         };
            return result.ToList();
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
