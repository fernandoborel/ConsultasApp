using ConsultasApp.Application.Dtos.Request;
using ConsultasApp.Application.Dtos.Response;
using ConsultasApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConsultasApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PacientesController : ControllerBase
{
    private readonly IPacienteAppService _pacienteAppService;

    public PacientesController(IPacienteAppService pacienteAppService)
    {
        _pacienteAppService = pacienteAppService;
    }

    [HttpGet("obter-todos")]
    [ProducesResponseType(typeof(List<PacienteResponse>), 200)]
    [ProducesResponseType(typeof(object), 400)]
    [ProducesResponseType(typeof(string), 500)]
    public async Task<IActionResult> ObterTodos()
    {
        var pacientes = await _pacienteAppService.ObterTodos();
        return Ok(pacientes);
    }

    [HttpPost("adicionar")]
    [ProducesResponseType(typeof(PacienteResponse), 200)]
    [ProducesResponseType(typeof(object), 400)]
    [ProducesResponseType(typeof(string), 500)]
    public async Task<IActionResult> Adicionar([FromBody] PacienteRequest request)
    {
        if (request == null)
            return BadRequest("Dados do paciente não podem ser nulos.");

        try
        {
            var paciente = await _pacienteAppService.Adicionar(request);
            return Ok(paciente);
        }
        catch (ApplicationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
