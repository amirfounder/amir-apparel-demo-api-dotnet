namespace Amir.Apparel.Demo.Api.Dotnet.Data.Models
{
    public class LineItem : Entity
    {
        public Purchase Purchase { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }
    }
}
