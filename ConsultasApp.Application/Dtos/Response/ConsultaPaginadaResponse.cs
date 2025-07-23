namespace ConsultasApp.Application.Dtos.Response;

public class ConsultaPaginadaResponse
{
    public int Id { get; set; }
    public string NomeMedico { get; set; }
    public string EspecialidadeMedico { get; set; }
    public string NomePaciente { get; set; }
    public DateTime DataHora { get; set; }
}
