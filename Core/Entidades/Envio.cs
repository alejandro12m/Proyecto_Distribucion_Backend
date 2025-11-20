using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Distribucion.Core.Entidades
{
    public class Envio
    {
        [Key]
        public int IdEnvio { get; set; }
        public int Codigo { get; set; }
        public DateOnly FechaEnvio {  get; set; }
        public string Detalles { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; } = "Pendiente";

    }
}
