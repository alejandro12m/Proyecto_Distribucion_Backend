using System.ComponentModel.DataAnnotations;

namespace Distribucion.Core.Entidades
{
    public class Camion
    {
        [Key]
        public int Id { get; set; }
        public int Placa {  get; set; }
        public int Capacidad { get; set; }
        public string TipoVehiculo {  get; set; }
        public string UnidadCapacidad { get; set; }
        public string Estado { get; set; } = "Activo";

    }
}
