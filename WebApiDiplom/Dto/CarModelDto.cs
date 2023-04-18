namespace WebApiDiplom.Dto
{
    public class CarModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandCarId { get; set; }
        public int Capacity { get; set; }
        public int BodyTypeId { get; set; }
    }
}
