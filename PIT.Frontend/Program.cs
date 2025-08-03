using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PIT.Frontend.Shared;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// ✅ Apuntar al backend WebAPI
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:32775") // Puerto del backend
});

await builder.Build().RunAsync();
