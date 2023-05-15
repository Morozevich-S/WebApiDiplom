using System.Data;
using System.Diagnostics.Contracts;
using WebApiDiplom.Data;
using WebApiDiplom.Interfaces;
using WebApiDiplom.Models;

namespace WebApiDiplom.Repository
{
    public class RentalContractRepository : IRentalContractRepository
    {
        private readonly DataContext _context;

        public RentalContractRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateRentalContract(int clientId, int carId, RentalContract rentalContract)
        {
            var client = _context.Clients.Where(c => c.Id == clientId).FirstOrDefault();
            var branCarEntity = _context.Cars.Where(c => c.Id == carId)
                                              .Select(cm => cm.CarModel)
                                              .Select(cm => cm.BrandCar).FirstOrDefault();
            var car = _context.Cars.FirstOrDefault(c => c.Id == carId);

            var clientBrandCar = new ClientBrandCar()
            {
                Client = client,
                BrandCar = branCarEntity
            };

            rentalContract.Price = rentalContract.RentalDuration * car.Rate;

            _context.Add(clientBrandCar);
            _context.Add(rentalContract);
            return Save();
        }

        public bool DeleteRentalContract(RentalContract rentalContract)
        {
            _context.Remove(rentalContract);
            //rentalContract.IsDeleted = true;
            return Save();
        }

        public Car GetCarByRentalContract(int id)
        {
            return _context.RentalContracts.Where(c => c.Id == id)
                .Select(c => c.Car).FirstOrDefault();
        }

        public RentalContract GetRentalContract(int id)
        {
            return _context.RentalContracts.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<RentalContract> GetRentalContracts()
        {
            return _context.RentalContracts.OrderBy(c => c.Id).ToList();
        }

        public bool RentalContractExists(int id)
        {
            return _context.RentalContracts.Any(c => c.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdadeRentalContract(int clientdId, int carId, RentalContract rentalContract)
        {
            _context.Update(rentalContract);
            return Save();
        }
        public bool StartRentalContract(int clientId, int carId, RentalContract rentalContract)
        {
            CreateRentalContract(clientId, carId, rentalContract);

            var rentCar = _context.Cars.FirstOrDefault(c => c.Id == carId);
            rentCar.Rented = true;

            return Save();
        }

        public bool FinishRentalContract(int carMiliageFinish, DateTime dateTimeFinish, int rentalContractId)
        {
            var rentalContract = _context.RentalContracts.FirstOrDefault(rc => rc.Id == rentalContractId);
            var rentCar = _context.Cars.FirstOrDefault(c => c.Id == rentalContract.CarId);
            rentCar.Rented = false;

            if (carMiliageFinish > rentCar.Mileage)
            {
                rentCar.Mileage = carMiliageFinish;
            }

            if (dateTimeFinish > rentalContract.Date)
            {
                var duration = new TimeSpan();
                duration = dateTimeFinish - rentalContract.Date;
                rentalContract.RentalDuration = duration.Days;
                rentalContract.Price = duration.Days * rentCar.Rate;
            }

            _context.Update(rentalContract);
            return Save();
        }
    }
}
