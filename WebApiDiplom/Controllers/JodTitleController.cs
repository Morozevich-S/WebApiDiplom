using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiDiplom.Dto;
using WebApiDiplom.Interfaces;
using WebApiDiplom.Models;
using WebApiDiplom.Repository;

namespace WebApiDiplom.Controllers
{
    [Authorize]
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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateJobTitle([FromBody] JobTitleDto jobTitleCreate)
        {
            if(jobTitleCreate == null)
            {
                return BadRequest(ModelState);
            }

            var jobTitle = _jobTitleRepository.GetJobTitles()
                .Where(j => j.Title.Trim().ToUpper() ==  jobTitleCreate.Title.Trim().ToUpper())
                .FirstOrDefault();

            if (jobTitle != null) 
            {
                ModelState.AddModelError("", "Job title already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jobTitleMap = _mapper.Map<JobTitle>(jobTitleCreate);

            if(!_jobTitleRepository.CreateJobTitle(jobTitleMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{jobTitleId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateJobTitle(int jobTitleId, [FromBody] JobTitleDto updateJobTitle)
        {
            if (updateJobTitle == null)
            {
                return BadRequest(ModelState);
            }

            if (jobTitleId != updateJobTitle.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_jobTitleRepository.JobTitleExists(jobTitleId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var jobTitleMap = _mapper.Map<JobTitle>(updateJobTitle);

            if (!_jobTitleRepository.UpgradeJobTitle(jobTitleMap))
            {
                ModelState.AddModelError("", "Something went wrong updating job title");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{jobTitleId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteJobTitle(int jobTitleId)
        {
            if (!_jobTitleRepository.JobTitleExists(jobTitleId))
            {
                return NotFound();
            }
            var jobTitleToDelete = _jobTitleRepository.GetJobTitle(jobTitleId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_jobTitleRepository.DeleteJobTitle(jobTitleToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting job title");
            }

            return NoContent();
        }
    }
}
