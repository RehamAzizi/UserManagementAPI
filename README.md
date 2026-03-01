# TaskOne – ASP.NET Core User Management API

**TaskOne** is a backend project built with **ASP.NET Core**, showcasing key backend practices and modern API design for learning and professional development.

---

## Key Features

- Minimal APIs for lightweight and maintainable endpoints  
- JWT Authentication for secure API access  
- Basic Authentication for Swagger documentation  
- Custom Middleware for centralized exception handling and request processing  
- FluentValidation for request validation  
- Result Pattern to standardize API responses  
- Structured architecture following Clean Architecture principles (API, Application, Domain, Infrastructure layers)

---

## Project Structure

- `TaskOne.Api` – Entry point, controllers, endpoints, Swagger configuration  
- `TaskOne.Application` – Business logic and use cases  
- `TaskOne.Domain` – Core entities and domain logic  
- `TaskOne.Infrastructure` – Data access, repositories, and external services  

---

## How to Run

1. Clone the repository:


git clone https://github.com/RehamAzizi/UserManagementAPI.git


2. Open `TaskOne.sln` in Visual Studio  
3. Build the solution  
4. Run the project `TaskOne.Api`  
5. Access Swagger UI (protected by Basic Authentication)  
   - **Username:** `admin`  
   - **Password:** `123456`  
6. Explore and test API endpoints  

---

## Notes

This project is a simple User Management API (Add/Delete users), but demonstrates:

- Clean code principles  
- Custom middleware  
- JWT authentication  
- FluentValidation  
- Structured backend architecture  

It is intended to showcase best practices in backend development.

---
