public class Purchase
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int Quantity { get; set; }
    public DateTime PurchasedAt { get; set; } = DateTime.UtcNow;
}
