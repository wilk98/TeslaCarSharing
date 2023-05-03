# Tesla Car Sharing

This web application is designed to provide a car rental service for Tesla cars in Mallorca, Spain. The platform offers users the ability to rent various Tesla models from multiple locations, such as Palma Airport, Palma City Center, Alcudia, and Manacor. The project is divided into four main layers: `api`, `infrastructure`, `application`, and `core`.

## Features

- Backend: ASP.NET Core and C# with MSSQL Server and Entity Framework
- Frontend: React and TypeScript
- Data validation with FluentValidation
- Repository design pattern
- Enumerations for `Location` and `TeslaModel`
- Three main classes: `Customer`, `Car`, and `Reservation`
  - Each class has a corresponding controller, service, and repository
- DTOs (Data Transfer Objects) for each class, mapped using `MappingProfile`
- Frontend pages: Home, About, Our Cars, Reservation, Price List, and Contact
  - The Our Cars page displays all available cars and allows users to add or remove cars
  - The Reservation page enables users to create a reservation by selecting dates, choosing an available car, and providing customer details

## Front-end

The front-end of the application is built using React and TypeScript, prioritizing code quality and readability over visual effects. The website is accessible at http://localhost:5173/.

## Back-end

The back-end is developed using ASP.NET Core and C#, with data stored and retrieved using MSSQL Server and Entity Framework. The Swagger API documentation is available at https://localhost:44307/swagger/index.html.

## Decisions and Assumptions

1. The front-end is built using React and TypeScript, prioritizing code quality and readability over visual effects.
2. The back-end is developed using ASP.NET Core and C#, with data stored and retrieved using MSSQL Server and Entity Framework.
3. The project is divided into four main layers: `api`, `infrastructure`, `application`, and `core` to ensure a modular and maintainable architecture.
4. The application uses FluentValidation for data validation when adding records to the database.
5. The project employs the repository design pattern to provide an abstraction layer between the data access layer and the business logic layer.
6. Enumerations for `Location` and `TeslaModel` have been created to represent the various rental locations and available Tesla models.
