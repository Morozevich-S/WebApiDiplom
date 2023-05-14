using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApiDiplom.Data;
using WebApiDiplom.Dto;
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

        public bool CreateClient(Client client)
        {
            _context.Clients.Add(client);
            return Save();
        }

        public bool DeleteClient(Client client)
        {
            _context.Remove(client);
            return Save();
        }

        public Client GetClient(int id)
        {
           return _context.Clients.Include(c => c.User).FirstOrDefault(c => c.Id == id);
        }

        public Client GetClient(string passport)
        {
            return _context.Clients.Where(c => c.User.Passport == passport).FirstOrDefault();
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

        public bool UpdateClient(Client client)
        {
            _context.Update(client);
            return Save();
        }

        private Client UpdateRatingAndFines(Client client)
        {
            client.Fines = _context.RentalContracts.Where(r => r.ClientId == client.Id)
                .Select(r => r.Fines).Count();
            if (client.Fines == 0)
            {
                client.Rating = client.DrivingExperience;
            }
            else
            {
                client.Rating = (double)client.DrivingExperience / client.Fines;
            }
            UpdateClient(client);
            return client;
        }

        public IEnumerable<Client> GetClientsByRating()
        {
            var clients = GetClients();
            var clientUpdate = new List<Client>();

            foreach (var client in clients) 
            {
              clientUpdate.Add(UpdateRatingAndFines(client));
            }

            return clientUpdate.OrderBy(c => c.Rating);
        }
    }
}
