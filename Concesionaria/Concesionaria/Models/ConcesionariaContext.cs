using Microsoft.EntityFrameworkCore;

namespace Concesionaria.Models
{
    public class ConcesionariaContext:DbContext
    {
        public virtual DbSet<Cliente> clientes { get; set; }
        public virtual DbSet<Plan> planes { get; set; }
        public virtual DbSet<Factura> facturas { get; set; }
        public virtual DbSet<Vehiculo> vehiculos { get; set; }
        public virtual DbSet<Vendedor> vendedores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuider)
        {

            optionsBuider.UseSqlServer("Data Source= DESKTOP-O26FGC7\\SQLEXPRESS; Initial Catalog=Concesionaria; " +
                    "Integrated Security=true");

        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            modelBuilder.Entity<Plan>()
          .HasOne(d => d.Vehiculo)
          .WithMany()
         .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Plan>()
         .HasOne(d => d.Cliente)
         .WithMany()
         .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
