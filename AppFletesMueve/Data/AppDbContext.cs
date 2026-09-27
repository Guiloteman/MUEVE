using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using AppFletesMueve.Models;

namespace AppFletesMueve.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Conductor> Conductores { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<SolicitudFlete> SolicitudFletes { get; set; }
        public DbSet<SolicitudCarga> SolicitudCargas { get; set; }
        public DbSet<TipoCarga> TipoCargas { get; set; }
        public DbSet<VehiculoModel> VehiculoModels { get; set; }

        // Constructor principal que requiere Entity Framework Core (usado en MauiProgram)
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        // Constructor por defecto opcional
        public AppDbContext()
        {
        }
    }
}