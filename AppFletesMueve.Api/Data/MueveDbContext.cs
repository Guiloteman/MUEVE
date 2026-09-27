using Microsoft.EntityFrameworkCore;
using AppFletesMueve.Api.Models;

namespace AppFletesMueve.Api.Data
{
    public class MueveDbContext : DbContext
    {
        public MueveDbContext(DbContextOptions<MueveDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Conductor> Conductores { get; set; }
        public DbSet<SolicitudCarga> Pedidos { get; set; }
        public DbSet<TipoCarga> TiposCarga { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<VehiculoModel> VehiculoModelos { get; set; }

    }
}