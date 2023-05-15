namespace WebApiDiplom.Models
{
    public class ClientBrandCar
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int BrandCarId { get; set; }
        public Client Client { get; set; }
        public BrandCar BrandCar { get; set; }
    }
}
