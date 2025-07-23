namespace ConsultasApp.Domain.Entities;

public class Paciente
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public string Cpf { get; set; }

    public DateTime DataDeNascimento { get; set; }

    public string Informacoes { get; set; }

    #region Relacionamentos
    public int EnderecoId { get; set; }
    public Endereco Endereco { get; set; }

    public ICollection<Consulta> Consultas { get; set; }
    #endregion
}