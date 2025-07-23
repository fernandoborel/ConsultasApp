namespace ConsultasApp.Domain.Entities;

public class Medico
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int AnosDeExperiencia { get; set; }
    public int Crm { get; set; }
    public string Especialidade { get; set; }
    public DateTime DataDeNascimento { get; set; }
    public DateTime HorariosDisponiveis { get; set; }
    public ICollection<Consulta> Consultas { get; set; } = new List<Consulta>();
}