using ConsultasApp.Application.Dtos.Request;
using ConsultasApp.Application.Dtos.Response;
using ConsultasApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConsultasApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConsultasController : ControllerBase
{
    private readonly IConsultaAppService _consultaAppService;

    public ConsultasController(IConsultaAppService consultaAppService)
    {
        _consultaAppService = consultaAppService;
    }

    [HttpGet("obter-todos")]
    [ProducesResponseType(typeof(List<ConsultaResponse>), 200)]
    [ProducesResponseType(typeof(object), 400)]
    [ProducesResponseType(typeof(string), 500)]
    public async Task<IActionResult> ObterTodos()
    {
        var consultas = await _consultaAppService.ObterTodos();
        return Ok(consultas);
    }

    [HttpGet("paginadas")]
    [ProducesResponseType(typeof(List<ConsultaPaginadaResponse>), 200)]
    [ProducesResponseType(typeof(object), 400)]
    [ProducesResponseType(typeof(string), 500)]
    public async Task<IActionResult> ObterConsultasPaginadas([FromQuery] int pagina = 1, [FromQuery] int tamanhoPagina = 10)
    {
        try
        {
            var (consultas, totalCount) = await _consultaAppService.ObterConsultasPaginadasAsync(pagina, tamanhoPagina);

            var resultado = new
            {
                TotalRegistros = totalCount,
                PaginaAtual = pagina,
                TamanhoPagina = tamanhoPagina,
                Consultas = consultas
            };

            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno: {ex.Message}");
        }
    }


    [HttpPost("adicionar")]
    [ProducesResponseType(typeof(ConsultaResponse), 200)]
    [ProducesResponseType(typeof(object), 400)]
    [ProducesResponseType(typeof(string), 500)]
    public async Task<IActionResult> Adicionar([FromBody] ConsultaRequest request)
    {
        if (request == null)
            return BadRequest("Dados da consulta não podem ser nulos.");
        try
        {
            var consulta = await _consultaAppService.Adicionar(request);
            return Ok(consulta);
        }
        catch (ApplicationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}