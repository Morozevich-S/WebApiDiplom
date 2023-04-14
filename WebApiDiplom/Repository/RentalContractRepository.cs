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
    }
}
