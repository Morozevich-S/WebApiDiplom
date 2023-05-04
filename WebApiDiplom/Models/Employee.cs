namespace WebApiDiplom.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int JobTitleId { get; set; }
        public string Passport { get; set; }
        public string Phone { get; set; }
        public JobTitle JobTitle { get; set; }
        public ICollection<RentalContract> RentalContracts { get; set; }

        public int UserId { get; set; }
        public AppUser User { get; set; }
    }
}
