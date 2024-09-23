using Dapper.Contrib.Extensions;

namespace PersistencePoc.Core.Entities
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public int? Ano { get; set; }
        public decimal? Preco { get; set; }
        public string? Categoria { get; set; }
        public int? Estoque { get; set; }
        public bool Ativo { get; set; }

        // Navigation Properties
        public ICollection<Simulacao>? Simulacoes { get; set; }
        public ICollection<Proposta>? Propostas { get; set; }
        public ICollection<Seguro>? Seguros { get; set; }
    }
}
