using Contract = WebApiDiplom.Models.Contract;

namespace WebApiDiplom.Interfaces
{
    public interface IContractRepository
    {
        ICollection<Contract> GetContracts();
    }
}
