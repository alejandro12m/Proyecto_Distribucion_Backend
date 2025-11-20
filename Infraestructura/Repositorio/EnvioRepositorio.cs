using Distribucion.Core.DTOs;
using Distribucion.Core.Entidades;
using Distribucion.Core.Interfaces;
using Distribucion.Core.Mapeadores;
using Distribucion.Infraestructura.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Distribucion.Infraestructura.Repositorio
{
    public class EnvioRepositorio : IEnvioRepositorio
    {
        private readonly DistribucionContext context;

        public EnvioRepositorio(DistribucionContext context)
        {
            this.context = context;
        }
        public async Task<EnvioDTO> GetEnvioCodigo(int Codigo)
        {
            return await (
                from u in context.Envio
                where u.Codigo == Codigo
                select u.toEnvioDTO()).FirstOrDefaultAsync();
                
        }
        public async Task<List<EnvioDTO>> GetEnvio()
        {
                var envio = await(
                 from u in context.Envio
                 select u).Select(us => us.toEnvioDTO()).ToListAsync();
            return envio;                

        }

        public async Task<List<EnvioDTO>> GetEnvioPendiente()
        {
            var pendientes = await (
                 from u in context.Envio
                 where u.Estado == "Pendiente"
                 select u).Select(us => us.toEnvioDTO()).ToListAsync();
            return pendientes;
        }
        public async Task<List<EnvioDTO>> GetEnvioCancelados()
        {
            var cancelados = await (
                from e in context.Envio
                where e.Estado == "Cancelado"
                select e).Select(us => us.toEnvioDTO()).ToListAsync();

            return cancelados;
        }
        public async Task<List<EnvioDTO>> GetEnvioEntregados()
        {
            var entregado = await (
                            from e in context.Envio
                            where e.Estado == "Entregado"
                            select e).Select(us => us.toEnvioDTO()).ToListAsync();

            return entregado;
        }

        public async Task<EnvioDTO> PostEnvio(int codigo,DateOnly fechaEnvio,string detalles,string tipo)
        {
            Envio envio = new Envio() { Codigo = codigo, FechaEnvio = fechaEnvio, Detalles = detalles, Tipo = tipo };
            context.Envio.Add(envio);
            await context.SaveChangesAsync();

            return envio.toEnvioDTO();
        }
        public async Task<EnvioDTO> PutEstadoEnvio(int codigo ,string estado)
        {
            var envio = await (
                from e in context.Envio
                where e.Codigo == codigo
                select e).FirstOrDefaultAsync();
            if (envio == null)
            {
                throw new Exception("No se encontro ese Envio");
            }
            envio.Estado = estado;
            context.Envio.Update(envio);
            await context.SaveChangesAsync();
            return envio.toEnvioDTO();
        }

        public async Task<EnvioDTO> DeleteEnvio(int codigo)
        {
            var envio = await (
              from e in context.Envio
              where e.Codigo == codigo
              select e).FirstOrDefaultAsync();
            if (envio == null)
            {
                throw new Exception("No se encontro ese Envio");
            }
            envio.Estado = "Cancelado";
            context.Envio.Update(envio);
            await context.SaveChangesAsync();
            return envio.toEnvioDTO();

        }



    }
}
