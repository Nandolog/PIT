namespace PIT.Shared.Models


{
    public class RegistroEmbolsadoDto
    {
        public string LoteId { get; set; }
        public DateTime FechaHora { get; set; }
        public string Turno { get; set; }
        public string Operador { get; set; }
        public int Cantidad { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
    }
}

