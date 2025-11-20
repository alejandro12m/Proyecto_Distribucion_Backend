using Distribucion.Core.DTOs;
using Distribucion.Core.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Distribucion.Core.Interfaces
{
    public interface IEnvioRepositorio
    {
        Task<EnvioDTO> GetEnvioCodigo(int Codigo);
        Task<List<EnvioDTO>> GetEnvio();
        Task<List<EnvioDTO>> GetEnvioPendiente();
        Task<List<EnvioDTO>> GetEnvioCancelados();
        Task<List<EnvioDTO>> GetEnvioEntregados();
        Task<EnvioDTO> PostEnvio(int codigo, DateOnly fechaEnvio, string detalles, string tipo);
        Task<EnvioDTO> PutEstadoEnvio(int codigo ,string estado);
        Task<EnvioDTO> DeleteEnvio(int codigo);


    }
}
