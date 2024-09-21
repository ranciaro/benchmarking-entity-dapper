namespace PersistencePoc.Core.Entities
{
    public class Cep
    {
        public int CepID { get; set; }
        public string Codigo { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Complemento { get; set; }

        // Navigation Properties
        public ICollection<Endereco> Enderecos { get; set; }
    }

}
