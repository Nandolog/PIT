# 🏗️ PIT: Sistema de Trazabilidad y Optimización en el Área de Embolsado

## 🎯 Objetivo General

Crear una solución técnica que permita **monitorear, analizar y documentar** el proceso de embolsado de cemento, ayudando a:

- 🔍 Identificar cuellos de botella o pérdidas operativas  
- 📦 Mejorar la planificación y trazabilidad del producto  
- 🎓 Facilitar la capacitación y la toma de decisiones técnicas  

Este sistema busca aplicar tecnología en entornos industriales con restricciones reales, usando .NET 8, Blazor WebAssembly y Docker.

---

## ⚙️ PIT.Backend - API REST

- ASP.NET Core 8 + Entity Framework Core (InMemory)
- Swagger UI disponible en [https://localhost:5001/swagger](https://localhost:5001/swagger)
- CORS habilitado para `https://localhost:7176`
- Endpoints disponibles:
  - `GET /api/Produccion` → Lista simulada de lotes
  - `POST /api/Produccion` → Agregar nuevo lote

### 🔧 ProduccionController.cs

```csharp
[ApiController]
[Route("api/[controller]")]
public class ProduccionController : ControllerBase
{
    private static readonly List<string> lotes = new() { "Lote-001", "Lote-002", "Lote-003" };

    [HttpGet]
    public IActionResult GetLotes() => Ok(lotes);

    [HttpPost]
    public IActionResult AgregarLote([FromBody] string nuevoLote)
    {
        lotes.Add(nuevoLote);
        return CreatedAtAction(nameof(GetLotes), new { id = nuevoLote }, nuevoLote);
    }
}
🖥️ PIT.Frontend - Blazor WebAssembly
Corre en https://localhost:7176

Consume API REST del backend

Componente EstadoDelSistema.razor muestra los lotes en tiempo real

🔧 Configuración de HttpClient
csharp
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:5001")
});
🔧 Componente EstadoDelSistema.razor
razor
@inject HttpClient Http

<h3>Estado del sistema</h3>

@if (error != null)
{
    <p style="color:red">Error: @error</p>
}
else if (lotes == null)
{
    <p>Cargando...</p>
}
else
{
    <ul>
        @foreach (var lote in lotes)
        {
            <li>@lote</li>
        }
    </ul>
}

@code {
    private List<string>? lotes;
    private string? error;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            lotes = await Http.GetFromJsonAsync<List<string>>("api/produccion");
        }
        catch (Exception ex)
        {
            error = ex.Message;
        }
    }
}
🐳 Docker (en progreso)
Dockerfile para PIT.Backend

docker-compose opcional

Hosting provisional para pruebas

📌 Cómo ejecutar localmente
bash
git clone https://github.com/tu-usuario/pit.git
Abrir la solución en Visual Studio

Ejecutar el backend en https://localhost:5001

Ejecutar el frontend en https://localhost:7176

Verificar conexión en Swagger y en el componente EstadoDelSistema

📚 Objetivo del proyecto
Este sistema busca ser:

Reproducible y portable

Documentado paso a paso

Adaptable a entornos industriales con restricciones

Referencia técnica para otros analistas

🤝 Autor
Fernando — Analista técnico, enfocado en soluciones reales, reproducibles y documentadas para entornos industriales.
