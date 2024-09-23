using Dapper.Contrib.Extensions;

namespace PersistencePoc.Core.Entities
{
    public class ClienteConcessionaria
    {
        [Key]
        public int Id { get; set; }
        public DateTime? DataInicioRelacionamento { get; set; }
        public DateTime? DataFimRelacionamento { get; set; }
        public string? Observacoes { get; set; }

        // Navigation Properties
        public int? ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        public int? ConcessionariaId { get; set; }
        public Concessionaria? Concessionaria { get; set; }
    }
}
