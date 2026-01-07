namespace POS.Core.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string BarCode { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public decimal WholesaleQuantity { get; set; }
        public decimal WholesalePrice { get; set; }
        public decimal Stock { get; set; }
        public decimal MinStock { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public int MeasurementUnitId { get; set; }
        public MeasurementUnit? MeasurementUnit { get; set; }
    }
}
