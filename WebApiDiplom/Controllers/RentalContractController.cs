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
        private readonly ICarRepository _carRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IRentalContractRepository _rentalContractRepository;
        private readonly IMapper _mapper;

        public RentalContractController(ICarRepository carRepository, 
                                        IClientRepository clientRepository, 
                                        IEmployeeRepository employeeRepository,
                                        IRentalContractRepository rentalContractRepository, 
                                        IMapper mapper)
        {
            _carRepository = carRepository;
            _clientRepository = clientRepository;
            _employeeRepository = employeeRepository;
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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateRentalContract([FromQuery] int carId, [FromQuery] int clientId,
                                                  [FromQuery] int employeeId,
                                                  [FromBody] RentalContractDto rentalContractCreate)
        {
            if (rentalContractCreate == null)
            {
                return BadRequest(ModelState);
            }

            var rentalContract = _rentalContractRepository.GetRentalContracts()
                .Where(r => r.Id == rentalContractCreate.Id)
                .FirstOrDefault();

            if (rentalContract != null)
            {
                ModelState.AddModelError("", "Rental contract already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rentalContractMap = _mapper.Map<RentalContract>(rentalContractCreate);

            rentalContractMap.Car = _carRepository.GetCar(carId);
            rentalContractMap.Client = _clientRepository.GetClient(clientId);
            rentalContractMap.Employee = _employeeRepository.GetEmployee(employeeId);

            if (!_rentalContractRepository.CreateRentalContract(clientId, carId, rentalContractMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{rentalContractId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateRentalContract(int rentalContractId,
                                                  [FromQuery]int clientdId, 
                                                  [FromQuery] int carId,
                                                  [FromBody] RentalContractDto updateRentalContract)
        {
            if (updateRentalContract == null)
            {
                return BadRequest(ModelState);
            }

            if (rentalContractId != updateRentalContract.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_rentalContractRepository.RentalContractExists(rentalContractId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var rentalContractMap = _mapper.Map<RentalContract>(updateRentalContract);

            if (!_rentalContractRepository.UpdadeRentalContract(clientdId, carId, rentalContractMap))
            {
                ModelState.AddModelError("", "Something went wrong updating rental contract");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{rentalContractId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteRentalContract(int rentalContractId)
        {
            if (!_rentalContractRepository.RentalContractExists(rentalContractId))
            {
                return NotFound();
            }
            var rentalContractToDelete = _rentalContractRepository.GetRentalContract(rentalContractId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_rentalContractRepository.DeleteRentalContract(rentalContractToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting rental contract");
            }

            return NoContent();
        }
    }
}
