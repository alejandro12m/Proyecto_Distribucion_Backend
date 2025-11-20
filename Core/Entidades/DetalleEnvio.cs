using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace Distribucion.Core.Entidades
{
    public class DetalleEnvio
    {
        [Key]
        public int IdDetalleEnvio { get; set; }
        public int CodigoDetalleEnvio { get; set; }
        public int CodigoProducto {  get; set; }
        public int CodigoEnvio { get; set; }
        public int Cantidad {  get; set; }
        public string UnidadMedida { get; set; }
        public string Estado { get; set; } = "Activo";
    }
}
