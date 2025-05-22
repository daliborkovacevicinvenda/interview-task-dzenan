namespace WebShopSimulation.DTOs
{
    public class ShopOutputDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductOutputDto> Products { get; set; }
    }
}
