using ConsultasApp.Application.Dtos.Request;
using ConsultasApp.Application.Dtos.Response;
using ConsultasApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConsultasApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MedicosController : ControllerBase
{
    private readonly IMedicoAppService _medicoAppService;

    public MedicosController(IMedicoAppService medicoAppService)
    {
        _medicoAppService = medicoAppService;
    }

    [HttpGet("obter-todos")]
    [ProducesResponseType(typeof(List<MedicoResponse>), 200)]
    [ProducesResponseType(typeof(object), 400)]
    [ProducesResponseType(typeof(string), 500)]
    public async Task<IActionResult> ObterTodos()
    {
        var medicos = await _medicoAppService.ObterTodos();
        return Ok(medicos);
    }

    [HttpPost("adicionar")]
    [ProducesResponseType(typeof(MedicoResponse), 200)]
    [ProducesResponseType(typeof(object), 400)]
    [ProducesResponseType(typeof(string), 500)]
    public async Task<IActionResult> Adicionar([FromBody] MedicoRequest request)
    {
        if (request == null)
            return BadRequest("Dados do médico não podem ser nulos.");

        try
        {
            var medico = await _medicoAppService.Adicionar(request);
            return Ok(medico);
        }
        catch (ApplicationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
