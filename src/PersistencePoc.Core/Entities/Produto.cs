using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistencePoc.Core.Entities
{
    public class Produto
    {
        public int ProdutoID { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public int Ano { get; set; }
        public string? Cor { get; set; }
        public decimal Preco { get; set; }
        public string? Chassi { get; set; }
        public string? Placa { get; set; }
        public string? TipoVeiculo { get; set; }
        public string? Combustivel { get; set; }

        // Coleção de Simulacoes
        public ICollection<Simulacao>? Simulacoes { get; set; }
    }
}
