namespace WebShopSimulation.DTOs;
public class CreateProductDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int ShopId { get; set; }
}