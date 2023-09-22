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



