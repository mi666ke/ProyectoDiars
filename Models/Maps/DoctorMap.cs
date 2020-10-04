using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DentoWeb.Models.Maps
{
    public class DoctorMap : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        { 
            builder.ToTable("Doctor");
            builder.HasKey(o => o.idDoctor);
        }
    }
}