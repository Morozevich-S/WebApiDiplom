namespace WebApiDiplom.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string ColorName { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
