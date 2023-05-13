namespace WebApiDiplom.Models
{
    public class RentalContract
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int CarId { get; set; }
        public DateTime Date { get; set; }
        public int RentalDuration { get; set; }
        public decimal Price { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public Client Client { get; set; }
        public Car Car { get; set; }
        public ICollection<Fine> Fines { get; set; }
        public bool IsDeleted { get; set; }
    }
}
