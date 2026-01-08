namespace POS.Core.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime TakenAt { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public string? Network { get; set; }
        public string? CardLast4Digits { get; set; }
        public string? Reference { get; set; } // Número de aprobación
        public int UserId { get; set; }
    }
}
