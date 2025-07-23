using ConsultasApp.Domain.Entities;
using ConsultasApp.Domain.Interfaces.Repositories;

namespace ConsultasApp.Infra.Data.Repositories;

public class PacienteRepository : BaseRepository<Paciente>, IPacienteRepository
{
    public PacienteRepository(Contexts.DataContext context) : base(context)
    {
    }
}