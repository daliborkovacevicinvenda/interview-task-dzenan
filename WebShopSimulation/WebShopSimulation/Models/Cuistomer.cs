public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
