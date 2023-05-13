using WebApiDiplom.Models;

namespace WebApiDiplom.Interfaces
{
    public interface IUserRepository
    {
        AppUser GetUser (int id);
        bool UserExists(int id);
        bool Save();
    }
}
