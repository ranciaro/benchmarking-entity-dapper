using Dapper.Contrib.Extensions;

namespace PersistencePoc.Core.Entities
{
    public class Seguro
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal? ValorPremio { get; set; }
        public decimal? Franquia { get; set; }
        public string? Cobertura { get; set; }
        public string? TipoSeguro { get; set; }
        public string? Seguradora { get; set; }
        public DateTime? DataInicioVigencia { get; set; }
        public DateTime? DataFimVigencia { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataModificacao { get; set; }
        public bool Ativo { get; set; }
        public string? ApoliceNumero { get; set; }
        public string? FormaPagamento { get; set; }
        public int? Parcelas { get; set; }
        public decimal? ValorParcela { get; set; }
        public string? Observacoes { get; set; }
        public string? TipoCobertura { get; set; }
        public bool? Assistencia24h { get; set; }
        public bool? CarroReserva { get; set; }
        public bool? ProtecaoVidros { get; set; }
        public bool? DanosTerceiros { get; set; }
        public bool? MorteAcidental { get; set; }
        public bool? InvalidezPermanente { get; set; }
        public bool? AssistenciaFuneral { get; set; }

        // Navigation Properties
        public int? ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        public int? ProdutoId { get; set; }
        public Produto? Produto { get; set; }
        public int? VendedorId { get; set; }
        public Vendedor? Vendedor { get; set; }
        public int? ConcessionariaId { get; set; }
        public Concessionaria? Concessionaria { get; set; }
        public ICollection<Simulacao>? Simulacoes { get; set; }
        public ICollection<Proposta>? Propostas { get; set; }
    }
}
