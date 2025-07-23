using ConsultasApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsultasApp.Infra.Data.Mappings;

public class ConsultaMap : IEntityTypeConfiguration<Consulta>
{
    public void Configure(EntityTypeBuilder<Consulta> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.DataHora)
               .IsRequired();

        builder.HasOne(c => c.Medico)
               .WithMany(m => m.Consultas)
               .HasForeignKey(c => c.MedicoId);

        builder.HasOne(c => c.Paciente)
               .WithMany(p => p.Consultas)
               .HasForeignKey(c => c.PacienteId);
    }
}
