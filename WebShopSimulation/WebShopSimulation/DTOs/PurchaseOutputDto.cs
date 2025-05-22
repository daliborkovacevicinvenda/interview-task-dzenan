namespace WebShopSimulation.DTOs
{
    public class PurchaseOutputDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime PurchasedAt { get; set; }
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
    }
}
