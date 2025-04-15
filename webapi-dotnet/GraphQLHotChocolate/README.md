# 📊 .NET 8 GraphQL + REST API Project

This project is a hybrid API built with **GraphQL** and **REST** using **ASP.NET Core 8**, **Entity Framework Core**, and **HotChocolate**.

It demonstrates how GraphQL can enhance your API experience with flexible querying, efficient data retrieval, and strong typing — all while supporting REST for traditional use cases.

---

## 📘 What is GraphQL?

**GraphQL** is a query language for your API and a runtime for executing those queries with your existing data. Unlike REST which requires multiple endpoints for different resources, GraphQL works through a single endpoint and gives clients the power to ask for exactly what they need.

---

## 🚀 Why Use GraphQL?

| Feature                 | GraphQL                                                   | REST                        |
|------------------------|------------------------------------------------------------|-----------------------------|
| **Data Fetching**      | Only what you ask for                                      | Might over-fetch/under-fetch|
| **Single Endpoint**    | `/graphql` handles everything                              | Multiple endpoints required |
| **Query Efficiency**   | Combines nested and related data in one request            | Often requires chaining calls|
| **Self-Documentation** | Schema introspection + tools like Banana Cake Pop          | Swagger/OpenAPI             |
| **Versioning**         | Usually not needed—clients define their shape              | Often requires `/v1`, `/v2` |

---

## 📦 Required NuGet Packages

The project uses the following Nuget packages:

```
    HotChocolate.AspNetCore 13.9.14
    HotChocolate.Data 13.9.14
    HotChocolate.Data.EntityFramework 13.9.14
    Microsoft.EntityFrameworkCore 8.0.2
    Microsoft.EntityFrameworkCore.Design 8.0.2
    Microsoft.EntityFrameworkCore.SqlServer 8.0.2
    Microsoft.EntityFrameworkCore.Tools 8.0.2
```

---

## 🧠 Core Concepts of GraphQL

### 📌 **Schema**
The **schema** defines how clients can access your data. It includes:
- **Query** – Read data
- **Mutation** – Write or modify data
- **Types** – Define the shape of your objects

### 📌 **Types**
A GraphQL type defines the structure of the data, like a C# class or database table:

```
type Student {
  id: ID!
  firstName: String!
  lastName: String!
  Address: String!
  phoneNumber: String!
  courses: [Course]
}
```

### 📌 **Query**
Used to **fetch** data:

```
query {
  users {
    id,
    firstName,
    lastName
    courses {
      id,
      name
    }
  }
}
```

### 📌 **Mutation**
Used to **modify** data (insert, update, delete):

```
mutation {
  createUser(firstName: "Jane", lastName: "Doe", Address: "1st Californai street", phoneNumber: "+15645638743") {
    id,
    firstName,
    lastName
  }
}
```

### 📌 **Input Types**
GraphQL mutations often accept input objects:

```
input CreateUserInput {
  firstName: String!
  lastName: String!
  Address: String!
  phoneNumber: String!
}
```

---

## ✨ Tips for Creating GraphQL APIs with HotChocolate

✅ **1. Define your types and queries as C# classes**
```
public class StudentType
{
    public int Id { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string Address { get; set; }
    public string phoneNumber { get; set; }
}
```

✅ **2. Register services and schema in `Program.cs`**
```
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();
```

✅ **3. Add Query and Mutation classes**
```
public class Query
{
    public IQueryable<Student> GetStudents([Service] AppDbContext db) =>
        db.Students;
}

public class Mutation
{
    public async Task<Student> CreateStudent(string name, [Service] AppDbContext db)
    {
        var student = new Student { FirstName = firstName };
        db.Students.Add(student);
        await db.SaveChangesAsync();
        return student;
    }
}
```

✅ **4. Use Banana Cake Pop for testing**
Run your app and open `/graphql` in the browser to test queries interactively.

---

## 🛠️ Running the Project


1. **Install EF Core tools (if not yet installed):**
```
dotnet tool install --global dotnet-ef
```

2. **Restore packages**
```
dotnet restore
```

4. **Apply migrations**
```
dotnet ef database update
```

5. **Run the application**
```
dotnet run
```

REST enpoints Swagger UI test:

- Visit Swagger at: `https://localhost:5001/swagger`

GrapQL HotChocolate UI test:

- Visit Banana Cake Pop at: `https://localhost:5001/graphql`

---
