using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiDiplom.Dto;
using WebApiDiplom.Interfaces;
using WebApiDiplom.Models;

namespace WebApiDiplom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarModelController : Controller
    {
        private readonly ICarModelRepository _carModelRepository;
        private readonly IMapper _mapper;

        public CarModelController(ICarModelRepository carModelRepository, IMapper mapper)
        {
            _carModelRepository = carModelRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CarModel>))]
        public IActionResult GetCarModels()
        {
            var carModels = _mapper.Map<List<CarModelDto>>(_carModelRepository.GetCarModels());
            //var carModels = _carModelRepository.GetCarModels();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(carModels);
        }

        [HttpGet("{carModelId}")]
        [ProducesResponseType(200, Type = typeof(CarModel))]
        [ProducesResponseType(400)]
        public IActionResult GetCarModel(int id)
        {
            if (!_carModelRepository.CarModelExists(id))
            {
                return NotFound();
            }

            var carModel =  _mapper.Map<CarModelDto>(_carModelRepository.GetCarModel(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(carModel);
        }

        [HttpGet("{carModelId}/capacity")]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(400)]
        public IActionResult GetCarModelCapacity(int modelId)
        {
            if (!_carModelRepository.CarModelExists(modelId))
            {
                return NotFound();
            }

            var capacity = _carModelRepository.GetCarModelCapacity(modelId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(capacity);
        }

    }
}
