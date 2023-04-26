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
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarModelRepository _carModelRepository;
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;

        public CarController(ICarRepository carRepository, 
                             ICarModelRepository carModelRepository, 
                             IColorRepository colorRepository, 
                             IMapper mapper)
        {
            _carRepository = carRepository;
            _carModelRepository = carModelRepository;
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Car>))]
        public IActionResult GetCars()
        {
            var cars = _mapper.Map<List<CarDto>>(_carRepository.GetCars());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(cars);
        }

        [HttpGet("{carId}")]
        [ProducesResponseType(200, Type = typeof(Car))]
        [ProducesResponseType(400)]
        public IActionResult GetCar(int carId)
        {
            if (!_carRepository.CarExists(carId))
            {
                return NotFound();
            }

            var car = _mapper.Map<CarDto>(_carRepository.GetCar(carId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(car);
        }

        [HttpGet("/api/CarModel/{carModelId}/cars")]
        [ProducesResponseType(200, Type = typeof(ICollection<Car>))]
        [ProducesResponseType(400)]
        public IActionResult GetCarByCarModel(int carModelId)
        {
            var car = _mapper.Map<List<CarDto>>(_carRepository.GetCarByCarModel(carModelId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(car);
        }

        [HttpGet("/api/Color/{colorId}/cars")]
        [ProducesResponseType(200, Type = typeof(ICollection<Car>))]
        [ProducesResponseType(400)]
        public IActionResult GetCarByColor(int colorId)
        {
            var cars = _mapper.Map<List<CarDto>>(_carRepository.GetCarByColor(colorId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(cars);
        }

        [HttpGet("{carId}/carModel")]
        [ProducesResponseType(200, Type = typeof(CarModel))]
        [ProducesResponseType(400)]
        public IActionResult GetCarModelByCar(int carId)
        {
            var carModel = _mapper.Map<CarModelDto>(_carRepository.GetCarModelByCar(carId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(carModel);
        }

        [HttpGet("{carId}/color")]
        [ProducesResponseType(200, Type = typeof(Color))]
        [ProducesResponseType(400)]
        public IActionResult GetColorByCar(int carId)
        {
            var color = _mapper.Map<ColorDto>(_carRepository.GetColorByCar(carId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(color);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCar([FromQuery] int carModelId, [FromQuery] int colorId, [FromBody] CarDto carCreate)
        {
            if (carCreate == null)
            {
                return BadRequest(ModelState);
            }

            var car = _carRepository.GetCars()
                .Where(c => c.Id == carCreate.Id)
                .FirstOrDefault();

            if (car != null)
            {
                ModelState.AddModelError("", "Car already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var carMap = _mapper.Map<Car>(carCreate);

            carMap.CarModel = _carModelRepository.GetCarModel(carModelId);
            carMap.Color = _colorRepository.GetColor(colorId);

            if (!_carRepository.CreateCar(carMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{carId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCar(int carId, [FromBody] CarDto updateCar)
        {
            if (updateCar == null)
            {
                return BadRequest(ModelState);
            }

            if (carId != updateCar.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_carRepository.CarExists(carId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var carMap = _mapper.Map<Car>(updateCar);

            if (!_carRepository.UpdateCar(carMap))
            {
                ModelState.AddModelError("", "Something went wrong updating car");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{carId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCar(int carId)
        {
            if (!_carRepository.CarExists(carId))
            {
                return NotFound();
            }
            var carToDelete = _carRepository.GetCar(carId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_carRepository.DeleteCar(carToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting car");
            }

            return NoContent();
        }
    }
}
