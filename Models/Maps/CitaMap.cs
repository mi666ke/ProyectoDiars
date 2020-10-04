using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DentoWeb.Models.Maps
{
    public class CitaMap : IEntityTypeConfiguration<Cita>
    {
        public void Configure(EntityTypeBuilder<Cita> builder)
        {
            builder.ToTable("Cita");
            builder.HasKey(o => o.idCita);
            builder.HasOne(o => o.cliente).WithMany().HasForeignKey(o=>o.idCliente);
            builder.HasOne(o => o.doctor).WithMany().HasForeignKey(o => o.idDoctor);
        }
    }
}