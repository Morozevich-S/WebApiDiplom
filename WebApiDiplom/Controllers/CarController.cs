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
        private readonly IMapper _mapper;

        public CarController(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Car>))]
        public IActionResult GetCarModels()
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
    }
}
