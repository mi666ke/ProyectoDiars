using Microsoft.EntityFrameworkCore;
using DentoWeb.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DentoWeb.Models.Maps
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey( o => o.idCliente);
        }
    }
}