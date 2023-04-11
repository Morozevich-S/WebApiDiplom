using WebApiDiplom.Models;

namespace WebApiDiplom.Interfaces
{
    public interface IRentalContractRepository
    {
        ICollection<RentalContract> GetRentalContracts();
        RentalContract GetRentalContract(int id);
    }
}
