using Distribucion.Core.DTOs;
using Distribucion.Core.Entidades;
using Distribucion.Core.Interfaces;
using Distribucion.Core.Mapeadores;
using Distribucion.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;

namespace Distribucion.Infraestructura.Repositorio
{
    public class CamionRepositorio:ICamionRepositorio
    {
        private readonly DistribucionContext context;

        public CamionRepositorio(DistribucionContext context)
        {
            this.context = context;
        }

        public async Task<List<CamionDTO>> GetCamion()
        {
            var Camion = await (
                        from c in context.Caminon
                        select c).Select(us => us.toCamionDTO()).ToListAsync();
            return Camion;
        }

        public async Task<CamionDTO> PostCamion(int placa, int capacidad, string tipoVehiculo, string unidadCapacidad)
        {
            Camion camion = new Camion()
            {
                Placa = placa,
                Capacidad = capacidad,
                TipoVehiculo = tipoVehiculo,
                UnidadCapacidad = unidadCapacidad
            };

            context.Caminon.Add(camion);
            await context.SaveChangesAsync();

            return camion.toCamionDTO();
        }
    }
}
