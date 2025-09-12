using Microsoft.EntityFrameworkCore;
using PD1.Models;

namespace PD1.Data
{
    public class SistemaPD1Context : DbContext
    {
        public SistemaPD1Context(DbContextOptions<SistemaPD1Context> options) : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Categoria>().ToTable("Categorias");
            modelBuilder.Entity<Proveedor>().ToTable("Proveedores");
            modelBuilder.Entity<Producto>().ToTable("Productos");
            modelBuilder.Entity<Cliente>().ToTable("Clientes");
        }
    }
}