using ConsultasApp.Application.Dtos.Request;
using ConsultasApp.Application.Dtos.Response;
using ConsultasApp.Domain.Entities;

namespace ConsultasApp.Application.Interfaces;

public interface IConsultaAppService
{
    Task<ConsultaResponse> Adicionar(ConsultaRequest request);
    Task<List<Consulta>> ObterTodos();
    Task<(List<ConsultaPaginadaResponse> Consultas, int TotalCount)> ObterConsultasPaginadasAsync(int pagina, int tamanhoPagina);
}