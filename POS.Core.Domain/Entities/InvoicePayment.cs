namespace POS.Core.Domain.Entities
{
    public class InvoicePayment
    {
        public int InvoiceId { get; set; }
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
    }
}
