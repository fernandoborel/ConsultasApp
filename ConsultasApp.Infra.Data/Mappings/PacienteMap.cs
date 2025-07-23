using ConsultasApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsultasApp.Infra.Data.Mappings;

public class PacienteMap : IEntityTypeConfiguration<Paciente>
{
    public void Configure(EntityTypeBuilder<Paciente> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
               .IsRequired()
               .HasMaxLength(150);

        builder.Property(p => p.Cpf)
               .IsRequired()
               .HasMaxLength(14);

        builder.Property(p => p.DataDeNascimento)
               .IsRequired();

        builder.Property(p => p.Informacoes)
               .HasMaxLength(500);

        builder.HasOne(p => p.Endereco)
               .WithOne(e => e.Paciente)
               .HasForeignKey<Paciente>(p => p.EnderecoId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.Consultas)
               .WithOne(c => c.Paciente)
               .HasForeignKey(c => c.PacienteId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}