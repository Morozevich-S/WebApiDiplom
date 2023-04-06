namespace WebApiDiplom.Models
{
    public class ClientBrandCar
    {
        public int ClientId { get; set; }
        public int BrandId { get; set; }

        public Client Client { get; set; }
        public BrandCar BrandCar { get; set; }
    }
}
