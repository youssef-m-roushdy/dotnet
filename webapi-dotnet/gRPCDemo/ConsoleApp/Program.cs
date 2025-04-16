using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using GrpcService.Protos;

var channel = GrpcChannel.ForAddress("http://localhost:5001");
var client = new ProductProtoService.ProductProtoServiceClient(channel);

var create1 = await client.CreateProductAsync(new CreateProductRequest
{
    Name = "Computer",
    Description = "A workstation computer",
    Price = 1800
});
Console.WriteLine(create1);
Console.WriteLine("========");
var create2 = await client.CreateProductAsync(new CreateProductRequest
{
    Name = "Airpods",
    Description = "A aitpods for private listeninig",
    Price = 100
});
Console.WriteLine(create1);
Console.WriteLine("========");

var productsList = await client.ListProductAsync(new Google.Protobuf.WellKnownTypes.Empty());

foreach (var product in productsList.Products)
{
    Console.WriteLine($"${product.Id}: {product}");
}

