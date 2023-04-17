using System.Linq;
using WebApiDiplom.Data;
using WebApiDiplom.Interfaces;
using WebApiDiplom.Models;

namespace WebApiDiplom.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;

        public ClientRepository(DataContext context)
        {
            _context = context;
        }

        public bool ClientExists(int id)
        {
            return _context.Clients.Any(c => c.Id == id);
        }

        public bool CreateClient(int brandId, Client client)
        {
            var clientBrandCarEntity = _context.BrandCars.Where(c => c.Id == brandId).FirstOrDefault();

            var clientBrandCar = new ClientBrandCar()
            {
                Client = client,
                BrandCar = clientBrandCarEntity
            };

            _context.Add(clientBrandCar);
            _context.Add(client);

            return Save();
        }

        public Client GetClient(int id)
        {
            return _context.Clients.Where(c => c.Id == id).FirstOrDefault();
        }

        public Client GetClient(string passport)
        {
            return _context.Clients.Where(c => c.Passport == passport).FirstOrDefault();
        }

        public ICollection<Client> GetClients()
        {
            return _context.Clients.ToList();
        }

        public ICollection<RentalContract> GetRentalContractByClient(int clientId)
        {
            return _context.RentalContracts.Where(rc => rc.ClientId == clientId).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
