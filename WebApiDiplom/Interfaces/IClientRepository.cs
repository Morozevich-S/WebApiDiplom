using WebApiDiplom.Models;

namespace WebApiDiplom.Interfaces
{
    public interface IClientRepository
    {
        ICollection<Client> GetClients();
        Client GetClient(int id);
        Client GetClient(string passport);
        ICollection<RentalContract> GetRentalContractByClient(int clientId);
        bool ClientExists(int id);
        bool CreateClient(int brandId, Client client);
        bool Save();
    }
}
