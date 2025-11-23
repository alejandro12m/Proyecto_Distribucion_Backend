using Distribucion.Core.DTOs;
using Distribucion.Core.Entidades;
namespace Distribucion.Core.Mapeadores
{
    public static class CamionMapeador
    {
        public static CamionDTO toCamionDTO(this Camion CamionDTO)
        {
            return new CamionDTO()
            {
                Placa = CamionDTO.Placa,
                Capacidad = CamionDTO.Capacidad,
                UnidadCapacidad = CamionDTO.UnidadCapacidad

            };
        }
    }
}
