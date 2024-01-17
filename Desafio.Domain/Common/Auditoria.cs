namespace Desafio.Domain.Common
{
    public class Auditoria
    {
        public string? CriadoPor {  get; set; }
        public DateTime DataCriacao { get; set; }
        public string? AlteradoPor { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
