namespace PersistencePoc.Core.Entities
{
    public class ClienteConcessionaria
    {
        public int ClienteID { get; set; }
        public int ConcessionariaID { get; set; }
        public DateTime? DataInicioRelacionamento { get; set; }
        public DateTime? DataFimRelacionamento { get; set; }
        public string Observacoes { get; set; }

        // Navigation Properties
        public Cliente Cliente { get; set; }
        public Concessionaria Concessionaria { get; set; }
    }
}
