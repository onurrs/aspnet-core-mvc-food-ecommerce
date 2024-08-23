# ASP.NET Core MVC Food E-Commerce Platform

## Description

This ASP.NET Core MVC project is a complete e-commerce platform that includes:
- **Admin Panel**: Manage categories and products with CRUD operations.
- **Public Storefront**: Allows anonymous users to browse products, view details, and add items to their cart.
- **Statistical Insights**: View statistics on product availability, prices, stock quantities, and more.

## Features

- **Categories Management**: Admins can add, update, and delete product categories.
- **Products Management**: Admins can perform CRUD operations on products, including setting prices and stock quantities.
- **Shopping Cart**: Users can browse products, view details, and add items to their cart.
- **Statistics Dashboard**: Provides insights into product stock, prices, and category details.

## Installation

1. Clone the repository:
   ```
   git clone https://github.com/yourusername/aspnet-core-mvc-food-ecommerce.git
2. Navigate to the project directory:
   ```
   cd aspnet-core-mvc-food-ecommerce
3. Restore NuGet packages:
   ```
   dotnet restore
4. Set up the database and apply migrations:
   ```
   dotnet ef database update
5. Run the application:
   ```
   dotnet run
6. Open a browser and go to http://localhost:5000 to access the application.

## Usage
- **Admin Panel**: Access the admin panel by navigating to /admin and log in with admin credentials to manage categories and products.
- **Public Storefront**: Browse products and view details on the home page. Users can add products to the cart and proceed to checkout.

## Contributing
1. Fork the repository.
2. Create a new branch (git checkout -b feature/your-feature).
3. Make your changes.
4. Commit your changes (git commit -am 'Add some feature').
5. Push to the branch (git push origin feature/your-feature).
6. Create a new Pull Request.

## License
This project is licensed under the MIT License - see the LICENSE file for details.
