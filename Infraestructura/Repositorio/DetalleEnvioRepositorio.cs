using Distribucion.Core.DTOs;
using Distribucion.Core.Entidades;
using Distribucion.Core.Interfaces;
using Distribucion.Core.Mapeadores;
using Distribucion.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace Distribucion.Infraestructura.Repositorio
{
    public class DetalleEnvioRepositorio : IDetalleEnvioRepositorio
    {
        private readonly DistribucionContext context;

        public DetalleEnvioRepositorio(DistribucionContext context)
        {
            this.context = context;
        }
        public async Task<List<DetalleEnvioDTO>> GetDetalleEnvio()
        {
            var DetalleEnvios = await(
                        from u in context.DetalleEnvio
                        select u).Select(us => us.toDetalleEnvioDTO()).ToListAsync();
            return DetalleEnvios;
        }


        public async Task<DetalleEnvioDTO> GetDetalleDetalleEnvioCodigo(int codigoDetalleEnvio)
        {
            return await (
               from d in context.DetalleEnvio
               where d.CodigoDetalleEnvio == codigoDetalleEnvio
               select d.toDetalleEnvioDTO()).FirstOrDefaultAsync();
        }

        public async Task<List<DetalleEnvioDTO>> GetDetalleEnvioCodigo(int codigoEnvio)
        {
            var DetalleEnvio = await (
                      from d in context.DetalleEnvio
                      where d.CodigoEnvio == codigoEnvio
                      select d).Select(us => us.toDetalleEnvioDTO()).ToListAsync();
            return DetalleEnvio;
        }

        public async Task<DetalleEnvioDTO> PostDetalleEnvio(int codigoDetalle, int codigoProducto, int codigoEnvio, int cantidad, string undidadMedida)
        {
            DetalleEnvio DetalleEnvio = new DetalleEnvio() {
                CodigoDetalleEnvio = codigoDetalle,
                CodigoProducto = codigoProducto,
                CodigoEnvio = codigoEnvio, 
                Cantidad = cantidad,
                UnidadMedida = undidadMedida
            };
            context.DetalleEnvio.Add(DetalleEnvio);
            await context.SaveChangesAsync();

            return DetalleEnvio.toDetalleEnvioDTO();
        }

        public async Task<DetalleEnvioDTO> PutDetalleEnvio(int codigo, int cantidad, string unidad, int codigoProducto)
        {
            var detalleEnvio = await(
                       from d in context.DetalleEnvio
                       where d.CodigoDetalleEnvio == codigo
                       select d).FirstOrDefaultAsync();
            if (detalleEnvio == null)
            {
                throw new Exception("No se encontro ese Envio");
            }
            detalleEnvio.Cantidad = cantidad;
            detalleEnvio.UnidadMedida = unidad;
            detalleEnvio.CodigoProducto = codigoProducto;
            context.DetalleEnvio.Update(detalleEnvio);
            await context.SaveChangesAsync();
            return detalleEnvio.toDetalleEnvioDTO();
        }

        public async Task<DetalleEnvioDTO> DeleteDetalleEnvio(int codigo)
        {
            var DetalleEnvio = await(
                  from e in context.DetalleEnvio
                  where e.CodigoDetalleEnvio == codigo
                  select e).FirstOrDefaultAsync();
            if (DetalleEnvio == null)
            {
                throw new Exception("No se encontro ese DetalleEnvio");
            }
            DetalleEnvio.Estado = "Cancelado";
            context.DetalleEnvio.Update(DetalleEnvio);
            await context.SaveChangesAsync();
            return DetalleEnvio.toDetalleEnvioDTO();
        }

    }
}
