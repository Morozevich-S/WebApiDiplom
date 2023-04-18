namespace WebApiDiplom.Models
{
    public class Car
    {
        public int Id { get; set; }
        public DateTime YearOfIssue { get; set; }
        public int Mileage { get; set; }
        public bool Rented { get; set; }
        public int CarModelId { get; set; }
        public int ColorId { get; set; }
        public ICollection<RentalContract> RentalContracts { get; set; }
        public Color Color { get; set; }
        public CarModel CarModel { get; set; }
    }
}
