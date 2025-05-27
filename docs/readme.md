# Clean Architecture Solution Setup

## Project Structure

### API Layer

```bash
dotnet new webapi -n cleanArch.Api -o src/cleanArch.Api
```

### Application Layer

```bash
dotnet new classlib -n cleanArch.Application -o src/cleanArch.Application
```

### Domain Layer

```bash
dotnet new classlib -n cleanArch.Domain -o src/cleanArch.Domain
```

### Infrastructure Layer

```bash
dotnet new classlib -n cleanArch.Infrastructure -o src/cleanArch.Infrastructure
```

## Project References

### API References

```bash
dotnet add src/cleanArch.Api/cleanArch.Api.csproj reference src/cleanArch.Application/cleanArch.Application.csproj
dotnet add src/cleanArch.Api/cleanArch.Api.csproj reference src/cleanArch.Infrastructure/cleanArch.Infrastructure.csproj
```

### Application References

```bash
dotnet add src/cleanArch.Application/cleanArch.Application.csproj reference src/cleanArch.Domain/cleanArch.Domain.csproj
```

### Infrastructure References

```bash
dotnet add src/cleanArch.Infrastructure/cleanArch.Infrastructure.csproj reference src/cleanArch.Application/cleanArch.Application.csproj
dotnet add src/cleanArch.Infrastructure/cleanArch.Infrastructure.csproj reference src/cleanArch.Domain/cleanArch.Domain.csproj
```

## Test Setup

```bash
dotnet new xunit -o tests/cleanArch.Tests

# Add project references
dotnet add tests/cleanArch.Tests/cleanArch.Tests.csproj reference src/cleanArch.Application/cleanArch.Application.csproj
dotnet add tests/cleanArch.Tests/cleanArch.Tests.csproj reference src/cleanArch.Domain/cleanArch.Domain.csproj
dotnet add tests/cleanArch.Tests/cleanArch.Tests.csproj reference src/cleanArch.Infrastructure/cleanArch.Infrastructure.csproj

# Add testing packages
dotnet add tests/cleanArch.Tests/cleanArch.Tests.csproj package Moq
```
