using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Distribucion.Core.Entidades;

namespace Distribucion.Infraestructura.Data
{
    public class DistribucionContext : DbContext
    {
        public DistribucionContext (DbContextOptions<DistribucionContext> options)
            : base(options)
        {
        }

        public DbSet<Envio> Envio { get; set; } = default!;
        public DbSet<Distribucion.Core.Entidades.DetalleEnvio> DetalleEnvio { get; set; } = default!;
        public DbSet<Distribucion.Core.Entidades.Camion> Caminon { get; set; } = default!;
    }
}
