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

            var clientBrandCar = new ClientBrandCar()
            {
                Client = client,
                BrandCar = branCarEntity
            };

            _context.Add(clientBrandCar);
            _context.Add(rentalContract);
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
    }
}
