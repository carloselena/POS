namespace POS.Core.Domain.Entities
{
    public class ClientAddress
    {
        public int Id { get; set; }

        public int ClientId { get; set; }
        public Client? Client { get; set; }

        public string Type { get; set; }
        public string Number { get; set; }
        public string Street { get; set; }
        public string Sector { get; set; }
        public string Municipality { get; set; }
        public string Province { get; set; }
        public string? PostalCode { get; set; }
    }
}
