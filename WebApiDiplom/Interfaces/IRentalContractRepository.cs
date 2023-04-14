using WebApiDiplom.Models;

namespace WebApiDiplom.Interfaces
{
    public interface IRentalContractRepository
    {
        ICollection<RentalContract> GetRentalContracts();
        RentalContract GetRentalContract(int id);
        bool RentalContractExists(int id);
        Car GetCarByRentalContract(int id);
    }
}
