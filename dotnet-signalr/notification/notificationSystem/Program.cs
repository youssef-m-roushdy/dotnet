// Program.cs
using notificationSystem.Hubs;
using notificationSystem.Servers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSignalR();
builder.Services.AddHostedService<ServerTimeNotifier>();
builder.Services.AddCors(opt => {
    opt.AddPolicy("reactApp", builder => {
        builder.WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("reactApp");

app.MapHub<NotificationHub>("notifications");

app.Run();
