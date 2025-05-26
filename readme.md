init project

# ✅ API

dotnet new webapi -n cleanArch.Api -o src/cleanArch.Api

# ✅ Application

dotnet new classlib -n cleanArch.Application -o src/cleanArch.Application

# ✅ Domain

dotnet new classlib -n cleanArch.Domain -o src/cleanArch.Domain

# ✅ Infrastructure

dotnet new classlib -n cleanArch.Infrastructure -o src/cleanArch.Infrastructure

# API --> Application + Infrastructure

dotnet add src/cleanArch.Api/cleanArch.Api.csproj reference src/cleanArch.Application/cleanArch.Application.csproj
dotnet add src/cleanArch.Api/cleanArch.Api.csproj reference src/cleanArch.Infrastructure/cleanArch.Infrastructure.csproj

# Application --> Domain

dotnet add src/cleanArch.Application/cleanArch.Application.csproj reference src/cleanArch.Domain/cleanArch.Domain.csproj

# Infrastructure --> Application + Domain

dotnet add src/cleanArch.Infrastructure/cleanArch.Infrastructure.csproj reference src/cleanArch.Application/cleanArch.Application.csproj
dotnet add src/cleanArch.Infrastructure/cleanArch.Infrastructure.csproj reference src/cleanArch.Domain/cleanArch.Domain.csproj

# Test Project

dotnet new xunit -o tests/cleanArch.Tests
dotnet add tests/cleanArch.Tests/cleanArch.Tests.csproj reference src/cleanArch.Application/cleanArch.Application.csproj
dotnet add tests/cleanArch.Tests/cleanArch.Tests.csproj reference src/cleanArch.Domain/cleanArch.Domain.csproj
dotnet add tests/cleanArch.Tests/cleanArch.Tests.csproj reference src/cleanArch.Infrastructure/cleanArch.Infrastructure.csproj

dotnet add tests/cleanArch.Tests/cleanArch.Tests.csproj package Moq
