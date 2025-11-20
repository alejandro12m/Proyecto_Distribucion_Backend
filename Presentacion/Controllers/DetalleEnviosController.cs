using Distribucion.Core.DTOs;
using Distribucion.Core.Entidades;
using Distribucion.Core.Interfaces;
using Distribucion.Infraestructura.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Distribucion.Presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleEnviosController : ControllerBase
    {
        private readonly IDetalleEnvioRepositorio context;

        public DetalleEnviosController(IDetalleEnvioRepositorio context)
        {
            this.context = context;
        }



        //GET: api/DetalleEnvio/Todos
        [HttpGet("ListaDetalleEnvios")]
        public async Task<IActionResult> GetDetalleEnvio()
        {
            return Ok(await context.GetDetalleEnvio());
        }


        // GET: api/DetalleEnvios/codigo
        [HttpGet("{CodigoDetalleEnvio}")]
        public async Task<IActionResult> GetDetalleDetalleEnvioCodigo(int CodigoDetalleEnvio)
        {
            var detalleEnvio = await context.GetDetalleDetalleEnvioCodigo(CodigoDetalleEnvio);
            if (detalleEnvio == null)
            {
                return NotFound();
            }

            return Ok(detalleEnvio);
        }

        // GET: api/DetalleEnvios
        [HttpGet("ListarCodigoEnvio{codigoEnvio}")]
        public async Task<IActionResult> GetDetalleEnvioCodigo(int codigoEnvio) {

            return Ok(await context.GetDetalleEnvioCodigo(codigoEnvio));


        }
        //Post 
        [HttpPost("MeterDatos")]

        public async Task<IActionResult> PostDetalleEnvio(int codigoDetallle, int codigoProducto, int codigoEnvio, int catidad, string undidadMedida)
        {
            return Ok(await context.PostDetalleEnvio(codigoDetallle, codigoProducto, codigoEnvio,catidad,undidadMedida));

        }

        // Put: api/DetalleEnvio/PutDetalleEnvio

        [HttpPut("EditarDetalleEnvio")]
        public async Task<IActionResult> PutDetalleEnvio(int codigo, int cantidad, string unidad, int codigoProducto)
        {

            DetalleEnvioDTO DetalleEnvio = await context.PutDetalleEnvio(codigo, cantidad, unidad, codigoProducto);
            if (DetalleEnvio == null)
            {
                return NotFound();
            }
            return Ok(DetalleEnvio);
        }
        //Delete: api/DetalleEnvio/DeleteDetalleEnvio
        [HttpDelete("DetalleEnvio {codigo}")]
        public async Task<IActionResult> DeleteDetalleEnvio(int codigo)
        {

            DetalleEnvioDTO detalleEnvio = await context.DeleteDetalleEnvio(codigo);
            if (detalleEnvio == null)
            {
                return NotFound();
            }
            return Ok(detalleEnvio);
        }



        }
    }
