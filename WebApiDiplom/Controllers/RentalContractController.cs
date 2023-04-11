using Microsoft.AspNetCore.Mvc;
using WebApiDiplom.Interfaces;
using WebApiDiplom.Models;

namespace WebApiDiplom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalContractController : Controller
    {
        private readonly IRentalContractRepository _rentalContractRepository;
        public RentalContractController(IRentalContractRepository rentalContractRepository)
        {
            _rentalContractRepository = rentalContractRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RentalContract>))]
        public IActionResult GetRentalContracts() 
        {
            var contracts = _rentalContractRepository.GetRentalContracts();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(contracts);
        }
    }
}
