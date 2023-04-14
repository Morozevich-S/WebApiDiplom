using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiDiplom.Dto;
using WebApiDiplom.Interfaces;
using WebApiDiplom.Models;

namespace WebApiDiplom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : Controller
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;

        public ColorController(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Color>))]
        public IActionResult GetColors()
        {
            var colors = _mapper.Map<List<ColorDto>>(_colorRepository.GetColors());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(colors);
        }

        [HttpGet("{colorId}")]
        [ProducesResponseType(200, Type = typeof(Color))]
        [ProducesResponseType(400)]
        public IActionResult GetColor(int colorId)
        {
            if (!_colorRepository.ColorExists(colorId))
            {
                return NotFound();
            }

            var color = _mapper.Map<ColorDto>(_colorRepository.GetColor(colorId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(color);
        }
    }
}
