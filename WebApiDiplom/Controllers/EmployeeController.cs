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
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IJobTitleRepository _jobTitleRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, IJobTitleRepository jobTitleRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _jobTitleRepository = jobTitleRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Employee>))]
        public IActionResult GetEmployees()
        {
            var employees = _mapper.Map<List<EmployeeDto>>(_employeeRepository.GetEmployees());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(employees);
        }

        [HttpGet("{employeeId}")]
        [ProducesResponseType(200, Type = typeof(Employee))]
        [ProducesResponseType(400)]
        public IActionResult GetEmployee(int employeeId)
        {
            if (!_employeeRepository.EmployeeExists(employeeId))
            {
                return NotFound();
            }

            var employee = _mapper.Map<EmployeeDto>(_employeeRepository.GetEmployee(employeeId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(employee);
        }

        [HttpGet("/api/RentalContract/{contractId}/employee")]
        [ProducesResponseType(200, Type = typeof(Employee))]
        [ProducesResponseType(400)]
        public IActionResult GetEmployeeByRentalContract(int contractId)
        {
            var employee = _mapper.Map<EmployeeDto>(_employeeRepository.GetEmployeeByRentalContract(contractId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(employee);
        }

        [HttpGet("{employeeId}/rentalContract")]
        [ProducesResponseType(200, Type = typeof(ICollection<Employee>))]
        [ProducesResponseType(400)]
        public IActionResult GetRentalContractByEmployee(int employeeId)
        {
            if (!_employeeRepository.EmployeeExists(employeeId))
            {
                return NotFound();
            }

            var rentalContracts = _mapper.Map<List<RentalContractDto>>(_employeeRepository
                .GetRentalContractByEmployee(employeeId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(rentalContracts);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateEmployee([FromQuery] int jobTitleId, [FromBody] EmployeeDto employeeCreate)
        {
            if (employeeCreate == null)
            {
                return BadRequest(ModelState);
            }

            var employee = _employeeRepository.GetEmployees()
                .Where(e => e.Surname.Trim().ToUpper() == employeeCreate.Surname.Trim().ToUpper())
                .FirstOrDefault();

            if (employee != null)
            {
                ModelState.AddModelError("", "Employee already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeMap = _mapper.Map<Employee>(employeeCreate);

            employeeMap.JobTitle = _jobTitleRepository.GetJobTitle(jobTitleId);

            if (!_employeeRepository.CreateEmployee(employeeMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{employeeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateEmployee(int employeeId, [FromBody] EmployeeDto updateEmployee)
        {
            if (updateEmployee == null)
            {
                return BadRequest(ModelState);
            }

            if (employeeId != updateEmployee.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_employeeRepository.EmployeeExists(employeeId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var employeeMap = _mapper.Map<Employee>(updateEmployee);

            if (!_employeeRepository.UpdateEmployee(employeeMap))
            {
                ModelState.AddModelError("", "Something went wrong updating employee");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
