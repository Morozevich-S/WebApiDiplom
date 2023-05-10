using Microsoft.AspNetCore.Mvc;
using WebApiDiplom.Models;

namespace WebApiDiplom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        public Client CurrentClient { get; set; }
        public Employee CurrentEmployee { get; set; }
    }
}
