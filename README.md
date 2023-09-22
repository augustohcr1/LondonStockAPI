# London Stock API

London Stock API is a .NET Core application that provides functionality for managing and querying stock data.

## Table of Contents

- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
- [Usage](#usage)
  - [API Endpoints](#api-endpoints)
- [System Design](#system-design)

## Getting Started

### Prerequisites

Before you begin, ensure you have met the following requirements:

- [.NET 7](https://dotnet.microsoft.com/download/dotnet/7.0) or later installed.
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) for database access.
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads).

- Set a valid connection string on the appsettings.development.json file

## Usage
## API Endpoints

Get Current Stock Price:
GET /api/stocks/{tickerSymbol}

Get All Stocks:
GET /api/stocks

Get Stocks in Range:
GET /api/stocks/range?symbols=ABC,XYZ

Create Stock Transaction:
POST /api/stock/{tickerSymbol}/transaction

## System Design

1. Architecture: The project follows a layered architecture with application, domain, infrastructure, and API layers.

2. Data Storage: Entity Framework Core is used for interacting with a relational database.

3. CQRS Pattern: MediatR is employed to implement the Command Query Responsibility Segregation (CQRS) pattern.

4.  Domain-Driven Design (DDD): The project embraces DDD principles by defining domain entities (e.g., Stock and StockTransaction) and value objects, encapsulating business logic within the domain, and applying domain exceptions.

5. AutoMapper: AutoMapper is used for mapping domain models to DTOs.

6. Exception Handling: Exception handling is implemented to return appropriate HTTP status codes and error messages.

7. API Controllers: Controllers handle HTTP requests for stocks and stock transactions.

8. Testing: Unit tests cover various components, including handlers, AutoMapper configurations, and domain models.

9. Swagger/OpenAPI: Swagger is integrated for API documentation.



