﻿using System.Diagnostics.Metrics;
using WebApiDiplom.Data;
using WebApiDiplom.Models;
using Contract = WebApiDiplom.Models.Contract;

namespace WebApiDiplom
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.Contracts.Any())
            {
                var contracts = new List<Contract>()
                {
                    new Contract()
                    {
                        Client = new Client()
                        {
                            Name = "Elena",
                            Surname = "Ivanova",
                            Passport = "MC1234567",
                            Phone = "+375295556688",
                            DrivingExperience = 5
                        },
                        Employee = new Employee()
                        {
                            Name = "Jack",
                            Surname = "Smith",
                            Phone = "+375443332211",
                            Passport = "MP2713355",
                            JobTitle = new JobTitle()
                            {
                                Title = "junior manager",
                                Salary = 500
                            }
                        },
                        Car = new Car()
                        {
                            YearOfIssue = new DateTime(2020,1,1),
                            Color = new Color()
                            {
                                ColorName = "red"
                            },
                            Model = new Model()
                            {
                                Name = "Golf",
                                Capacity = 5,
                                BodyType = new BodyType()
                                {
                                    Type = "hatcback"
                                },
                                BrandCar = new BrandCar()
                                {
                                    Name = "Volkswagen"
                                }
                            }
                        },
                        Date = new DateTime(2023,1,1),
                        RentalDuration = 5,
                        Fines = new List<Fine>()
                        {
                            new Fine()
                            {
                                Date = new DateTime(2023,1,2),
                                Description = "speeding fine",
                                Amount  = 50
                            },
                            new Fine()
                            {
                                Date = new DateTime(2023,1,2),
                                Description = "parking ticket",
                                Amount  = 25
                            },
                             new Fine()
                            {
                                Date = new DateTime(2023,1,3),
                                Description = "oncoming lane penalty",
                                Amount  = 100
                            }
                        }
                    },
                    new Contract()
                    {
                        Client = new Client()
                        {
                            Name = "Vasilii",
                            Surname = "Petrov",
                            Passport = "MA7654321",
                            Phone = "+375297775585",
                            DrivingExperience = 3
                        },
                        Employee = new Employee()
                        {
                            Name = "Peter",
                            Surname = "Wiliams",
                            Phone = "+37544336643",
                            Passport = "Mk9654361",
                            JobTitle = new JobTitle()
                            {
                                Title = "middle manager",
                                Salary = 700
                            }
                        },
                        Car = new Car()
                        {
                            YearOfIssue = new DateTime(2019,6,10),
                            Color = new Color()
                            {
                                ColorName = "black"
                            },
                            Model = new Model()
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
                        },
                        Date = new DateTime(2023,2,1),
                        RentalDuration = 15,
                        Fines = new List<Fine>()
                        {
                            new Fine()
                            {
                                Date = new DateTime(2023,2,12),
                                Description = "speeding fine",
                                Amount  = 50
                            }
                        }
                    },
                    new Contract()
                    {
                        Client = new Client()
                        {
                            Name = "Leonid",
                            Surname = "Zamorskii",
                            Passport = "MA1654386",
                            Phone = "+375291548743",
                            DrivingExperience = 13
                        },
                        Employee = new Employee()
                        {
                            Name = "Adam",
                            Surname = "Rouding",
                            Phone = "+375337649856",
                            Passport = "MB8745071",
                            JobTitle = new JobTitle()
                            {
                                Title = "senior manager",
                                Salary = 1000
                            }
                        },
                        Car = new Car()
                        {
                            YearOfIssue = new DateTime(2010,10,10),
                            Color = new Color()
                            {
                                ColorName = "white"
                            },
                            Model = new Model()
                            {
                                Name = "SLK280",
                                Capacity = 2,
                                BodyType = new BodyType()
                                {
                                    Type = "cabriolet"
                                },
                                BrandCar = new BrandCar()
                                {
                                    Name = "Mercedes"
                                }
                            }
                        },
                        Date = new DateTime(2023,2,23),
                        RentalDuration = 10,
                    }
                };
                dataContext.Contracts.AddRange(contracts);
                dataContext.SaveChanges();
            }
        }
    }
}