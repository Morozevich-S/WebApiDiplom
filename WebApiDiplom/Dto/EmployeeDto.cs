using WebApiDiplom.Models;

namespace WebApiDiplom.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int JobTitleId { get; set; }
        public string Passport { get; set; }
        public string Phone { get; set; }
        public JobTitle JobTitle { get; set; }
    }
}
