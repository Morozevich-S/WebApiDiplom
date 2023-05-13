using System.ComponentModel.DataAnnotations;

namespace WebApiDiplom.Dto
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Passport { get; set; }
        public string Phone { get; set; }
    }
}
