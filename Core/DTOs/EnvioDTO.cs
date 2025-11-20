using System.ComponentModel.DataAnnotations.Schema;

namespace Distribucion.Core.DTOs
{
    public class EnvioDTO
    {
        public int Codigo {  get; set; }
        public DateOnly FechaEnvio{get; set;}
        public string Detalles { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; } = "Pendiente";

    }
}
