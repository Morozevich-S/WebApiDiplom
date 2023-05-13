using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiDiplom.Dto;
using WebApiDiplom.Interfaces;
using WebApiDiplom.Models;
using WebApiDiplom.Repository;

namespace WebApiDiplom.Controllers
{
    public class ColorController : BaseApiController
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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateColor([FromBody] ColorDto colorCreate)
        {
            if (colorCreate == null)
            {
                return BadRequest(ModelState);
            }

            var color = _colorRepository.GetColors()
                .Where(c => c.ColorName.Trim().ToUpper() == colorCreate.ColorName.Trim().ToUpper())
                .FirstOrDefault();

            if (color != null)
            {
                ModelState.AddModelError("", "Color already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var colorMap = _mapper.Map<Color>(colorCreate);

            if (!_colorRepository.CreateColor(colorMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{colorId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateColor(int colorId, [FromBody] ColorDto updateColor)
        {
            if (updateColor == null)
            {
                return BadRequest(ModelState);
            }

            if (colorId != updateColor.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_colorRepository.ColorExists(colorId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var colorMap = _mapper.Map<Color>(updateColor);

            if (!_colorRepository.UpdateColor(colorMap))
            {
                ModelState.AddModelError("", "Something went wrong updating color");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{colorId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteColor(int colorId)
        {
            if (!_colorRepository.ColorExists(colorId))
            {
                return NotFound();
            }
            var colorToDelete = _colorRepository.GetColor(colorId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_colorRepository.DeleteColor(colorToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting color");
            }

            return NoContent();
        }
    }
}
