﻿namespace PersistencePoc.Core.Entities
{
    public class Simulacao
    {
        public int SimulacaoID { get; set; }
        public DateTime DataSimulacao { get; set; }
        public int ClienteID { get; set; }
        public int VendedorID { get; set; }
        public int ConcessionariaID { get; set; }
        public int ProdutoID { get; set; }
        public int? SeguroID { get; set; }
        public decimal? ValorVeiculo { get; set; }
        public decimal? Entrada { get; set; }
        public int? QuantidadeParcelas { get; set; }
        public decimal? ValorParcela { get; set; }
        public decimal? TaxaJuros { get; set; }
        public string SistemaAmortizacao { get; set; }
        public decimal? TotalFinanciado { get; set; }
        public decimal? TotalPagar { get; set; }
        public DateTime? DataPrimeiraParcela { get; set; }
        public string Observacoes { get; set; }
        public string Status { get; set; }
        public bool? SeguroIncluso { get; set; }
        public decimal? ValorSeguro { get; set; }
        public decimal? Descontos { get; set; }
        public decimal? TaxasAdicionais { get; set; }
        public decimal? IOF { get; set; }
        public decimal? CET { get; set; }
        public DateTime? DataValidade { get; set; }
        public int? UsuarioID { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataModificacao { get; set; }
        public string TipoFinanciamento { get; set; }
        public string BancoFinanciador { get; set; }
        public bool? Aprovado { get; set; }

        // Navigation Properties
        public Cliente Cliente { get; set; }
        public Vendedor Vendedor { get; set; }
        public Concessionaria Concessionaria { get; set; }
        public Produto Produto { get; set; }
        public Seguro Seguro { get; set; }
        public ICollection<Proposta> Propostas { get; set; }
    }
}
