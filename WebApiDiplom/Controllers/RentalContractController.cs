using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiDiplom.Dto;
using WebApiDiplom.Interfaces;
using WebApiDiplom.Models;
using WebApiDiplom.Repository;

namespace WebApiDiplom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalContractController : Controller
    {
        private readonly IRentalContractRepository _rentalContractRepository;
        private readonly IMapper _mapper;

        public RentalContractController(IRentalContractRepository rentalContractRepository, IMapper mapper)
        {
            _rentalContractRepository = rentalContractRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RentalContract>))]
        public IActionResult GetRentalContracts() 
        {
            var rentalContracts = _mapper.Map<List<RentalContractDto>>(_rentalContractRepository.GetRentalContracts());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(rentalContracts);
        }

        [HttpGet("{rentalContractId}")]
        [ProducesResponseType(200, Type = typeof(RentalContract))]
        [ProducesResponseType(400)]
        public IActionResult GetRentalContract(int rentalContractId)
        {
            if (!_rentalContractRepository.RentalContractExists(rentalContractId))
            {
                return NotFound();
            }

            var rentalContract = _mapper.Map<RentalContractDto>(_rentalContractRepository
                .GetRentalContract(rentalContractId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(rentalContract);
        }

        [HttpGet("{rentalContractId}/car")]
        [ProducesResponseType(200, Type = typeof(Car))]
        [ProducesResponseType(400)]
        public IActionResult GetCarByRentalContract(int rentalContractId)
        {
            var car = _mapper.Map<CarDto>(_rentalContractRepository.GetCarByRentalContract(rentalContractId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(car);
        }
    }
}
