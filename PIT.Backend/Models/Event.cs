namespace PIT.Backend.Models
{
    // Modelo base para registrar eventos operativos en la línea de embolsado.
    // Se utiliza en el módulo de monitoreo para detectar cuellos de botella y pérdidas.

    public class Event
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Type { get; set; } // Ej: "Inicio", "Parada", "Error"
        public string Description { get; set; }
        public string MachineId { get; set; }
    }
}
