using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIT.Shared.Models


{
    public class RespuestaHistorial
    {
        public int Total { get; set; }
        public int Pagina { get; set; }
        public List<RegistroEmbolsadoDto> Registros { get; set; } = new();
    }

}