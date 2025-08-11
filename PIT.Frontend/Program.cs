using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PIT.Frontend; // Add this using directive if App is in this namespace
using App = PIT.Frontend.App;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// ✅ Apuntar al backend WebAPI
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:32789") // Puerto del backend
});

await builder.Build().RunAsync();