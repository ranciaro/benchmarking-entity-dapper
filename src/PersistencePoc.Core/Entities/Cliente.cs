using Dapper.Contrib.Extensions;

namespace PersistencePoc.Core.Entities
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public char? Sexo { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? OrgaoEmissor { get; set; }
        public DateTime? DataEmissao { get; set; }
        public string? EstadoCivil { get; set; }
        public string? Nacionalidade { get; set; }
        public string? Profissao { get; set; }
        public decimal? RendaMensal { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }

        // Navigation Properties
        public int? TipoDocumentoId { get; set; }
        public virtual TipoDocumento? TipoDocumento { get; set; }
        public virtual ICollection<Endereco>? Enderecos { get; set; }
        public virtual ICollection<ClienteConcessionaria>? ClienteConcessionarias { get; set; }
        public virtual ICollection<Simulacao>? Simulacoes { get; set; }
        public virtual ICollection<Proposta>? Propostas { get; set; }
        public virtual ICollection<Seguro>? Seguros { get; set; }
    }
}
