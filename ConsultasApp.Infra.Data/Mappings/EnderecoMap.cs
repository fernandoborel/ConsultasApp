using ConsultasApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsultasApp.Infra.Data.Mappings;

public class EnderecoMap : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Logradouro)
               .IsRequired()
               .HasMaxLength(150);

        builder.Property(e => e.Numero)
               .IsRequired();

        builder.Property(e => e.Cep)
               .IsRequired()
               .HasMaxLength(10);

        builder.Property(e => e.Municipio)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(e => e.Uf)
               .IsRequired()
               .HasMaxLength(2);

        // Relacionamento 1:1 com Paciente
        builder.HasOne(e => e.Paciente)
               .WithOne(p => p.Endereco)
               .HasForeignKey<Paciente>(p => p.EnderecoId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}