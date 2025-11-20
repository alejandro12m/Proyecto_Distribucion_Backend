using Distribucion.Core.DTOs;

namespace Distribucion.Core.Interfaces
{
    public interface IDetalleEnvioRepositorio
    {
        Task<List<DetalleEnvioDTO>> GetDetalleEnvioCodigo(int codigoEnvio);
        Task<List<DetalleEnvioDTO>> GetDetalleEnvio();
        Task<DetalleEnvioDTO> GetDetalleDetalleEnvioCodigo(int codigoDetalleEnvio);
        Task<DetalleEnvioDTO> PostDetalleEnvio(int codigoDetallle,int codigoProducto, int codigoEnvio, int catidad, string undidadMedida);
        Task<DetalleEnvioDTO> PutDetalleEnvio(int codigo, int cantidad,string unidad, int codigoProducto);
        Task<DetalleEnvioDTO> DeleteDetalleEnvio(int codigo);

    }
}
