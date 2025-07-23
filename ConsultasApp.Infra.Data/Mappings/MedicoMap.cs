using ConsultasApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsultasApp.Infra.Data.Mappings;

public class MedicoMap : IEntityTypeConfiguration<Medico>
{
    public void Configure(EntityTypeBuilder<Medico> builder)
    {
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Nome)
               .IsRequired()
               .HasMaxLength(150);

        builder.Property(m => m.AnosDeExperiencia)
               .IsRequired();

        builder.Property(m => m.DataDeNascimento)
               .IsRequired();

        builder.Property(m => m.Crm)
               .IsRequired();

        // Relacionamento 1:N: Medico => Consultas
        builder.HasMany(m => m.Consultas)
               .WithOne(c => c.Medico)
               .HasForeignKey(c => c.MedicoId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}