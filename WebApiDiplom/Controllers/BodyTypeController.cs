using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiDiplom.Dto;
using WebApiDiplom.Interfaces;
using WebApiDiplom.Models;

namespace WebApiDiplom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodyTypeController : Controller
    {
        private readonly IBodyTypeRepository _bodyTypeRepository;
        private readonly IMapper _mapper;

        public BodyTypeController(IBodyTypeRepository bodyTypeRepository, IMapper mapper)
        {
            _bodyTypeRepository = bodyTypeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BodyType>))]
        public IActionResult GetBodyTypes()
        {
            var bodyTypes = _mapper.Map<List<BodyTypeDto>>(_bodyTypeRepository.GetBodyTypes());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(bodyTypes);
        }

        [HttpGet("{bodyTypeId}")]
        [ProducesResponseType(200, Type = typeof(BodyType))]
        [ProducesResponseType(400)]
        public IActionResult GetBodyType(int bodyTypeId)
        {
            if (!_bodyTypeRepository.BodyTypeExists(bodyTypeId))
            {
                return NotFound();
            }

            var bodyType = _mapper.Map<BodyTypeDto>(_bodyTypeRepository.GetBodyType(bodyTypeId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(bodyType);
        }

        [HttpGet("/api/CarModel/{carModelId}/bodyType")]
        [ProducesResponseType(200, Type = typeof(BodyType))]
        [ProducesResponseType(400)]
        public IActionResult GetBodyTypeByCarModel(int carModelId)
        {
            var country = _mapper.Map<BodyTypeDto>(_bodyTypeRepository.GetBodyTypeByCarModel(carModelId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(country);
        }

        [HttpGet("{bodyTypeId}/carModel")]
        [ProducesResponseType(200, Type = typeof(ICollection<CarModel>))]
        [ProducesResponseType(400)]
        public IActionResult GetCarModelsByBodyType(int bodyTypeId)
        {
            var carModels = _mapper.Map<List<CarModelDto>>(_bodyTypeRepository.GetCarModelsByBodyType(bodyTypeId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(carModels);
        }
    }
}
