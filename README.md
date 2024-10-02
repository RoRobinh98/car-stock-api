# Car Stock Management API

This is a demo API for managing car stock, built using ASP.NET Core. The API supports JWT authentication and allows authorized users to add and remove cars.

## Features

- **Add/remove car**: Users must be authenticated via a JWT token to add or remove cars.
- **List cars and stock levels**: The API allows adding, removing, and retrieving cars from a SQLite database.
- **Update car stock level**: Users must be authenticated to update car stock.
- **Search car by make and model**: Cars can be searched by make or model separatly or together.

## Prerequisites

To run this project, you need the following installed on your machine:

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- A tool to test APIs such as [Postman](https://www.postman.com/downloads/) or `curl`.

## Setup Instructions

Follow the steps below to set up and run the project.


### 1. Install Dependencies

- dotnet restore

### 2. Build the Project

- dotnet build

### 3. Run the Project

- dotnet run

## Sample Call

- GET http://localhost:5000/v1/public/car

