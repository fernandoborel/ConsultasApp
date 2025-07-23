using ConsultasApp.Application.Dtos.Request;
using ConsultasApp.Application.Dtos.Response;
using ConsultasApp.Domain.Entities;

namespace ConsultasApp.Application.Interfaces;

public interface IMedicoAppService
{
    Task<MedicoResponse> Adicionar(MedicoRequest request);
    Task<List<Medico>> ObterTodos();
}