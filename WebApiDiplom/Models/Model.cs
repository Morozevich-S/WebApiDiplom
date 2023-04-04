namespace WebApiDiplom.Models
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int Capacity { get; set; }
        public int TypeId { get; set; }
        public BrandCar BrandCar { get; set; }
        public BodyType BodyType { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
