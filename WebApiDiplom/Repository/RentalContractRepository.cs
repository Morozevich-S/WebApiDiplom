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

        public RentalContract GetRentalContract(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<RentalContract> GetRentalContracts() 
        {
            return _context.RentalContracts.OrderBy(c => c.Id).ToList();
        }
    }
}
