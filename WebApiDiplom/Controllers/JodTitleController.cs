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
    public class JodTitleController : Controller
    {
        private readonly IJobTitleRepository _jobTitleRepository;
        private readonly IMapper _mapper;

        public JodTitleController(IJobTitleRepository jobTitleRepository, IMapper mapper)
        {
            _jobTitleRepository = jobTitleRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<JobTitle>))]
        public IActionResult GetJobTitles()
        {
            var jobTitles = _mapper.Map<List<JobTitleDto>>(_jobTitleRepository.GetJobTitles());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(jobTitles);
        }

        [HttpGet("{jobTitleId}")]
        [ProducesResponseType(200, Type = typeof(JobTitle))]
        [ProducesResponseType(400)]
        public IActionResult GetJobTitle(int jobTitleId)
        {
            if (!_jobTitleRepository.JobTitleExists(jobTitleId))
            {
                return NotFound();
            }

            var jobTitle = _mapper.Map<JobTitleDto>(_jobTitleRepository.GetJobTitle(jobTitleId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(jobTitle);
        }

        [HttpGet("{jobTitleId}/employee")]
        [ProducesResponseType(200, Type = typeof(ICollection<Employee>))]
        [ProducesResponseType(400)]
        public IActionResult GetEmployeeByJobTitle(int jobTitleId)
        {
            var employees = _mapper.Map<List<EmployeeDto>>(_jobTitleRepository.GetEmployeeByJobTitle(jobTitleId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(employees);
        }
    }
}
