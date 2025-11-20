namespace Distribucion.Core.DTOs
{
    public class DetalleEnvioDTO
    {
        public int CodigoDetalleEnvio { get; set; }
        public int CodigoProducto { get; set; }
        public int CodigoEnvio { get; set; }
        public int Cantidad { get; set; }
        public string UnidadMedida { get; set; }
    }
}
