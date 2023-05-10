using WebApiDiplom.Models;

namespace WebApiDiplom.Dto
{
    public class CarDetailDto
    {
        public int Id { get; set; }
        public string BrandCarName { get; set; }
        public string CarModelName { get; set; }
        public string ColorName { get; set; }
        public string BodyTypeName { get; set; }
        public DateTime YearOfIssue { get; set; }
        public int Mileage { get; set; }
        public int Capacity { get; set; }
        public bool Rented { get; set; }
    }
}
