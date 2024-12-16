using Microsoft.EntityFrameworkCore;
using student_service.Data;
using student_service.Interfaces;
using student_service.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<StudentDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("StudentDB")
    )
);

builder.Services.AddTransient<IStudentRepository, StudentRepository>();

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

