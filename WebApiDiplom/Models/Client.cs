using Microsoft.AspNetCore.Identity;

namespace WebApiDiplom.Models
{
    public class Client
    {
        public int Id { get; set; }
        public int DrivingExperience { get; set; }
        /// <summary>
        /// The number of orders
        /// </summary>
        public double Rating { get; set; }
        /// <summary>
        /// The number of fines
        /// </summary>
        public int Fines { get; set; }
        public int UserId { get; set; }
        public ICollection<RentalContract> RentalContracts { get; set; }
        public ICollection<ClientBrandCar> ClientBrandCars { get; set; }
        public AppUser User { get; set; }
    }
}
