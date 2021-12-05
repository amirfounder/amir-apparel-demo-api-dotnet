namespace Amir.Apparel.Demo.Api.Dotnet.API.DTOs
{
    public class LineItemRequestDTO
    {
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public decimal TotalCost { get; set; }
        public int Quantity { get; set; }
    }
}
