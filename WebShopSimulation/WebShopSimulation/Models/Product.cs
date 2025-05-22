public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public int ShopId { get; set; }
    public Shop Shop { get; set; }

    public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
