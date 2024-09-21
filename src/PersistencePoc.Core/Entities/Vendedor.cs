namespace PersistencePoc.Core.Entities
{
    public class Vendedor
    {
        public int VendedorID { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int TipoDocumentoID { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int? EnderecoID { get; set; }
        public DateTime? DataContratacao { get; set; }
        public decimal? Salario { get; set; }
        public decimal? PercentualComissao { get; set; }
        public int ConcessionariaID { get; set; }
        public bool Ativo { get; set; }
        public string Observacoes { get; set; }

        // Navigation Properties
        public TipoDocumento TipoDocumento { get; set; }
        public Endereco Endereco { get; set; }
        public Concessionaria Concessionaria { get; set; }
        public ICollection<Simulacao> Simulacoes { get; set; }
        public ICollection<Seguro> Seguros { get; set; }
        public ICollection<Proposta> Propostas { get; set; }
    }
}
