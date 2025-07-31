# 🏗️ PIT - Sistema Integrado de Trazabilidad, Capacitación y Recuperación Técnica

Este proyecto busca demostrar cómo aplicar soluciones tecnológicas reales en entornos industriales con restricciones, usando .NET, Blazor WebAssembly y Docker.

---

## 📦 Estructura del Proyecto

```plaintext
PIT/
├── PIT.Backend/       # API REST en .NET 8
│   └── Controllers/
│       └── ProduccionController.cs
├── PIT.Frontend/      # Interfaz Blazor WebAssembly
├── README.md          # Documentación del proyecto
🚀 Tecnologías utilizadas
.NET 8

Blazor WebAssembly

ASP.NET Core WebAPI

Docker (configuración en progreso)

Visual Studio 2022+

⚙️ Backend: PIT.Backend
🔧 Controlador: ProduccionController.cs
csharp
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
🌐 Endpoints disponibles
Método	Ruta	Descripción
GET	/api/Produccion	Devuelve lista simulada de lotes
POST	/api/Produccion	Agrega un nuevo lote
🧪 Verificación
Swagger UI: http://localhost:8080/swagger

Producción: http://localhost:8080/api/Produccion

🖥️ Frontend: PIT.Frontend
Proyecto Blazor WebAssembly con configuración base:

csharp
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});
🐳 Docker (en progreso)
Se está preparando el Dockerfile para el backend, compatible con Visual Studio y Docker Desktop. Próximamente se incluirá:

Dockerfile para PIT.Backend

docker-compose opcional

Hosting provisional para pruebas

📌 Cómo ejecutar localmente
Clonar el repositorio:

bash
git clone https://github.com/tu-usuario/pit.git
Abrir la solución en Visual Studio.

Ejecutar el backend (PIT.Backend) en puerto 8080.

Acceder a Swagger: http://localhost:8080/swagger

📚 Objetivo del proyecto
Este sistema busca ser:

Reproducible y portable

Documentado paso a paso

Adaptable a entornos industriales con restricciones

Referencia técnica para otros analistas

📈 Próximos pasos
Integrar frontend con backend

Agregar persistencia simulada o real

Desplegar en entorno Docker

Preparar presentación técnica para validación interna

🤝 Autor
Fernando — Analista técnico, enfocado en soluciones reales, reproducibles y documentada