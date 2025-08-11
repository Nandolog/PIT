namespace  PIT.Shared.Models
{
    public class FiltroHistoricoDto
    {
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string? Turno { get; set; }
        public string? Operador { get; set; }
        public int Pagina { get; set; } = 1;
        public int TamanoPagina { get; set; } = 20;
    }
}
