using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDiplom.Controllers;
using WebApiDiplom.Dto;
using WebApiDiplom.Interfaces;

namespace WebApiDiplom.Tests.Controller
{
    public class BodyTypeControllerTests
    {
        private readonly IBodyTypeRepository _bodyTypeRepository;
        private readonly IMapper _mapper;

        public BodyTypeControllerTests()
        {
            _bodyTypeRepository = A.Fake<IBodyTypeRepository>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public void BodyTypeController_GetBodyTypes_ReturnOK()
        {
            var bodyTypes = A.Fake<ICollection<BodyTypeDto>>();
            var bodyTypeList = A.Fake<List<BodyTypeDto>>();
            A.CallTo(() => _mapper.Map<List<BodyTypeDto>>(bodyTypes)).Returns(bodyTypeList);
            var controller = new BodyTypeController(_bodyTypeRepository, _mapper);

            var result = controller.GetBodyTypes();

            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void BodyTypeController_CreateBodyTypes_ReturnOk()
        {

        }
    }
}
