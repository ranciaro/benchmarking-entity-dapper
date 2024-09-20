using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistencePoc.Core.Entities
{
    public class Simulacao
    {
        public int SimulacaoID { get; set; }
        public int ClienteID { get; set; }
        public int ProdutoID { get; set; }
        public int ConcessionariaID { get; set; }
        public DateTime? DataSimulacao { get; set; }
        public decimal ValorVeiculo { get; set; }
        public decimal ValorEntrada { get; set; }
        public int PrazoFinanciamento { get; set; }
        public decimal TaxaJurosMensal { get; set; }
        public decimal ValorFinanciado { get; set; }
        public decimal ValorParcela { get; set; }
        public decimal TotalAPagar { get; set; }
        public string Observacoes { get; set; }
        public string TipoFinanciamento { get; set; }
        public bool SeguroIncluso { get; set; }
        public decimal IOF { get; set; }
        public decimal TarifaCadastro { get; set; }
        public decimal CET { get; set; }
        public decimal ValorSeguro { get; set; }
        public decimal ValorIOF { get; set; }
        public decimal ValorTarifas { get; set; }
        public string Vendedor { get; set; }
        public string StatusSimulacao { get; set; }
        public DateTime? DataValidade { get; set; }
        public int ScoreCredito { get; set; }
        public string MotivoRejeicao { get; set; }
        public DateTime? DataAprovacao { get; set; }
        public DateTime? DataRejeicao { get; set; }
        public string NumeroProposta { get; set; }
        public string InstituicaoFinanceira { get; set; }
        public decimal ValorTaxas { get; set; }
        public decimal TaxaJurosAnual { get; set; }
        public DateTime? DataPrimeiroVencimento { get; set; }
        public decimal ComissaoVendedor { get; set; }
        public decimal ValorTotalImpostos { get; set; }
        public decimal ValorTotalSeguro { get; set; }
        public decimal ValorTotalFinanciado { get; set; }
        public int QuantidadeParcelas { get; set; }

        // Propriedades de navegação (opcionais)
        public Cliente Cliente { get; set; }
        public Produto Produto { get; set; }
        public Concessionaria Concessionaria { get; set; }
    }
}
