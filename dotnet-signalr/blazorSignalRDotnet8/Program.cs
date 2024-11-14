using blazorSignalRDotnet8.Components;
using blazorSignalRDotnet8.Hubs;

var builder = WebApplication.CreateBuilder(args);

//register signalr
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//add signalr service to app
builder.Services.AddSignalR();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

//Add url to chat
// register chatHub
app.MapHub<ChatHub>("/chathub");    

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
