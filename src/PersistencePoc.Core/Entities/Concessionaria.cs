using Dapper.Contrib.Extensions;

namespace PersistencePoc.Core.Entities
{
    public class Concessionaria
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? CNPJ { get; set; }
        public string? Telefone { get; set; }

        // Navigation Properties
        public int? EnderecoId { get; set; }
        public virtual Endereco? Endereco { get; set; }
        public virtual ICollection<Vendedor>? Vendedores { get; set; }
        public virtual ICollection<ClienteConcessionaria>? ClienteConcessionarias { get; set; }
        public virtual ICollection<Simulacao>? Simulacoes { get; set; }
        public virtual ICollection<Proposta>? Propostas { get; set; }
        public virtual ICollection<Seguro>? Seguros { get; set; }
    }

}
