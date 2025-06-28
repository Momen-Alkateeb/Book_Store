# 📚 Book Store Project

An ASP.NET Core MVC web application for managing and browsing books. This project demonstrates a full-featured online bookstore with user-friendly features, clean architecture, and solid backend development practices.

## 🚀 Technologies Used

- ASP.NET Core MVC  
- Entity Framework Core  
- C#  
- SQL Server   
- Bootstrap 5 (for styling)

## 📦 Features

- User Authentication (Login/Register)  
- List all available books  
- Search and filter books by title, author, or category  
- Admin panel to manage books and categories (CRUD operations)  
- Optional: Add to cart and checkout system  
- Optional: Dashboard for basic statistics

## 🏗️ Project Structure
  Book_Store/
├── Controllers/
├── Models/
├── Views/
├── Data/
├── wwwroot/
├── appsettings.json
├── Program.cs
├── Startup.cs
- Controllers/: Handles the user requests and business logic  
- Models/: Contains the data models (entities)  
- Views/: Razor views for rendering UI  
- Data/: DbContext and database seeding logic  
- wwwroot/: Static files like CSS, JS, and images  
- Program.cs / Startup.cs: Application configuration and middleware setup
  
  ## 🛠️ Getting Started
### Prerequisites

- .NET 6 SDK or higher  
- SQL Server  
- Visual Studio 2022 or Visual Studio Code
  
### Setup Instructions

1. Clone the repository: `git clone https://github.com/Momen-Alkateeb/Book_Store.git`  
2. Navigate into the project folder: `cd Book_Store`  
3. Update the database connection string in `appsettings.json`  
4. Apply migrations and create the database: `dotnet ef database update`  
5. Run the project: `dotnet run`  
6. Open your browser and visit: `http://localhost:5000`

   
## 👨‍💻 Author

**Momen Alkateeb**  
GitHub: [Momen-Alkateeb](https://github.com/Momen-Alkateeb)  
A passionate backend developer focused on ASP.NET Core, clean architecture, and building practical web applications.

## 📄 License

This project is open-source and available under the [MIT License](LICENSE).

