using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using WebApiDiplom.Data;
using WebApiDiplom.Dto;
using WebApiDiplom.Models;

namespace WebApiDiplom
{
    public static class Seed
    {
        public static async Task SeedDataContext(this IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
                //var context = services.GetRequiredService<DataContext>();
                var userManager = services.GetRequiredService<UserManager<AppUser>>();
                var roleManager = services.GetRequiredService<RoleManager<AppRole>>();

                dataContext.Database.MigrateAsync();

                if (!dataContext.RentalContracts.Any())
                {
                    var contracts = new List<RentalContract>()
                    {
                        new RentalContract()
                        {
                            Client = new Client()
                            {
                                DrivingExperience = 5,
                                User = new AppUser()
                                {
                                    UserName = "Ivanova",
                                    Name = "Elena",
                                    Surname = "Ivanova",
                                    Passport = "MC1234567",
                                    Phone = "+375295556688"
                                }
                            },
                            Employee = new Employee()
                            {
                                User = new AppUser()
                                {
                                    UserName = "Smith",
                                    Name = "Jack",
                                    Surname = "Smith",
                                    Phone = "+375443332211",
                                    Passport = "MP2713355"
                                 },
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
                                CarModel = new CarModel()
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
                        new RentalContract()
                        {
                            Client = new Client()
                            {
                                DrivingExperience = 3,
                                User = new AppUser()
                                {
                                    UserName = "Petrov",
                                    Name = "Vasilii",
                                    Surname = "Petrov",
                                    Passport = "MA7654321",
                                    Phone = "+375297775585"
                                }
                            },
                            Employee = new Employee()
                            {
                                User = new AppUser()
                                {
                                    UserName = "Wiliams",
                                    Name = "Peter",
                                    Surname = "Wiliams",
                                    Phone = "+37544336643",
                                    Passport = "Mk9654361",

                                },
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
                        new RentalContract()
                        {
                            Client = new Client()
                            {
                                DrivingExperience = 13,
                                User = new AppUser()
                                {
                                    UserName = "Zamorskii",
                                    Name = "Leonid",
                                    Surname = "Zamorskii",
                                    Passport = "MA1654386",
                                    Phone = "+375291548743"
                                }
                            },
                            Employee = new Employee()
                            {
                                User = new AppUser()
                                {
                                    UserName = "Rouding",
                                    Name = "Adam",
                                    Surname = "Rouding",
                                    Phone = "+375337649856",
                                    Passport = "MB8745071"
                                },
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
                                CarModel = new CarModel()
                                {
                                    Name = "Z4",
                                    Capacity = 2,
                                    BodyType = new BodyType()
                                    {
                                        Type = "cabriolet"
                                    },
                                    BrandCar = new BrandCar()
                                    {
                                        Name = "BMW"
                                    }
                                }
                            },
                            Date = new DateTime(2023,2,23),
                            RentalDuration = 10,
                        }
                    };

                    var roles = new List<AppRole>
                        {
                            new AppRole{Name = "Client"},
                            new AppRole{Name = "Employee"},
                            new AppRole{Name = "Admin"}
                        };

                    foreach (var role in roles)
                        {
                            await roleManager.CreateAsync(role);
                        }

                    var userAdmin = new AppUser
                        {
                            UserName = "admin",
                            Name = "admin",
                            Surname = "admin",
                            Phone = "admin",
                            Passport = "admin",
                        };

                    var userClient = new AppUser
                        {
                            UserName = "client",
                            Name = "Ivan",
                            Surname = "Berezkin",
                            Phone = "+375297776655",
                            Passport = "MP7776655",
                        };

                    var userEmployee = new AppUser
                        {
                            UserName = "employee",
                            Name = "James",
                            Surname = "Bond",
                            Phone = "+375447007007",
                            Passport = "MP7007007",
                        };

                    var users = dataContext.Users.ToList();

                    foreach (var user in users)
                    {
                        await userManager.CreateAsync(user, "Pa$$w0rd");
                    }

                    await userManager.CreateAsync(userClient, "clientPa$$w0rd");
                    await userManager.CreateAsync(userEmployee, "employeePa$$w0rd");
                    await userManager.CreateAsync(userAdmin, "adminPa$$w0rd");

                    await userManager.AddToRoleAsync(userClient, "Client");
                    await userManager.AddToRoleAsync(userEmployee, "Employee");
                    await userManager.AddToRoleAsync(userAdmin, "Admin");

                    dataContext.RentalContracts.AddRange(contracts);
                    dataContext.SaveChanges();
                }
            }
        }
        //public static async Task SeedUsers(UserManager<AppUser> userManager,
        //                                   RoleManager<AppRole> roleManager)
        //{
        //    if (await userManager.Users.AnyAsync())
        //    {
        //        return;
        //    }

        //    var roles = new List<AppRole>
        //    {
        //        new AppRole{Name = "Client"},
        //        new AppRole{Name = "Employee"},
        //        new AppRole{Name = "Admin"}
        //    };

        //    foreach (var role in roles)
        //    {
        //        await roleManager.CreateAsync(role);
        //    }

        //    var userAdmin = new AppUser
        //    {
        //        UserName = "admin",
        //        Name = "admin",
        //        Surname = "admin",
        //        Phone = "admin",
        //        Passport = "admin",
        //    };

        //    var userClient = new AppUser
        //    {
        //        UserName = "client",
        //        Name = "Ivan",
        //        Surname = "Berezkin",
        //        Phone = "+375297776655",
        //        Passport = "MP7776655",
        //    };

        //    var userEmployee = new AppUser
        //    {
        //        UserName = "employee",
        //        Name = "James",
        //        Surname = "Bond",
        //        Phone = "+375447007007",
        //        Passport = "MP7007007",
        //    };

        //    await userManager.CreateAsync(userClient, "clientPa$$w0rd");
        //    await userManager.CreateAsync(userEmployee, "employeePa$$w0rd");
        //    await userManager.CreateAsync(userAdmin, "adminPa$$w0rd");

        //    await userManager.AddToRoleAsync(userClient, "Client");
        //    await userManager.AddToRoleAsync(userEmployee, "Employee");
        //    await userManager.AddToRoleAsync(userAdmin, "Admin");
        //}
    }
}
