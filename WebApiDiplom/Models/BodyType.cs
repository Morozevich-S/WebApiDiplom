namespace WebApiDiplom.Models
{
    public class BodyType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public ICollection<Model> Models { get; set; }
    }
}
