﻿namespace WebApiDiplom.Models
{
    public class BrandCar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Model> Models { get; set; }
    }
}
