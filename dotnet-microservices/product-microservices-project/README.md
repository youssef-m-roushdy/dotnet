# Product Management Application Service

## Required Packages For Entity Framework Core

### NuGet:

```
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.Relational
```

### In My Case I Use MySQL So I Installed

```
Pomelo.EntityFrameworkCore.MySql
```

### If You Prefer SQL Server Installed

```
Microsoft.EntityFrameworkCore.SqlServer
```

## Congigure `appsetting.json` And Add The Connection String

### I Use MySQL Connection String

```
"ConnectionStrings": {
    "ProductDB": "Server=127.0.0.1;Port=3306;Database=DbName;Uid=Uid;Pwd=Pwd;"
  }
```

## Finally Migrate And Apply Modification Into The Database

```
dotnet ef migrations add MigrationName
dotnet ef database update
```

## Repository Pattern

  * Repository works as a micro component of microservice that encapsulates the data access layer, and helps in data persistence and testability as well. Let's configure repository pattern in our product microservice project

## Swagger

### What Is Swagger

  * Swagger is an open source api documentation that helps to understand API service methods.
  * When we consume a web API then understanding its various methods and verbs can be challenging for a developer
  * This solves the problem of generating documentation. It's known as OpenAPI

### There Are Three Core Components Of It

  * SwashBuckle.AspNetCore.Swagger: A Swagger object model expose SwaggerDocument objects in JSON
  * SwashBuckle.SwaggerGen: It provides the functionalities to generate JSON Swagger
  * SwashBuckle.SwaggerUI: The Swagger UI tool uses above documents for a rich customization for describing the Web API functioalities

## How To Dockerize Your Application

  * Create a `Dockerfile`
  * Populate the `Dockerfile` with the following content:
  ```
  # Use the official ASP.NET Core runtime as the base image
  # Base runtime image
  FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
  WORKDIR /app
  EXPOSE 8080
  EXPOSE 8081

  # Build stage
  FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
  ARG BUILD_CONFIGURATION=Release
  WORKDIR /src

  # Copy the .csproj file directly (no folder structure change needed)
  COPY YourProjectName.csproj ./
  RUN dotnet restore YourProjectName.csproj

  # Copy all project files and build
  COPY . .
  RUN dotnet build YourProjectName.csproj -c $BUILD_CONFIGURATION -o /app/build

  # Publish stage
  FROM build AS publish
  ARG BUILD_CONFIGURATION=Release
  RUN dotnet publish YourProjectName.csproj -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

  # Final runtime image
  FROM base AS final
  WORKDIR /app
  COPY --from=publish /app/publish .
  ENTRYPOINT ["dotnet", "YourProjectName.dll"]
  ```

  * `docker-compose` file content:
  ```
  version: '3.4'

  services:
    products.api:
      image: ${DOCKER_REGISTRY-}ImageName
      container_name: products_service
      build:
        context: .
        dockerfile: Dockerfile
      ports:
        - "8080:8080"
        - "8081:8081"
      environment:
        - ConnectionStrings__ProductDB=Server=mysql_service;Port=3306;Database=productdb;User=root;Password=123;
        - ASPNETCORE_ENVIRONMENT=Development

    mysql:
      image: mysql:8.0
      container_name: mysql_service
      restart: always
      environment:
        MYSQL_ROOT_PASSWORD: 123
        MYSQL_DATABASE: productdb
      ports:
        - "3307:3306"  # Map host port 3307 to container port 3306
      volumes:
        - mysql_data:/var/lib/mysql

  volumes:
    mysql_data:
```
  * Finally run this `docker-compose up --build` to build your containers
  * Test On Swagger UI Follow this link `http://localhost:8080/swagger/index.html`

