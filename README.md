# WebShop Simulation – Take-Home Assignment

This project is a simple ASP.NET Core Web API simulating a web shop platform with two user roles: **Shops** and **Customers**. It allows shops to manage their inventory and view revenue reports, while customers can browse products and make purchases.

---

## Tech Stack

- ASP.NET Core 8
- Entity Framework Core
- SQL Server (LocalDB)
- Swagger / OpenAPI for documentation
- C#

---

## How to Run

1. Clone the repo
2. Open in Visual Studio 2022+
3. Trust the HTTPS certificate if prompted
4. Press ▶️ (F5) to run
5. Swagger UI will open at: https://localhost:<port>/swagger

---

## User Roles

### Shops
- Add/edit/delete their own products
- View purchases for their products
- View revenue reports (total and per product)

### Customers
- View available products
- Purchase products

---

## Key API Endpoints

### Products
- 'GET /api/product' – list all products 
- 'POST /api/product' – create a product

{
	"name": "Digital Vending Machine",
	"price": 50,
	"stock": 10,
	"shopId": 1
}

### Shops
- GET /api/shop – list all shops with products and purchases
- GET /api/shop/{id} – single shop with products and purchases
- POST /api/shop – create a shop

{
	"name": "Invenda"
}

### Purchases
POST /api/purchase – make a purchase

{
  "customerId": 1,
  "productId": 1,
  "quantity": 2
}

GET /api/purchase/shop/{shopId} – list purchases for a shop
GET /api/purchase/shop/{shopId}/revenue – revenue report by product and total

---

## Design Decisions
- Used DTOs for both input and output to avoid circular references and keep Swagger clean.
- Added validation to all POST endpoints (e.g., stock check before purchase).
- Used .ThenInclude() to eager-load related entities where needed.
- Avoided overfetching and protected from infinite loops using ReferenceHandler.IgnoreCycles (only temporarily, replaced with DTO-based projection).

## Notes
- Customer creation is not exposed as an endpoint. You can insert test customers via database (in SQL Server Object Explorer).
- Swagger shows only necessary fields thanks to use of input DTOs (CreateShopDto, CreateProductDto, etc.).

## Folder Structure
- Controllers/ – API endpoints
- Models/ – EF Core entity models
- DTOs/ – Input/output models used for cleaner APIs
- Data/ – ApplicationDbContext with EF Core config