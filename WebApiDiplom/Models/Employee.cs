namespace WebApiDiplom.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int JobTitleId { get; set; }
        public JobTitle JobTitle { get; set; }
        public ICollection<RentalContract> RentalContracts { get; set; }
        public int UserId { get; set; }
        public AppUser User { get; set; }
        public bool IsDeleted { get; set; }
    }
}
