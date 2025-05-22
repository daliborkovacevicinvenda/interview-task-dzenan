using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShopSimulation.DTOs;

namespace WebShopSimulation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PurchaseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/purchase
        [HttpGet]
        public async Task<IActionResult> MakePurchase(PurchaseDto dto)
        {
            var customer = await _context.Customers.FindAsync(dto.CustomerId);
            if (customer == null)
            {
                return BadRequest("Invalid customer");
            }

            var product = await _context.Products.FindAsync(dto.ProductId);
            if (product == null)
            {
                return BadRequest("Invalid product");
            }

            if (dto.Quantity <= 0)
            {
                return BadRequest("Quantity must be greater than 0");
            }

            if (product.Stock < dto.Quantity)
            {
                return BadRequest("Not enough stock available");
            }

            // Update product stock
            product.Stock -= dto.Quantity;

            // Create purchase
            var purchase = new Purchase
            {
                CustomerId = dto.CustomerId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                PurchasedAt = DateTime.UtcNow
            };

            _context.Purchases.Add(purchase);
            await _context.SaveChangesAsync();

            return Ok("Purchase successful");
        }

        // GET: api/purchase/shop/5
        [HttpGet("shop/{shopId}")]
        public async Task<IActionResult> GetPurchasesForShop(int shopId)
        {
            var purchases = await _context.Purchases
                .Include(p => p.Product)
                .ThenInclude(p => p.Shop)
                .Where(p => p.Product.ShopId == shopId)
                .ToListAsync();

            return Ok(purchases);
        }

        // GET: api/purchase/shop/5/revenue
        [HttpGet("shop/{shopId}/revenue")]
        public async Task<IActionResult> GetShopRevenue(int shopId)
        {
            var revenueByProduct = await _context.Purchases
                .Include(p => p.Product)
                .Where(p => p.Product.ShopId == shopId)
                .GroupBy(p => p.Product.Name)
                .Select(g => new
                {
                    Product = g.Key,
                    TotalRevenue = g.Sum(p => p.Quantity * p.Product.Price),
                    TotalSold = g.Sum(p => p.Quantity)
                })
                .ToListAsync();

            var totalRevenue = revenueByProduct.Sum(r => r.TotalRevenue);

            return Ok(new
            {
                TotalRevenue = totalRevenue,
                Breakdown = revenueByProduct
            });
        }
    }
}
