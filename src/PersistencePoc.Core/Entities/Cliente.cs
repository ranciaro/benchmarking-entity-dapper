namespace PersistencePoc.Core.Entities
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? RG { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Endereco { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? CEP { get; set; }
        public string? Telefone { get; set; }
        public string? Celular { get; set; }
        public string? Email { get; set; }
        public string? EstadoCivil { get; set; }
        public string? Profissao { get; set; }
        public decimal RendaMensal { get; set; }

        // Coleção de Simulacoes
        public ICollection<Simulacao>? Simulacoes { get; set; }
    }
}
