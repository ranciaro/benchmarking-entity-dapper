namespace PersistencePoc.Core.Entities
{
    public class TipoDocumento
    {
        public int TipoDocumentoID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataModificacao { get; set; }
        public string Codigo { get; set; }
        public int? Validade { get; set; } // in years
        public string Emissor { get; set; }
        public string PaisEmissor { get; set; }

        // Navigation Properties
        public ICollection<Cliente> Clientes { get; set; }
        public ICollection<Vendedor> Vendedores { get; set; }
    }
}
