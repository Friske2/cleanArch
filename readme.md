# Clean Architecture Template for .NET

This repository provides a clean architecture template for .NET projects, enabling you to quickly set up a well-structured solution following clean architecture principles.

## Features

- Layered architecture with clear separation of concerns
- Domain-driven design approach
- Built-in dependency injection
- Ready-to-use project structure
- Basic configuration setup

## Getting Started

## Add template

```bash
git clone https://github.com/Friske2/cleanArch.git
cd cleanArch

#install local template
dotnet new -i .

#create project
dotnet new cleanarch -n MyProject
```

## Running the Project

To run the project locally, follow these steps:

1. Navigate to the API project directory:

```bash
cd ./src/<MyProject>.Api
```

2. Run the application:

```bash
dotnet run
```

3. The API will start, typically at `https://localhost:3000`

4. You can access the Swagger UI documentation at `https://localhost:3000/swagger`

## Project Structure

The solution follows clean architecture principles with the following structure:

- **cleanArch.Domain**: Contains enterprise-wide logic and entities
- **cleanArch.Application**: Contains business logic and use cases
- **cleanArch.Infrastructure**: Contains implementation details (database, external services)
- **cleanArch.Api**: Contains the web API controllers and configuration
