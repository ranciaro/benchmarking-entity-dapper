namespace PersistencePoc.Infra.EntityFrameworkSix.Migrations
{
    using PersistencePoc.Core.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PersistencePoc.Infra.EntityFrameworkSix.Context.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PersistencePoc.Infra.EntityFrameworkSix.Context.DatabaseContext context)
        {
            var random = new Random();

            for (int i = 0; i < 10000; i++)
            {
                var cep = new Cep
                {
                    Codigo = "12345-678",
                    Logradouro = "Rua Exemplo",
                    Bairro = "Bairro Exemplo",
                    Cidade = "Cidade Exemplo",
                    Estado = "Estado Exemplo",
                    Pais = "Pais Exemplo"
                };

                var endereco = new Endereco
                {
                    TipoEndereco = "Comercial",
                    Numero = random.Next(1000).ToString(),
                    Complemento = "Bloco " + random.Next(1, 10),
                    PontoReferencia = "Ponto " + random.Next(1, 100),
                    DataCriacao = DateTime.Now,
                    Ativo = true,
                    Zona = "Zona " + random.Next(1, 5),
                    TelefoneResidencial = "1111-2222",
                    TelefoneComercial = "3333-4444",
                    Email = $"email{i}@exemplo.com",
                    Cep = cep,
                    DataModificacao = DateTime.Now,
                    DataMudanca = DateTime.Now
                };

                var concessionaria = new Concessionaria
                {
                    Nome = $"Concessionaria {i}",
                    CNPJ = $"00.000.000/000{i}",
                    Telefone = "1234-5678",
                    Endereco = endereco,
                };

                var cliente = new Cliente
                {
                    Nome = $"Cliente {i}",
                    Sobrenome = $"Sobrenome {i}",
                    NumeroDocumento = $"123456789{i}",
                    Email = $"cliente{i}@exemplo.com",
                    Enderecos = new List<Endereco> { endereco },
                    DataNascimento = DateTime.Now,
                    DataEmissao = DateTime.Now,
                    ClienteConcessionarias = new List<ClienteConcessionaria>
            {
                new ClienteConcessionaria
                {
                    DataInicioRelacionamento = DateTime.Now,
                    Concessionaria = concessionaria
                }
            }
                };

                var vendedor = new Vendedor
                {
                    Nome = $"Vendedor {i}",
                    Sobrenome = $"Sobrenome Vendedor {i}",
                    NumeroDocumento = $"VEND123456{i}",
                    Email = $"vendedor{i}@exemplo.com",
                    Concessionaria = concessionaria,
                    DataNascimento = DateTime.Now,
                    DataContratacao = DateTime.Now,
                    TipoDocumento = new TipoDocumento()
                    {
                        DataCriacao = DateTime.Now,
                        DataModificacao = DateTime.Now
                    }
                };

                var produto = new Produto
                {
                    Nome = $"Produto {i}",
                    Marca = "MarcaX",
                    Preco = random.Next(10000, 50000),
                    Categoria = "Categoria " + random.Next(1, 5),
                    Estoque = random.Next(1, 100),
                };

                var simulacao = new Simulacao
                {
                    DataSimulacao = DateTime.Now,
                    ValorVeiculo = random.Next(10000, 50000),
                    Entrada = random.Next(1000, 5000),
                    QuantidadeParcelas = random.Next(12, 48),
                    Cliente = cliente,
                    Produto = produto,
                    Concessionaria = concessionaria,
                    DataCriacao = DateTime.Now,
                    DataModificacao = DateTime.Now,
                    DataPrimeiraParcela = DateTime.Now,
                    DataValidade = DateTime.Now
                };

                var proposta = new Proposta
                {
                    DataProposta = DateTime.Now,
                    ValorProposto = simulacao.ValorVeiculo,
                    ValorEntrada = simulacao.Entrada,
                    QuantidadeParcelas = simulacao.QuantidadeParcelas,
                    Cliente = cliente,
                    Produto = produto,
                    Concessionaria = concessionaria,
                    Vendedor = vendedor,
                    DataPrimeiraParcela = DateTime.Now,
                    DataModificacao = DateTime.Now,
                    DataCriacao = DateTime.Now,
                    DataAnalise = DateTime.Now,
                    DataAprovacao = DateTime.Now,
                    DataConclusao = DateTime.Now,
                    DataEnvioDocumentos = DateTime.Now
                };

                context.Ceps!.Add(cep);
                context.Enderecos!.Add(endereco);
                context.Concessionarias!.Add(concessionaria);
                context.Clientes!.Add(cliente);
                context.Vendedores!.Add(vendedor);
                context.Produtos!.Add(produto);
                context.Simulacoes!.Add(simulacao);
                context.Propostas!.Add(proposta);
                context.SaveChanges();
            }

            
        }



    }
}
