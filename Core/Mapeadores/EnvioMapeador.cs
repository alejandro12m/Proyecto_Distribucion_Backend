using Distribucion.Core.DTOs;
using Distribucion.Core.Entidades;


namespace Distribucion.Core.Mapeadores
{
    public static class EnvioMapeador
    {
        public static EnvioDTO toEnvioDTO(this Envio envio)
        {
            return new EnvioDTO()
            {
                Codigo = envio.Codigo,
                FechaEnvio = envio.FechaEnvio,
                Detalles = envio.Detalles,
                Tipo = envio.Tipo,
                Estado=envio.Estado
            };
        }
    }
}
