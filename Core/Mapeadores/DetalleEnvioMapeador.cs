using Distribucion.Core.DTOs;
using Distribucion.Core.Entidades;


namespace Distribucion.Core.Mapeadores
{
    public static class DetalleEnvioMapeador
    {
        public static  DetalleEnvioDTO toDetalleEnvioDTO(this DetalleEnvio detalleEnvio)
        {
            return new DetalleEnvioDTO()
            {
                CodigoDetalleEnvio = detalleEnvio.CodigoDetalleEnvio,
                CodigoProducto = detalleEnvio.CodigoProducto,
                CodigoEnvio = detalleEnvio.CodigoEnvio,
                Cantidad = detalleEnvio.Cantidad,
                UnidadMedida = detalleEnvio.UnidadMedida

            };
        }
    }
}
