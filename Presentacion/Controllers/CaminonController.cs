using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Distribucion.Core.Entidades;
using Distribucion.Infraestructura.Data;
using Distribucion.Core.Interfaces;

namespace Distribucion.Presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaminonController : ControllerBase
    {
        private readonly ICamionRepositorio context;

        public CaminonController(ICamionRepositorio context)
        {
            this.context = context;
        }
        //GET: api/DetalleEnvio/Todos
        [HttpGet("ListarCamiones")]
        public async Task<IActionResult> GetCamion()
        {
            return Ok(await context.GetCamion());
        }
        //Post :api/Camion/
        [HttpPost()]
        public async Task<IActionResult> PostCamion(int placa, int capacidad, string tipoVehiculo, string unidadCapacidad)
        {
            var result = await context.PostCamion(placa, capacidad, tipoVehiculo, unidadCapacidad);
            return Ok(result);
        }



        /*
        // GET: api/Caminons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Camion>>> GetCaminon()
        {
            return await _context.Caminon.ToListAsync();
        }

        // GET: api/Caminons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Camion>> GetCaminon(int id)
        {
            var caminon = await context.Caminon.FindAsync(id);

            if (caminon == null)
            {
                return NotFound();
            }

            return caminon;
        }

        // PUT: api/Caminons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaminon(int id, Camion caminon)
        {
            if (id != caminon.Id)
            {
                return BadRequest();
            }

            context.Entry(caminon).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaminonExists(id))
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

        // POST: api/Caminons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Camion>> PostCaminon(Camion caminon)
        {
            context.Caminon.Add(caminon);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetCaminon", new { id = caminon.Id }, caminon);
        }

        // DELETE: api/Caminons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCaminon(int id)
        {
            var caminon = await context.Caminon.FindAsync(id);
            if (caminon == null)
            {
                return NotFound();
            }

            context.Caminon.Remove(caminon);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool CaminonExists(int id)
        {
            return context.Caminon.Any(e => e.Id == id);
        }*/
    }
}
