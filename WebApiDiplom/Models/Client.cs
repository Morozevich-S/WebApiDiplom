﻿using Microsoft.AspNetCore.Identity;

namespace WebApiDiplom.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int DrivingExperience { get; set; }
        /// <summary>
        /// The number of orders
        /// </summary>
        public int Rating { get; set; }
        public string Passport { get; set; }
        /// <summary>
        /// The number of fines
        /// </summary>
        public int Fines { get; set; }
        public string Phone { get; set; }
        //public int AppUserId { get; set; }
        public ICollection<RentalContract> RentalContracts { get; set; }
        public ICollection<ClientBrandCar> ClientBrandCars { get; set; }
        //public AppUser User { get; set; }
    }
}
