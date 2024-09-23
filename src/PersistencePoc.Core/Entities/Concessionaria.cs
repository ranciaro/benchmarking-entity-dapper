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
        public Endereco? Endereco { get; set; }
        public ICollection<Vendedor>? Vendedores { get; set; }
        public ICollection<ClienteConcessionaria>? ClienteConcessionarias { get; set; }
        public ICollection<Simulacao>? Simulacoes { get; set; }
        public ICollection<Proposta>? Propostas { get; set; }
        public ICollection<Seguro>? Seguros { get; set; }
    }

}
