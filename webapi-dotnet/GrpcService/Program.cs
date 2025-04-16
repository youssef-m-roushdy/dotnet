using GrpcService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ProductService>();

// Add services to the container.
builder.Services.AddGrpc();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<ProductService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
