namespace Amir.Apparel.Demo.Api.Dotnet.API.DTOs
{
    public class LineItemResponseDTO
    {
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public decimal TotalCost { get; set; }
        public int Quantity { get; set; }
    }
}
