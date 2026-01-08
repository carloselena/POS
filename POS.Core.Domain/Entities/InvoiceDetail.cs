namespace POS.Core.Domain.Entities
{
    public class InvoiceDetail
    {
        public int Id { get; set; }

        public int InvoiceId { get; set; }
        public Invoice? Invoice {  get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public decimal ProductCost { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductQuantity { get; set; }

        public decimal TaxRate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Total { get; set; }
    }
}
