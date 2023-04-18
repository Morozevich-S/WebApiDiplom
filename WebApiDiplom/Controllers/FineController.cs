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
        private readonly IRentalContractRepository _rentalContractRepository;
        private readonly IMapper _mapper;

        public FineController(IFineRepository fineRepository,
                              IRentalContractRepository rentalContractRepository, IMapper mapper)
        {
            _fineRepository = fineRepository;
            _rentalContractRepository = rentalContractRepository;
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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateFine([FromQuery] int rentalContractId, [FromBody] FineDto fineCreate)
        {
            if (fineCreate == null)
            {
                return BadRequest(ModelState);
            }

            var fine = _fineRepository.GetFines()
                .Where(f => f.Id == fineCreate.Id)
                .FirstOrDefault();

            if (fine != null)
            {
                ModelState.AddModelError("", "Fine already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fineMap = _mapper.Map<Fine>(fineCreate);

            fineMap.RentalContract = _rentalContractRepository.GetRentalContract(rentalContractId);

            if (!_fineRepository.CreateFine(fineMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{fineId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateFine(int fineId, [FromBody] FineDto updateFine)
        {
            if (updateFine == null)
            {
                return BadRequest(ModelState);
            }

            if (fineId != updateFine.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_fineRepository.FineExists(fineId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var fineMap = _mapper.Map<Fine>(updateFine);

            if (!_fineRepository.UpdateFine(fineMap))
            {
                ModelState.AddModelError("", "Something went wrong updating fine");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}