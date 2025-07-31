// Define el espacio de nombres donde vive este controlador.
// Ayuda a organizar el código y evitar conflictos entre clases con nombres similares.
using Microsoft.AspNetCore.Mvc;

namespace PIT.Backend.Controllers
{
    // Indica que esta clase es un controlador de API REST.
    // Habilita validaciones automáticas de modelo y respuestas coherentes.
    [ApiController]

    // Define la ruta base del controlador: "api/produccion".
    // El [controller] se reemplaza automáticamente por el nombre de la clase sin "Controller".
    [Route("api/[controller]")]
    public class ProduccionController : ControllerBase
    {
        // Lista estática simulada de lotes.
        // Se usa como almacenamiento temporal en memoria.
        private static readonly List<string> lotes = new()
        {
            "Lote-001", "Lote-002", "Lote-003"
        };

        // Método que responde a solicitudes HTTP GET en la ruta /api/produccion.
        // Devuelve la lista actual de lotes.
        [HttpGet]
        public IActionResult GetLotes()
        {
            // Retorna un código 200 OK con la lista de lotes como contenido.
            return Ok(lotes);
        }

        // Método que responde a solicitudes HTTP POST en la ruta /api/produccion.
        // Permite agregar un nuevo lote enviado en el cuerpo de la solicitud.
        [HttpPost]
        public IActionResult AgregarLote([FromBody] string nuevoLote)
        {
            // Agrega el nuevo lote a la lista simulada.
            lotes.Add(nuevoLote);

            // Retorna un código 201 Created, indicando que se creó exitosamente.
            // Incluye el nuevo lote como contenido y referencia al método GetLotes.
            return CreatedAtAction(nameof(GetLotes), new { id = nuevoLote }, nuevoLote);
        }
    }
}
