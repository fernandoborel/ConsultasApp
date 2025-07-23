using ConsultasApp.Domain.Entities;
using ConsultasApp.Domain.Interfaces.Repositories;
using ConsultasApp.Infra.Data.Contexts;

namespace ConsultasApp.Infra.Data.Repositories;

public class ConsultaRepository : BaseRepository<Consulta>, IConsultaRepository
{
    public ConsultaRepository(DataContext context) : base(context)
    {
    }
}