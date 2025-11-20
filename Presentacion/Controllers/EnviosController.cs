using Distribucion.Core.DTOs;
using Distribucion.Core.Entidades;
using Distribucion.Core.Interfaces;
using Distribucion.Infraestructura.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Distribucion.Presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnviosController : ControllerBase
    {
        private readonly IEnvioRepositorio context;

        public EnviosController(IEnvioRepositorio context)
        {
            this.context = context;
        }
        // GET: api/Envios/codigo
        [HttpGet("Listar/{Codigo}")]
        public async Task<IActionResult> GetEnvioCodigo([FromRoute] int Codigo)
        {
            var envio = await context.GetEnvioCodigo(Codigo);

            if (envio == null)
            {
                return NotFound();
            }

            return Ok(envio);
        }

        //GET: api/Envios/Todos
        [HttpGet("ListaEnvios")]
        public async Task<IActionResult> GetEnvio() {
            return Ok(await context.GetEnvio());        
        }



        //GET: api/Envios/Cancelados
        [HttpGet("ListaEnviosCancelados")]
        public async Task<IActionResult> GetEnvioCancelados()
        {
            return Ok(await context.GetEnvioCancelados());
        }


        [HttpGet("ListaEnviosPendientes")]
        public async Task<IActionResult> GetEnvioPendiente()
        {
            return Ok(await context.GetEnvioPendiente());
        }


        [HttpGet("ListaEnviosEntregados")]
        public async Task<IActionResult> GetEnvioEntregados()
        {
            return Ok(await context.GetEnvioEntregados());
        }
        //POST
        [HttpPost("IngresarEnvios/{codigo}/{fechaEnvio}/{detalles}/{tipo}")]
        public async Task<IActionResult> PostEnvio(
          [FromRoute] int codigo,
          [FromRoute] DateOnly fechaEnvio,
          [FromRoute] string detalles,
          [FromRoute] string tipo)
        {
            var result = await context.PostEnvio(codigo, fechaEnvio, detalles, tipo);
            return Ok(result);
        }

        //Put: api/Envio/PutEstadoEnvio

        [HttpPut("EditarEstadoEnvio")]
        public async Task<IActionResult> PutEstadoEnvio(int codigo, string estado) { 
        
            EnvioDTO envio = await context.PutEstadoEnvio(codigo,estado);
            if (envio == null)
            {
                return NotFound();
            }
            return Ok(envio);
        }
        // DELETE: api/Envios/Delete
        [HttpDelete("{codigo}")]
        public async Task<IActionResult> DeleteEnvio(int codigo)
        {

            EnvioDTO envio = await context.DeleteEnvio(codigo);
            if (envio == null)
            {
                return NotFound();
            }
            return Ok(envio);

        }



            /*
            // GET: api/Envios
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Envio>>> GetEnvio()
            {
                return await context.Envio.ToListAsync();
            }

            // GET: api/Envios/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Envio>> GetEnvio(int id)
            {
                var envio = await context.Envio.FindAsync(id);

                if (envio == null)
                {
                    return NotFound();
                }

                return envio;
            }

            // PUT: api/Envios/5
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPut("{id}")]
            public async Task<IActionResult> PutEnvio(int id, Envio envio)
            {
                if (id != envio.IdEnvio)
                {
                    return BadRequest();
                }

                context.Entry(envio).State = EntityState.Modified;

                try
                {
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnvioExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();
            }


            // DELETE: api/Envios/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteEnvio(int id)
            {
                var envio = await context.Envio.FindAsync(id);
                if (envio == null)
                {
                    return NotFound();
                }

                context.Envio.Remove(envio);
                await context.SaveChangesAsync();

                return NoContent();
            }

            private bool EnvioExists(int id)
            {
                return context.Envio.Any(e => e.IdEnvio == id);
            }*/
        }
}
