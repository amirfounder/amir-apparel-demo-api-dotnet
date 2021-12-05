using System.ComponentModel.DataAnnotations.Schema;

namespace Amir.Apparel.Demo.Api.Dotnet.Data.Models
{
    public class LineItem : Entity
    {
        [NotMapped]
        public Purchase Purchase { get; set; }
        [NotMapped]
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int PurchaseId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }
    }
}
