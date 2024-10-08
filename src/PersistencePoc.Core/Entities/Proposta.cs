﻿using Dapper.Contrib.Extensions;

namespace PersistencePoc.Core.Entities
{
    public class Proposta
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataProposta { get; set; }
        public decimal? ValorProposto { get; set; }
        public decimal? ValorEntrada { get; set; }
        public int? QuantidadeParcelas { get; set; }
        public decimal? ValorParcela { get; set; }
        public decimal? TaxaJuros { get; set; }
        public decimal? TotalFinanciado { get; set; }
        public decimal? TotalPagar { get; set; }
        public DateTime? DataPrimeiraParcela { get; set; }
        public string? Status { get; set; }
        public bool? Aprovado { get; set; }
        public DateTime? DataAprovacao { get; set; }
        public string? Observacoes { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataModificacao { get; set; }
        public bool? DocumentosEnviados { get; set; }
        public DateTime? DataEnvioDocumentos { get; set; }
        public DateTime? DataAnalise { get; set; }
        public DateTime? DataConclusao { get; set; }
        public string? MotivoRecusa { get; set; }
        public string? TipoFinanciamento { get; set; }
        public string? BancoFinanciador { get; set; }
        public decimal? IOF { get; set; }
        public decimal? CET { get; set; }
        public decimal? Descontos { get; set; }
        public decimal? TaxasAdicionais { get; set; }
        public bool? SeguroIncluso { get; set; }
        public decimal? ValorSeguro { get; set; }
        public string? ObservacoesInternas { get; set; }
        public int? ScoreCredito { get; set; }
        public string? Garantias { get; set; }
        public bool? ContratoGerado { get; set; }

        // Navigation Properties
        public int? SimulacaoId { get; set; }
        public virtual Simulacao? Simulacao { get; set; }
        public int? ClienteId { get; set; }
        public virtual Cliente? Cliente { get; set; }
        public int? ProdutoId { get; set; }
        public virtual Produto? Produto { get; set; }
        public int? ConcessionariaId { get; set; }
        public virtual Concessionaria? Concessionaria { get; set; }
        public int? SeguroId { get; set; }
        public virtual Seguro? Seguro { get; set; }
        public int? VendedorId { get; set; }
        public virtual Vendedor? Vendedor { get; set; }
    }
}
