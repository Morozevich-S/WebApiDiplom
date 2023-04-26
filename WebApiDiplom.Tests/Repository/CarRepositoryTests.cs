using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDiplom.Data;
using WebApiDiplom.Models;
using WebApiDiplom.Repository;

namespace WebApiDiplom.Tests.Repository
{
    public class CarRepositoryTests
    {
        private async Task<DataContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new DataContext(options);
            databaseContext.Database.EnsureCreated();
            if (await databaseContext.Cars.CountAsync() <= 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    databaseContext.Cars.Add(
                        new Car()
                        {
                            YearOfIssue = new DateTime(2019, 6, 10),
                            Color = new Color()
                            {
                                ColorName = "black"
                            },
                            CarModel = new CarModel()
                            {
                                Name = "S300",
                                Capacity = 5,
                                BodyType = new BodyType()
                                {
                                    Type = "sedan"
                                },
                                BrandCar = new BrandCar()
                                {
                                    Name = "Mercedes"
                                }
                            }
                        });
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }

        [Fact]
        public async void CarRepository_GetCar_ReturnCar()
        {
            var id = 1;
            var dbContext = await GetDatabaseContext();
            var carRepository = new CarRepository(dbContext);

            var result = carRepository.GetCar(id);

            result.Should().NotBeNull();
            result.Should().BeOfType<Car>();
        }

        [Fact]
        public async void CarRepository_GetColorByCar_ReturnColor()
        {
            var id = 1;
            var dbContext = await GetDatabaseContext();
            var carRepository = new CarRepository(dbContext);

            var result = carRepository.GetColorByCar(id);

            result.Should().NotBeNull();
            result.Should().BeOfType<Color>();
        }
    }
}
