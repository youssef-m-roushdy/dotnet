using Microsoft.EntityFrameworkCore;
using product_microservices_project.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProductDbContext>(
    options => options.UseMySql(
        builder.Configuration.GetConnectionString("ProductDB"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("ProductDB"))
    )
);

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.UseHttpsRedirection();

app.Run();

