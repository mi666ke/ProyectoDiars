using DentoWeb.Models.Maps;
using Microsoft.EntityFrameworkCore;

namespace DentoWeb.Models.Db
{
    public class DentoWebContext : DbContext
    {
public DentoWebContext(DbContextOptions<DentoWebContext> options) : base(options)
{
    
}

        public DbSet<Cliente> Clientes {get;set;}
        public DbSet<Doctor> Doctores {get;set;}
        public DbSet<Cita> Citas {get;set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new DoctorMap());
            modelBuilder.ApplyConfiguration(new CitaMap());
        }
    }
}