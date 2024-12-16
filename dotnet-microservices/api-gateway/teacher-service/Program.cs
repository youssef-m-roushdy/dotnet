using Microsoft.EntityFrameworkCore;
using teacher_service.Data;
using teacher_service.Interfaces;
using teacher_service.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<TeacherDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("TeacherDB")
    )
);

builder.Services.AddTransient<ITeacherRepository, TeacherRepository>();

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

