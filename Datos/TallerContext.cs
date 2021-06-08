using System;
using Entidad;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class TallerContext: DbContext
    {
        public TallerContext(DbContextOptions options): base (options)
        {
            
        }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Cita> Citas { get; set; } 
    }
}
