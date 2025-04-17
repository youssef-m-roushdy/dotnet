using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcService.Protos;

var channel = GrpcChannel.ForAddress("http://localhost:5001");
var client = new ProductProtoService.ProductProtoServiceClient(channel);

var headers = new Metadata
{
    {"Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI3MzEyMDQ4YS0wOTJiLTQ3NTMtODEyNC1iZTNiNDY2ZWMwZGYiLCJleHAiOjE3NDQ5MjgzNjcsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTAwMSIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTAwMSJ9.Ab8M2WONAzfsTBSebmUS-3CTQtPpMG74SAMZD-p9yH8"}
};

var create1 = await client.CreateProductAsync(new CreateProductRequest
{
    Name = "Computer",
    Description = "A workstation computer",
    Price = 1800
}, headers);
Console.WriteLine(create1);
Console.WriteLine("========");
var create2 = await client.CreateProductAsync(new CreateProductRequest
{
    Name = "Airpods",
    Description = "A aitpods for private listeninig",
    Price = 100
}, headers);
Console.WriteLine(create1);
Console.WriteLine("========");

var productsList = await client.ListProductAsync(new Google.Protobuf.WellKnownTypes.Empty(), headers);

foreach (var product in productsList.Products)
{
    Console.WriteLine($"${product.Id}: {product}");
}

