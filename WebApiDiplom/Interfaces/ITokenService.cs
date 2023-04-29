using WebApiDiplom.Models;

namespace WebApiDiplom.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(Client client);
    }
}
