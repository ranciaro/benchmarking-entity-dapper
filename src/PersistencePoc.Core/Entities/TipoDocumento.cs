using Dapper.Contrib.Extensions;

namespace PersistencePoc.Core.Entities
{
    public class TipoDocumento
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataModificacao { get; set; }
        public string? Codigo { get; set; }
        public int? Validade { get; set; }
        public string? Emissor { get; set; }
        public string? PaisEmissor { get; set; }

        // Navigation Properties
        public virtual ICollection<Cliente>? Clientes { get; set; }
        public virtual ICollection<Vendedor>? Vendedores { get; set; }
    }
}
