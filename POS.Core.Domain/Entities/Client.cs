namespace POS.Core.Domain.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string CardId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal CreditLimit { get; set; }
        public decimal Balance { get; set; }
        public ICollection<ClientPhoneNumber>? PhoneNumbers { get; set; }
        public ICollection<ClientAddress>? Addresses { get; set; }
    }
}
