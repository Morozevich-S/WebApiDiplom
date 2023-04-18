using WebApiDiplom.Models;

namespace WebApiDiplom.Interfaces
{
    public interface IColorRepository
    {
        ICollection<Color> GetColors();
        Color GetColor(int id);
        bool ColorExists(int id);
        bool CreateColor(Color color);
        bool UpdateColor(Color color);
        bool Save();
    }
}
