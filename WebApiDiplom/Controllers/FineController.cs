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
    public class FineController : Controller
    {
        private readonly IFineRepository _fineRepository;
        private readonly IMapper _mapper;
        
        public FineController(IFineRepository fineRepository, IMapper mapper)
        {
            _fineRepository = fineRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Fine>))]
        public IActionResult GetFines()
        {
            var fines = _mapper.Map<List<FineDto>>(_fineRepository.GetFines());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(fines);
        }

        [HttpGet("{fineId}")]
        [ProducesResponseType(200, Type = typeof(Fine))]
        [ProducesResponseType(400)]
        public IActionResult GetFine(int fineId)
        {
            if (!_fineRepository.FineExists(fineId))
            {
                return NotFound();
            }

            var fine = _mapper.Map<FineDto>(_fineRepository.GetFine(fineId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(fine);
        }

        [HttpGet("{fineId}/client")]
        [ProducesResponseType(200, Type = typeof(Client))]
        [ProducesResponseType(400)]
        public IActionResult GetClientByFine(int fineId)
        {
            if (!_fineRepository.FineExists(fineId))
            {
                return NotFound();
            }

            var client = _mapper.Map<ClientDto>(_fineRepository.GetClientByFine(fineId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(client);
        }

        [HttpGet("{fineId}/rentalContract")]
        [ProducesResponseType(200, Type = typeof(RentalContract))]
        [ProducesResponseType(400)]
        public IActionResult GetRentalContractByFine(int fineId)
        {
            if (!_fineRepository.FineExists(fineId))
            {
                return NotFound();
            }

            var rentalContract = _mapper.Map<RentalContract>(_fineRepository.GetRentalContractByFine(fineId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(rentalContract);
        }
    }
}
