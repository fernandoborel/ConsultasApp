namespace ConsultasApp.Application.Dtos.Response;

public class MedicoResponse
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int AnosDeExperiencia { get; set; }
    public int CRM { get; set; }
    public DateTime DataDeNascimento { get; set; }
    public DateTime HorariosDisponiveis { get; set; }
}
