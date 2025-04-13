using GraphQL.Server;
using GraphQLDemo.Data;
using GraphQLDemo.GraphQL;
using GraphQLDemo.GraphQL.Mutations;
using GraphQLDemo.GraphQL.Queries;
using GraphQLDemo.Interfaces;
using GraphQLDemo.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("GraphQLDemo")
    )
);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<EmployeeQuery>();
builder.Services.AddScoped<EmployeeMutation>();
builder.Services.AddScoped<AppSchema>();
//Register GraphQL
builder.Services.AddGraphQL(options =>
{
    options.EnableMetrics = true;
})
.AddSystemTextJson()
.AddErrorInfoProvider(opt => 
{
    opt.ExposeExceptionStackTrace = true;
})
.AddGraphTypes(typeof(AppSchema));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseGraphQL<AppSchema>();
app.UseGraphQLGraphiQL("/ui/graphql");

app.Run();
