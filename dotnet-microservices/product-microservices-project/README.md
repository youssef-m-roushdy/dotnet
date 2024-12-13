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
