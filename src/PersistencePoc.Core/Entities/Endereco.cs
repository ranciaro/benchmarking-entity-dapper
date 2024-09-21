namespace PersistencePoc.Core.Entities
{
    public class Endereco
    {
        public int EnderecoID { get; set; }
        public string TipoEndereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string PontoReferencia { get; set; }
        public int ClienteID { get; set; }
        public int CepID { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataModificacao { get; set; }
        public string Observacoes { get; set; }
        public bool Ativo { get; set; }
        public string TipoResidencia { get; set; }
        public DateTime? DataMudanca { get; set; }
        public bool? Propriedade { get; set; }
        public string Zona { get; set; }
        public string TelefoneResidencial { get; set; }
        public string TelefoneComercial { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public bool? EnderecoCorrespondencia { get; set; }

        // Navigation Properties
        public Cliente Cliente { get; set; }
        public Cep Cep { get; set; }
    }
}
