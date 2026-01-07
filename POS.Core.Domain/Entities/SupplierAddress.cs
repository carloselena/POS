namespace POS.Core.Domain.Entities
{
    public class SupplierAddress
    {
        public int Id { get; set; } // FK, PK, SupplierId
        public string Number { get; set; }
        public string Street { get; set; }
        public string Sector { get; set; }
        public string Municipality { get; set; }
        public string Province { get; set; }
        public string? PostalCode { get; set; }
    }
}
