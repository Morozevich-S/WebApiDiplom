using WebApiDiplom.Data;
using WebApiDiplom.Interfaces;
using Contract = WebApiDiplom.Models.Contract;


namespace WebApiDiplom.Repository
{
    public class ContractRepository : IContractRepository
    {
        private readonly DataContext _context;

        public ContractRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Contract> GetContracts() 
        {
            return _context.Contracts.OrderBy(c => c.Id).ToList();
        }
    }
}
