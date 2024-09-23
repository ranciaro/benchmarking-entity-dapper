using Dapper.Contrib.Extensions;

namespace PersistencePoc.Core.Entities
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }
        public string? TipoEndereco { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? PontoReferencia { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataModificacao { get; set; }
        public string? Observacoes { get; set; }
        public bool Ativo { get; set; }
        public string? TipoResidencia { get; set; }
        public DateTime? DataMudanca { get; set; }
        public bool? Propriedade { get; set; }
        public string? Zona { get; set; }
        public string? TelefoneResidencial { get; set; }
        public string? TelefoneComercial { get; set; }
        public string? Fax { get; set; }
        public string? Email { get; set; }
        public bool? EnderecoCorrespondencia { get; set; }

        // Navigation Properties
        public int? ClienteId { get; set; }
        public virtual Cliente? Cliente { get; set; }
        public int? CepId { get; set; }
        public virtual Cep? Cep { get; set; }
        public virtual ICollection<Concessionaria>? Concessionarias { get; set; }
    }
}
