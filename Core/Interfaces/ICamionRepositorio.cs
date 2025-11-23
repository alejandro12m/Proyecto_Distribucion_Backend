
using Distribucion.Core.DTOs;

namespace Distribucion.Core.Interfaces
{
    public interface ICamionRepositorio
    {
        Task<List<CamionDTO>> GetCamion();
        Task<CamionDTO> PostCamion(int placa, int capacidad, string tipoVehiculo, string unidadCapacidad);

    }
}
