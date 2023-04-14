using WebApiDiplom.Data;
using WebApiDiplom.Interfaces;
using WebApiDiplom.Models;

namespace WebApiDiplom.Repository
{
    public class ColorRepository : IColorRepository
    {
        private readonly DataContext _context;

        public ColorRepository(DataContext context)
        {
            _context = context;
        }

        public bool ColorExists(int id)
        {
            return _context.Colors.Any(c => c.Id == id);
        }

        public Color GetColor(int id)
        {
            return _context.Colors.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<Color> GetColors()
        {
            return _context.Colors.OrderBy(c => c.Id).ToList();
        }
    }
}
