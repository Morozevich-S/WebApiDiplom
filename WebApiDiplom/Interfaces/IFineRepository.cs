using WebApiDiplom.Models;

namespace WebApiDiplom.Interfaces
{
    public interface IFineRepository
    {
        ICollection<Fine> GetFines();
        Fine GetFine(int id);
        RentalContract GetRentalContractByFine(int id);
        Client GetClientByFine(int id);
        bool FineExists(int id);
        bool CreateFine(Fine fine);
        bool Save();
    }
}
