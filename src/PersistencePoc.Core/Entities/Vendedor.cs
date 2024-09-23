using Dapper.Contrib.Extensions;

namespace PersistencePoc.Core.Entities
{
    public class Vendedor
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? NumeroDocumento { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public DateTime? DataContratacao { get; set; }
        public decimal? Salario { get; set; }
        public decimal? PercentualComissao { get; set; }
        public bool Ativo { get; set; }
        public string? Observacoes { get; set; }

        // Navigation Properties
        public int? TipoDocumentoId { get; set; }
        public virtual TipoDocumento? TipoDocumento { get; set; }
        public int? EnderecoId { get; set; }
        public virtual Endereco? Endereco { get; set; }
        public int? ConcessionariaId { get; set; }
        public virtual Concessionaria? Concessionaria { get; set; }
        public virtual ICollection<Simulacao>? Simulacoes { get; set; }
        public virtual ICollection<Seguro>? Seguros { get; set; }
        public virtual ICollection<Proposta>? Propostas { get; set; }
    }
}
