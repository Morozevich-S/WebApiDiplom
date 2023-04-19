using System.Diagnostics.Contracts;
using WebApiDiplom.Data;
using WebApiDiplom.Interfaces;
using WebApiDiplom.Models;

namespace WebApiDiplom.Repository
{
    public class FineRepository : IFineRepository
    {
        private readonly DataContext _context;

        public FineRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateFine(Fine fine)
        {
            _context.Fines.Add(fine);
            return Save();
        }

        public bool DeleteFine(Fine fine)
        {
            _context.Remove(fine);
            return Save();
        }

        public bool FineExists(int id)
        {
            return _context.Fines.Any(f => f.Id == id);
        }

        public Client GetClientByFine(int id)
        {
            return _context.Fines.Where(f => f.Id == id).
               Select(c => c.RentalContract)
               .Select(r => r.Client).FirstOrDefault();
        }

        public Fine GetFine(int id)
        {
            return _context.Fines.Where(f => f.Id == id).FirstOrDefault();
        }

        public ICollection<Fine> GetFines()
        {
            return _context.Fines.OrderBy(f => f.Id).ToList();
        }

        public RentalContract GetRentalContractByFine(int id)
        {
            return _context.Fines.Where(f => f.Id == id).
                Select(c => c.RentalContract).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateFine(Fine fine)
        {
            _context.Update(fine);
            return Save();
        }
    }
}
