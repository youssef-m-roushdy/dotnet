using GraphQLHotChocolate.Data;
using GraphQLHotChocolate.GraphQL.Mutations;
using GraphQLHotChocolate.GraphQL.Queries;
using GraphQLHotChocolate.Interfaces;
using GraphQLHotChocolate.Interfaces.Common;
using GraphQLHotChocolate.Repositories;
using GraphQLHotChocolate.Repositories.Common;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IStudentCourseRepository, StudentCourseRepository>();

//builder.Services.AddCors();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddGraphQLServer()
    .RegisterDbContext<AppDbContext>(DbContextKind.Synchronized)
    .AddQueryType<StudentQuery>()
    .AddMutationType(d => d.Name("Mutation"))
    .AddTypeExtension<StudentMutation>()
    .AddTypeExtension<CourseMutation>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapGraphQL("/graphql");

app.Run();
