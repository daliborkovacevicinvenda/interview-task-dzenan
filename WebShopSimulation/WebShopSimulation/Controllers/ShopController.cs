using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShopSimulation.DTOs;

namespace WebShopSimulation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ShopController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/shop
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShopOutputDto>>> GetShops()
        {
            var shops = await _context.Shops.Include(s => s.Products).ThenInclude(p => p.Purchases).ThenInclude(pu => pu.Customer).ToListAsync();

            var shopDtos = shops.Select(s => new ShopOutputDto
            {
                Id = s.Id,
                Name = s.Name,
                Products = s.Products.Select(p => new ProductOutputDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Stock = p.Stock,
                    Purchases = p.Purchases.Select(pu => new PurchaseOutputDto
                    {
                        Id = pu.Id,
                        Quantity = pu.Quantity,
                        PurchasedAt = pu.PurchasedAt,
                        ProductName = p.Name,
                        CustomerName = pu.Customer.Name
                    }).ToList()
                }).ToList()
            }).ToList();

            return Ok(shopDtos);
        }

        // GET: api/shop/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShopOutputDto>> GetShop(int id)
        {
            var shop = await _context.Shops.Include(s => s.Products).ThenInclude(p => p.Purchases).ThenInclude(pu => pu.Customer).FirstOrDefaultAsync(s => s.Id == id);
            
            if (shop == null)
            {
                return NotFound();
            }

            var shopDto = new ShopOutputDto
            {
                Id = shop.Id,
                Name = shop.Name,
                Products = shop.Products.Select(p => new ProductOutputDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Stock = p.Stock,
                    Purchases = p.Purchases.Select(pu => new PurchaseOutputDto
                    {
                        Id = pu.Id,
                        Quantity = pu.Quantity,
                        PurchasedAt = pu.PurchasedAt,
                        ProductName = p.Name,
                        CustomerName = pu.Customer.Name
                    }).ToList()
                }).ToList()
            };

            return Ok(shopDto);
        }

        // POST: api/shop
        [HttpPost]
        public async Task<ActionResult<Shop>> CreateShop(CreateShopDto dto)
        {
            var shop = new Shop
            {
                Name = dto.Name
            };

            _context.Shops.Add(shop);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetShop), new { id = shop.Id }, shop);
        }

        // PUT: api/shop/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShop(int id, Shop updatedShop)
        {
            if (id != updatedShop.Id)
            {
                return BadRequest();
            }

            _context.Entry(updatedShop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Shops.Any(s => s.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/shop/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShop(int id)
        {
            var shop = await _context.Shops.FindAsync(id);
            if (shop == null)
            {
                return NotFound();
            }

            _context.Shops.Remove(shop);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
