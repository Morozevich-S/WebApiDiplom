namespace WebApiDiplom.Models
{
    public class BrandCar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CarModel> CarModels { get; set; }
        public ICollection<ClientBrandCar> ClientBrandCars { get; set; }
    }
}
