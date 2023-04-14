using WebApiDiplom.Models;

namespace WebApiDiplom.Dto
{
    public class RentalContractDto
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int CarId { get; set; }
        public DateTime Date { get; set; }
        public int RentalDuration { get; set; }
        public int Price { get; set; }
        public int EmployeeId { get; set; }
    }
}
