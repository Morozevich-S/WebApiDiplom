namespace WebApiDiplom.Dto
{
    public class FineDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public int RentalContractId { get; set; }

    }
}
