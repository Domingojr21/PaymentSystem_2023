using Microsoft.EntityFrameworkCore;
using SistemadeFacturacion_2023.Models;

namespace SistemadeFacturacion_2023.Context
{
    public class FacturaContext : DbContext
    {
        public FacturaContext(DbContextOptions<FacturaContext> options) : base(options) { }

        public DbSet<Clientes> CLIENTES { get; set; }
        public DbSet<Factura> FACTURA { get; set; }
        public DbSet<Productos> PRODUCTOS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>().HasKey(e => e.IDcliente);
            modelBuilder.Entity<Factura>().HasKey(e => e.IDFactura);
            modelBuilder.Entity<Productos>().HasKey(e => e.IDProductos);
        }
    }
}
