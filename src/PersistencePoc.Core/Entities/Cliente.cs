namespace PersistencePoc.Core.Entities
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public char? Sexo { get; set; }
        public int TipoDocumentoID { get; set; }
        public string NumeroDocumento { get; set; }
        public string OrgaoEmissor { get; set; }
        public DateTime? DataEmissao { get; set; }
        public string EstadoCivil { get; set; }
        public string Nacionalidade { get; set; }
        public string Profissao { get; set; }
        public decimal? RendaMensal { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        // Navigation Properties
        public TipoDocumento TipoDocumento { get; set; }
        public ICollection<Endereco> Enderecos { get; set; }
        public ICollection<ClienteConcessionaria> ClienteConcessionarias { get; set; }
        public ICollection<Simulacao> Simulacoes { get; set; }
        public ICollection<Proposta> Propostas { get; set; }
        public ICollection<Seguro> Seguros { get; set; }
    }
}
