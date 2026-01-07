namespace POS.Core.Domain.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }
        public string? Note { get; set; }
        public int ClientId { get; set; }
        public Client? Client { get; set; }

        public int CashierId { get; set; }

        public ICollection<InvoiceDetail>? Details { get; set; }
    }
}
