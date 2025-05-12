# Junior Developer Take-Home Assignment: QR Code Shop Simulation

## 🎯 Goal
Create a simple system simulating a **QR-code-based shop interaction**, with two user types: **Customers** and **Shops**.

This task will assess your knowledge of:
- **Frontend development** (mobile or web) — Angular preferred, but open choice
- **Backend API development using ASP.NET Core**
- **Database design and operations**
- **Code versioning using GitHub**

---

## 👤 User Roles & Use Cases

### Shop App (Web or Mobile App)
- Display a list of products, each with a **generated QR code** (encoding product info)
- **Add new products**
- **Remove products from sale**
- **Display inventory (available quantity, sold count)**
- **View report of products sold in the last 30 days**

### Customer App (Web or Mobile App)
- **Scan a QR code from the Shop App**
- **Display product details**
- **Confirm purchase**
- **See purchase history for last month**
- Notify the backend about the purchase

---

## 📦 Backend (ASP.NET Core Web API)
- Manage products, shops, purchases
- Ensure inventory updates upon purchase
- Provide APIs for:
  - Product listing (with QR code info)
  - Purchase confirmation
  - Inventory and sales reports
- Use **Entity Framework Core** or your preferred ORM

---

## 💾 Database
- Any SQL or NoSQL database
- Good relational design if using SQL (tables, foreign keys)
- Track products, shops, purchases, and stock changes

---

## 🔗 Integration Expectations
- **QR code** should encode enough data for the customer app to identify the product (ID, API link, etc.)
- **Shop and Customer apps should be separate apps or roles within a single app**

---

## 🚀 Technical Expectations
- **ASP.NET Core 8+ backend**
- **Frontend framework of choice (Angular preferred)**
- Use **GitHub repository** (provided by us)
- Clean code, regular commits, document your assumptions in the README

---

## 🚫 Limits
- The task is open-ended, do what you can in span of this week and we will review it on Monday 19th

---

## ✅ Bonus (Optional)
- Use **QR code generation library**
- Implement **JWT Authentication** (Customer vs. Shop roles)
- Provide **Docker Compose file** for easy local setup

---

## 🎉 Enjoy
- And dont forget to buy Dalibor a nice cold IPA if you pass
