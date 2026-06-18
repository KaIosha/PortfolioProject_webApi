# 🚀 Portfolio Project – ASP.NET Core Web API (Clean Architecture)

This project is a Simple **Portfolio Management Web API** built using **ASP.NET Core** To apply **Clean Architecture principles** with Repository Pattern and Unit of Work.

It demonstrates how to design scalable, maintainable, and testable backend systems using modern .NET practices.

---

# 📌 Features

- Manage Owners (CRUD operations)
- Manage Portfolio Projects (CRUD operations)
- One-to-Many relationship (Owner → Projects)
- Full RESTful API design
- DTO-based architecture (no direct entity exposure)
- Clean separation of concerns
- Dependency Injection with interfaces
- EF Core Code-First with Migrations

# 🏗️ Architecture

The solution follows **Clean Architecture** with 4 layers:

```text
Solution
│
├── Core
│   ├── Entities
│   ├── Interfaces
│
├── Application
│   ├── DTOs
│   ├── Interfaces (Services)
│   ├── Services
│
├── Infrastructure
│   ├── Data (DbContext)
│   ├── Repositories
│   ├── UnitOfWork
│   ├── Migrations
│
└── WebProject
    ├── Controllers
    ├── Program.cs
```
# 🧠 Design Patterns Used

- Clean Architecture
- Repository Pattern (Generic + Specific Repositories)
- Unit of Work Pattern
- Dependency Injection

---

# 🗄️ Database Design

## Entities

- Owner
- Address
- PortfolioItem (Project)

## Relationships

```

Owner (1) ──── (Many) PortfolioItems
Owner (1) ──── (1) Address
