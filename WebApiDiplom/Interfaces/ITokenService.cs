using WebApiDiplom.Models;

namespace WebApiDiplom.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}
