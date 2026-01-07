namespace POS.Core.Domain.Entities
{
    public class Supplier
    {
        public int Id { get; set; }
        public string RNC { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Salesperson { get; set; }
        public string SalespersonPhoneNumber { get; set; }
        public SupplierAddress? Address { get; set; }
    }
}
