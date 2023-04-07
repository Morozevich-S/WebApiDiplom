using Microsoft.AspNetCore.Mvc;
using WebApiDiplom.Interfaces;
using Contract = WebApiDiplom.Models.Contract;

namespace WebApiDiplom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : Controller
    {
        private readonly IContractRepository _contractRepository;
        public ContractController(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Contract>))]
        public IActionResult GetContracts() 
        {
            var contrcts = _contractRepository.GetContracts();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(contrcts);
        }
    }
}
