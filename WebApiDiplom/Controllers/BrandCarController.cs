using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiDiplom.Dto;
using WebApiDiplom.Interfaces;
using WebApiDiplom.Models;

namespace WebApiDiplom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandCarController : Controller
    {
        private readonly IBrandCarRepository _brandCarRepository;
        private readonly IMapper _mapper;

        public BrandCarController(IBrandCarRepository brandCarRepository, IMapper mapper)
        {
            _brandCarRepository = brandCarRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BrandCar>))]
        public IActionResult GetBrandCars()
        {
            var brandCars = _mapper.Map<List<BrandCarDto>>(_brandCarRepository.GetBrandCars());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(brandCars);
        }

        [HttpGet("{brandCarId}")]
        [ProducesResponseType(200, Type = typeof(BrandCar))]
        [ProducesResponseType(400)]
        public IActionResult GetBrandCar(int brandCarId)
        {
            if (!_brandCarRepository.BrandCarExists(brandCarId))
            {
                return NotFound();
            }

            var brandCar = _mapper.Map<BrandCarDto>(_brandCarRepository.GetBrandCar(brandCarId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(brandCar);
        }

        [HttpGet("{brandCarId}/carModel")]
        [ProducesResponseType(200, Type = typeof(ICollection<CarModel>))]
        [ProducesResponseType(400)]
        public IActionResult GetCarModelsByBrandCar(int brandCarId)
        {
            var carModels = _mapper.Map<List<CarModelDto>>(_brandCarRepository.GetCarModelByBrendCar(brandCarId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(carModels);
        }
    }
}
