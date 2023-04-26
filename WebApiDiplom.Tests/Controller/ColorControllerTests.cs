using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDiplom.Controllers;
using WebApiDiplom.Dto;
using WebApiDiplom.Helper;
using WebApiDiplom.Interfaces;
using WebApiDiplom.Models;
using WebApiDiplom.Repository;

namespace WebApiDiplom.Tests.Controller
{
    public class ColorControllerTests
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;

        public ColorControllerTests()
        {
            _colorRepository = A.Fake<IColorRepository>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public void ColorController_GetColors_ReturnOK()
        {
            // Arrange
            var colors = A.Fake<ICollection<ColorDto>>();
            var colorList = A.Fake<List<ColorDto>>();
            A.CallTo(() => _mapper.Map<List<ColorDto>>(colors)).Returns(colorList);
            var controller = new ColorController(_colorRepository, _mapper);

            // Act
            var result = controller.GetColors();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
    }
}
