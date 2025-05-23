using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }

    [Precision(18, 2)]
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public int ShopId { get; set; }

    [JsonIgnore]
    public Shop Shop { get; set; }

    public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
