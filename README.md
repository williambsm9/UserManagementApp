# User & Group Management

This repository contains a **User Management system** built using **ASP.NET Core (.NET 8)** and follows a **Clean Architecture** approach.

The solution consists of:

- A **Web API** for user and group management
- A **Razor Pages UI** that consumes the API
- Clearly separated **Domain**, **Application**, and **Infrastructure** layers
- Integration tests for the API

This README provides **step-by-step instructions** to run the solution locally.

---

## Solution Structure

| Path                            | Description                                     |
| ------------------------------- | ----------------------------------------------- |
| `src/Application`               | Application layer (use cases, DTOs, interfaces) |
| `src/Domain`                    | Core domain entities and business rules         |
| `src/Infrastructure`            | Data access and repository implementations      |
| `src/WebApi`                    | ASP.NET Core Web API                            |
| `src/UserAdminUI`               | Razor Pages UI consuming the API                |
| `tests/WebApi.IntegrationTests` | API integration tests                           |

---

## Prerequisites

Before running the solution, ensure you have the following installed:

- **.NET 8 SDK**  
  https://dotnet.microsoft.com/download
- **Visual Studio 2022 (17.8 or later)**  
  Workload: **ASP.NET and web development**
- **Git**

Verify the .NET SDK installation:

```
dotnet --version

git clone <repository-url>
cd <repository-folder>
```

### Running the Solution (Recommended: Visual Studio)

Open UserManagement.sln in Visual Studio

Ensure Multiple Startup Projects are configured:

WebApi → Start

UserAdminUI → Start

Press F5 to run the solution

The following applications will start:

Project URL
Web API http://localhost:5001

Razor UI http://localhost:5104

Exact ports may vary depending on your launchSettings.json.

Running via Command Line (Alternative - for VS Code)
Start the Web API

```
cd src/WebApi
dotnet run
```

Start the UI

```
cd src/UserAdminUI
dotnet run
```

## Application Architecture

This solution follows Clean Architecture principles:

### Domain

- Core business entities
- Business rules
- No dependencies on other layers

### Application

- Use cases and business logic
- Interfaces for repositories and services
- DTOs and validation

### Infrastructure

- Database access
- Repository implementations
- External service integrations

### WebApi

- HTTP endpoints
- Dependency injection configuration
- API controllers

### UserAdminUI

- Razor Pages UI
- Consumes the Web API via HTTP clients
- User and group management screens

### API Communication

The UI communicates with the API using HttpClient.

Example configuration (from Program.cs in UserAdminUI):

```

builder.Services.AddHttpClient<UserApiClient>(client =>
{
client.BaseAddress = new Uri("http://localhost:5001");
});

builder.Services.AddHttpClient<GroupApiClient>(client =>
{
client.BaseAddress = new Uri("http://localhost:5001");
});

```

### Testing

Run Integration Tests

```

cd tests/WebApi.IntegrationTests
dotnet test

```

These tests validate the API endpoints end-to-end.

## Common Issues

### API not reachable from UI

        Ensure WebApi is running
        Confirm the API base URL matches the port in launchSettings.json

### Port conflicts

        Update ports in:
            WebApi/Properties/launchSettings.json
            UserAdminUI HTTP client configuration

## Notes

- This project is designed as an enterprise-style solution
- Emphasis is placed on separation of concerns, testability, and maintainability
