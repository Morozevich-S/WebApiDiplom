namespace WebApiDiplom.Dto
{
    public class CarDto
    {
        public int Id { get; set; }
        public DateTime YearOfIssue { get; set; }
        public int Mileage { get; set; }
        public bool Rented { get; set; }
        public int CarModelId { get; set; }
        public int ColorId { get; set; }
    }
}
