using PIT.Backend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 🔧 Configurar base de datos antes de construir la app
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("PITDb")); // Para pruebas iniciales

// ✅ Servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ CORS: permitir llamadas desde el frontend Blazor
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.WithOrigins("https://localhost:7176") // Puerto fijo del frontend
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

var app = builder.Build();

// ✅ Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PIT.Backend v1");
        c.RoutePrefix = "swagger";
    });
}

// 🔧 HTTPS redirection desactivado para entorno local
// app.UseHttpsRedirection();

app.UseCors("AllowFrontend");
app.UseAuthorization();
app.MapControllers();

app.Run();
