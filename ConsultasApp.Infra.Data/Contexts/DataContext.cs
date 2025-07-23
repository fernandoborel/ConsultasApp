using ConsultasApp.Domain.Entities;
using ConsultasApp.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ConsultasApp.Infra.Data.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Consulta> Consultas { get; set; }
    public DbSet<Medico> Medicos { get; set; }
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ConsultaMap());
        modelBuilder.ApplyConfiguration(new MedicoMap());
        modelBuilder.ApplyConfiguration(new PacienteMap());
        modelBuilder.ApplyConfiguration(new EnderecoMap());
    }
}