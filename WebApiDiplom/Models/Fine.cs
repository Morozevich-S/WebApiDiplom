﻿namespace WebApiDiplom.Models
{
    public class Fine
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public int ContractId { get; set; }
    }
}