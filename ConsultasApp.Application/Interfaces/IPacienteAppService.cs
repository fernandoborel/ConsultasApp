using ConsultasApp.Application.Dtos.Request;
using ConsultasApp.Application.Dtos.Response;
using ConsultasApp.Domain.Entities;

namespace ConsultasApp.Application.Interfaces;

public interface IPacienteAppService
{
    Task<PacienteResponse> Adicionar(PacienteRequest request);
    Task<List<Paciente>> ObterTodos();
}