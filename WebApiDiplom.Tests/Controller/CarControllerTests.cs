using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDiplom.Controllers;
using WebApiDiplom.Dto;
using WebApiDiplom.Interfaces;
using WebApiDiplom.Models;

namespace WebApiDiplom.Tests.Controller
{
    public class CarControllerTests
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarModelRepository _carModelRepository;
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;

        public CarControllerTests()
        {
            _carRepository = A.Fake<ICarRepository>();
            _carModelRepository = A.Fake<ICarModelRepository>();
            _colorRepository = A.Fake<IColorRepository>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public void CarController_GetCars_ReturnOK()
        {
            var cars = A.Fake<ICollection<CarDto>>();
            var carList = A.Fake<List<CarDto>>();
            A.CallTo(() => _mapper.Map<List<CarDto>>(cars)).Returns(carList);
            var controller = new CarController(_carRepository, _carModelRepository, 
                                               _colorRepository, _mapper);

            var result = controller.GetCars();

            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        //[Fact]
        //public void BodyTypeController_CreateBodyTypes_ReturnOk()
        //{
        //    int carModelId = 1;
        //    int carColorId = 2;
        //    var car = A.Fake<Car>();
        //    var carCreate = A.Fake<CarDto>();
        //    var cars = A.Fake<ICollection<CarDto>>();
        //    var carList = A.Fake<List<CarDto>>();
        //    var carMap = A.Fake<Car>();

        //    carMap.CarModel = _carModelRepository.GetCarModel(carModelId);
        //    carMap.Color = _colorRepository.GetColor(carColorId);
        //    A.CallTo(() => _carRepository.GetCars()
        //                   .Where(c => c.Id == carCreate.Id)
        //                   .FirstOrDefault()).Returns(car);
        //    A.CallTo(() => _mapper.Map<Car>(carCreate)).Returns(car);
        //    A.CallTo(() => _carRepository.CreateCar(carMap)).Returns(true);
        //    var controller = new CarController(_carRepository, _carModelRepository, _colorRepository, _mapper);

        //    var result = controller.CreateCar(carModelId, carColorId, carCreate);

        //    result.Should().NotBeNull();
        //}
    }
}
