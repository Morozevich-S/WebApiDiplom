namespace WebApiDiplom.Dto
{
    public class ClientDto
    {
        public int Id { get; set; }
        public int DrivingExperience { get; set; }
        /// <summary>
        /// The number of orders
        /// </summary>
        public int Rating { get; set; }
        /// <summary>
        /// The number of fines
        /// </summary>
        public int Fines { get; set; }
        public UserDto User { get; set; }
    }
}
