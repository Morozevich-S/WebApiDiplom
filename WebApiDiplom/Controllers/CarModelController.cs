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
    public class CarModelController : Controller
    {
        private readonly IBodyTypeRepository _bodyTypeRepository;
        private readonly IBrandCarRepository _brandCarRepository;
        private readonly ICarModelRepository _carModelRepository;
        private readonly IMapper _mapper;

        public CarModelController(IBodyTypeRepository bodyTypeRepository,
            IBrandCarRepository brandCarRepository, ICarModelRepository carModelRepository, IMapper mapper)
        {
            _bodyTypeRepository = bodyTypeRepository;
            _brandCarRepository = brandCarRepository;
            _carModelRepository = carModelRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CarModel>))]
        public IActionResult GetCarModels()
        {
            var carModels = _mapper.Map<List<CarModelDto>>(_carModelRepository.GetCarModels());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(carModels);
        }

        [HttpGet("{carModelId}")]
        [ProducesResponseType(200, Type = typeof(CarModel))]
        [ProducesResponseType(400)]
        public IActionResult GetCarModel(int carModelId)
        {
            if (!_carModelRepository.CarModelExists(carModelId))
            {
                return NotFound();
            }

            var carModel =  _mapper.Map<CarModelDto>(_carModelRepository.GetCarModel(carModelId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(carModel);
        }

        [HttpGet("{carModelId}/capacity")]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(400)]
        public IActionResult GetCarModelCapacity(int carModelId)
        {
            if (!_carModelRepository.CarModelExists(carModelId))
            {
                return NotFound();
            }

            var capacity = _carModelRepository.GetCarModelCapacity(carModelId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(capacity);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCarModel([FromQuery] int bodyTypeId,
                                            [FromQuery] int brandCarId,
                                            [FromBody] CarModelDto carModelCreate)
        {
            if (carModelCreate == null)
            {
                return BadRequest(ModelState);
            }

            var carModel = _carModelRepository.GetCarModels()
                .Where(c => c.Name.Trim().ToUpper() == carModelCreate.Name.Trim().ToUpper())
                .FirstOrDefault();

            if (carModel != null)
            {
                ModelState.AddModelError("", "Car model already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var carModelMap = _mapper.Map<CarModel>(carModelCreate);

            carModelMap.BodyType = _bodyTypeRepository.GetBodyType(bodyTypeId);
            carModelMap.BrandCar = _brandCarRepository.GetBrandCar(brandCarId);

            if (!_carModelRepository.CreateCarModel(carModelMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{carModelId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCarModel(int carModelId, [FromBody] CarModelDto updateCarModel)
        {
            if (updateCarModel == null)
            {
                return BadRequest(ModelState);
            }

            if (carModelId != updateCarModel.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_carModelRepository.CarModelExists(carModelId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var carModelMap = _mapper.Map<CarModel>(updateCarModel);

            if (!_carModelRepository.UpdateCarModel(carModelMap))
            {
                ModelState.AddModelError("", "Something went wrong updating car model");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{carModelId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCarModel(int carModelId)
        {
            if (!_carModelRepository.CarModelExists(carModelId))
            {
                return NotFound();
            }
            var carModelToDelete = _carModelRepository.GetCarModel(carModelId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_carModelRepository.DeleteCarModel(carModelToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting car model");
            }

            return NoContent();
        }
    }
}
