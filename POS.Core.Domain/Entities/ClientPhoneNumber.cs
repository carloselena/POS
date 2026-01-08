namespace POS.Core.Domain.Entities
{
    public class ClientPhoneNumber
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int ClientId { get; set; }
        public Client? Client { get; set; }
    }
}
