<div align="center">

# 🛍️ MyStore

### Modern E-Commerce Web Application

Built with **ASP.NET Core 8 Razor Pages**, **Entity Framework Core**, **SQL Server**, and **ASP.NET Identity**.

---

![.NET](https://img.shields.io/badge/.NET-8.0-purple)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET-Core-blue)
![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-red)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core-green)
![License](https://img.shields.io/badge/License-MIT-success)

</div>

---

# 📖 Overview

MyStore is a complete e-commerce web application developed using **ASP.NET Core Razor Pages**.

The application provides a secure authentication system, role-based authorization, product management, category management, image uploading, email confirmation, and an organized repository architecture following modern ASP.NET Core best practices.

---

# ✨ Features

## 🔐 Authentication & Security

- ASP.NET Core Identity
- User Registration
- Secure Login
- Email Confirmation
- Cookie Authentication
- Password Policies
- Role-Based Authorization
- Policy-Based Authorization

---

## 👤 User Management

- User Accounts
- User Roles
- Manage Users
- Protected Pages
- Authorization Policies

---

## 📦 Product Management

- Create Products
- Edit Products
- Delete Products
- Product Details
- Product Images
- Product Stock
- Product Price
- Publisher Field
- Soft Delete Support

---

## 🗂 Category Management

- Create Categories
- Edit Categories
- Delete Categories
- Browse Categories
- View Category Products

---

## 🖼 Image Upload

- Upload Product Images
- Multiple Images Support
- Image Storage Service

---

## 📧 Email Services

- Email Confirmation
- SMTP Configuration
- MailKit Integration
- MimeKit Integration

---

## 🗄 Database

- SQL Server
- Entity Framework Core
- Code First
- EF Core Migrations
- Data Seeding

---

## 🏗 Architecture

- Razor Pages
- Repository Pattern
- Dependency Injection
- Services Layer
- Configuration Classes
- Clean Folder Structure

---

## 🔍 Extra Features

- Pagination
- Sorting
- Search Ready
- Validation using Data Annotations
- Repository Abstraction
- Custom Upload Service

---

# 🛠 Technologies

| Technology | Version |
|------------|---------|
| ASP.NET Core | 8 |
| Razor Pages | ✔ |
| Entity Framework Core | 8 |
| SQL Server | ✔ |
| ASP.NET Identity | ✔ |
| MailKit | ✔ |
| MimeKit | ✔ |
| Bootstrap | ✔ |
| C# | 12 |

---

# 📁 Project Structure

```
MyStore
│
├── Data
├── Models
├── ModelsView
├── Repository
├── Services
├── Pages
├── Migrations
├── Options
├── wwwroot
└── Program.cs
```

---

# 🚀 Getting Started

## Clone Repository

```bash
git clone https://github.com/YourUserName/MyStore.git
```

---

## Restore Packages

```bash
dotnet restore
```

---

## Update Database

```bash
dotnet ef database update
```

---

## Run Project

```bash
dotnet run
```

---

# ⚙ Configuration

Update the following inside **appsettings.json**

- SQL Server Connection String
- SMTP Settings

Example:

```json
"ConnectionStrings": {
  "LocalSQL": "YOUR_CONNECTION_STRING"
}
```

---

# 🔑 Authorization

The application uses:

- ASP.NET Identity
- Roles
- Authorization Policies
- Cookie Authentication

Example Policies:

- Admin
- Edit
- Client

---

# 📸 Screenshots

Add screenshots here.

Example:

```
/screenshots/home.png
/screenshots/products.png
/screenshots/categories.png
```

---

# 📚 Main Functionalities

✔ User Registration

✔ Email Confirmation

✔ Login / Logout

✔ Product CRUD

✔ Category CRUD

✔ Product Images

✔ User Management

✔ Authorization

✔ Repository Pattern

✔ Pagination

✔ Sorting

✔ SQL Server Integration

✔ Entity Framework Core

---

# 👨‍💻 Developed By

**Moayad Al-Madhoun**

ASP.NET Core Developer

---

# ⭐ Support

If you like this project, don't forget to give it a ⭐ on GitHub.

---

<div align="center">

### Thank you for visiting MyStore ❤️

</div>
