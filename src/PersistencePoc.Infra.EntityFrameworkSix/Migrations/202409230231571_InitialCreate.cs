namespace PersistencePoc.Infra.EntityFrameworkSix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cep",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(),
                        Logradouro = c.String(),
                        Bairro = c.String(),
                        Cidade = c.String(),
                        Estado = c.String(),
                        Pais = c.String(),
                        Latitude = c.Double(),
                        Longitude = c.Double(),
                        Complemento = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TipoEndereco = c.String(),
                        Numero = c.String(),
                        Complemento = c.String(),
                        PontoReferencia = c.String(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataModificacao = c.DateTime(),
                        Observacoes = c.String(),
                        Ativo = c.Boolean(nullable: false),
                        TipoResidencia = c.String(),
                        DataMudanca = c.DateTime(),
                        Propriedade = c.Boolean(),
                        Zona = c.String(),
                        TelefoneResidencial = c.String(),
                        TelefoneComercial = c.String(),
                        Fax = c.String(),
                        Email = c.String(),
                        EnderecoCorrespondencia = c.Boolean(),
                        ClienteId = c.Int(nullable: false),
                        CepId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cep", t => t.CepId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .Index(t => t.ClienteId)
                .Index(t => t.CepId);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Sobrenome = c.String(),
                        DataNascimento = c.DateTime(),
                        NumeroDocumento = c.String(),
                        OrgaoEmissor = c.String(),
                        DataEmissao = c.DateTime(),
                        EstadoCivil = c.String(),
                        Nacionalidade = c.String(),
                        Profissao = c.String(),
                        RendaMensal = c.Decimal(precision: 18, scale: 2),
                        Telefone = c.String(),
                        Email = c.String(),
                        TipoDocumentoId = c.Int(),
                        TipoDocumento_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoDocumento", t => t.TipoDocumento_Id)
                .ForeignKey("dbo.TipoDocumento", t => t.TipoDocumentoId)
                .Index(t => t.TipoDocumentoId)
                .Index(t => t.TipoDocumento_Id);
            
            CreateTable(
                "dbo.ClienteConcessionaria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataInicioRelacionamento = c.DateTime(),
                        DataFimRelacionamento = c.DateTime(),
                        Observacoes = c.String(),
                        ClienteId = c.Int(nullable: false),
                        ConcessionariaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .ForeignKey("dbo.Concessionaria", t => t.ConcessionariaId)
                .Index(t => t.ClienteId)
                .Index(t => t.ConcessionariaId);
            
            CreateTable(
                "dbo.Concessionaria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        CNPJ = c.String(),
                        Telefone = c.String(),
                        EnderecoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Endereco", t => t.EnderecoId)
                .Index(t => t.EnderecoId);
            
            CreateTable(
                "dbo.Proposta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataProposta = c.DateTime(nullable: false),
                        ValorProposto = c.Decimal(precision: 18, scale: 2),
                        ValorEntrada = c.Decimal(precision: 18, scale: 2),
                        QuantidadeParcelas = c.Int(),
                        ValorParcela = c.Decimal(precision: 18, scale: 2),
                        TaxaJuros = c.Decimal(precision: 18, scale: 2),
                        TotalFinanciado = c.Decimal(precision: 18, scale: 2),
                        TotalPagar = c.Decimal(precision: 18, scale: 2),
                        DataPrimeiraParcela = c.DateTime(),
                        Status = c.String(),
                        Aprovado = c.Boolean(),
                        DataAprovacao = c.DateTime(),
                        Observacoes = c.String(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataModificacao = c.DateTime(),
                        DocumentosEnviados = c.Boolean(),
                        DataEnvioDocumentos = c.DateTime(),
                        DataAnalise = c.DateTime(),
                        DataConclusao = c.DateTime(),
                        MotivoRecusa = c.String(),
                        TipoFinanciamento = c.String(),
                        BancoFinanciador = c.String(),
                        IOF = c.Decimal(precision: 18, scale: 2),
                        CET = c.Decimal(precision: 18, scale: 2),
                        Descontos = c.Decimal(precision: 18, scale: 2),
                        TaxasAdicionais = c.Decimal(precision: 18, scale: 2),
                        SeguroIncluso = c.Boolean(),
                        ValorSeguro = c.Decimal(precision: 18, scale: 2),
                        ObservacoesInternas = c.String(),
                        ScoreCredito = c.Int(),
                        Garantias = c.String(),
                        ContratoGerado = c.Boolean(),
                        SimulacaoId = c.Int(),
                        ClienteId = c.Int(nullable: false),
                        ProdutoId = c.Int(nullable: false),
                        ConcessionariaId = c.Int(nullable: false),
                        SeguroId = c.Int(),
                        VendedorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .ForeignKey("dbo.Concessionaria", t => t.ConcessionariaId)
                .ForeignKey("dbo.Simulacao", t => t.SimulacaoId)
                .ForeignKey("dbo.Produto", t => t.ProdutoId)
                .ForeignKey("dbo.Seguro", t => t.SeguroId)
                .ForeignKey("dbo.Vendedor", t => t.VendedorId)
                .Index(t => t.SimulacaoId)
                .Index(t => t.ClienteId)
                .Index(t => t.ProdutoId)
                .Index(t => t.ConcessionariaId)
                .Index(t => t.SeguroId)
                .Index(t => t.VendedorId);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        Marca = c.String(),
                        Modelo = c.String(),
                        Ano = c.Int(),
                        Preco = c.Decimal(precision: 18, scale: 2),
                        Categoria = c.String(),
                        Estoque = c.Int(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Seguro",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        ValorPremio = c.Decimal(precision: 18, scale: 2),
                        Franquia = c.Decimal(precision: 18, scale: 2),
                        Cobertura = c.String(),
                        TipoSeguro = c.String(),
                        Seguradora = c.String(),
                        DataInicioVigencia = c.DateTime(),
                        DataFimVigencia = c.DateTime(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataModificacao = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                        ApoliceNumero = c.String(),
                        FormaPagamento = c.String(),
                        Parcelas = c.Int(),
                        ValorParcela = c.Decimal(precision: 18, scale: 2),
                        Observacoes = c.String(),
                        TipoCobertura = c.String(),
                        Assistencia24h = c.Boolean(),
                        CarroReserva = c.Boolean(),
                        ProtecaoVidros = c.Boolean(),
                        DanosTerceiros = c.Boolean(),
                        MorteAcidental = c.Boolean(),
                        InvalidezPermanente = c.Boolean(),
                        AssistenciaFuneral = c.Boolean(),
                        ClienteId = c.Int(nullable: false),
                        ProdutoId = c.Int(nullable: false),
                        VendedorId = c.Int(),
                        ConcessionariaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .ForeignKey("dbo.Concessionaria", t => t.ConcessionariaId)
                .ForeignKey("dbo.Produto", t => t.ProdutoId)
                .ForeignKey("dbo.Vendedor", t => t.VendedorId)
                .Index(t => t.ClienteId)
                .Index(t => t.ProdutoId)
                .Index(t => t.VendedorId)
                .Index(t => t.ConcessionariaId);
            
            CreateTable(
                "dbo.Simulacao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataSimulacao = c.DateTime(nullable: false),
                        ValorVeiculo = c.Decimal(precision: 18, scale: 2),
                        Entrada = c.Decimal(precision: 18, scale: 2),
                        QuantidadeParcelas = c.Int(),
                        ValorParcela = c.Decimal(precision: 18, scale: 2),
                        TaxaJuros = c.Decimal(precision: 18, scale: 2),
                        SistemaAmortizacao = c.String(),
                        TotalFinanciado = c.Decimal(precision: 18, scale: 2),
                        TotalPagar = c.Decimal(precision: 18, scale: 2),
                        DataPrimeiraParcela = c.DateTime(),
                        Observacoes = c.String(),
                        Status = c.String(),
                        SeguroIncluso = c.Boolean(),
                        ValorSeguro = c.Decimal(precision: 18, scale: 2),
                        Descontos = c.Decimal(precision: 18, scale: 2),
                        TaxasAdicionais = c.Decimal(precision: 18, scale: 2),
                        IOF = c.Decimal(precision: 18, scale: 2),
                        CET = c.Decimal(precision: 18, scale: 2),
                        DataValidade = c.DateTime(),
                        UsuarioID = c.Int(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataModificacao = c.DateTime(),
                        TipoFinanciamento = c.String(),
                        BancoFinanciador = c.String(),
                        Aprovado = c.Boolean(),
                        ClienteId = c.Int(nullable: false),
                        VendedorId = c.Int(),
                        ConcessionariaId = c.Int(nullable: false),
                        ProdutoId = c.Int(nullable: false),
                        SeguroId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .ForeignKey("dbo.Concessionaria", t => t.ConcessionariaId)
                .ForeignKey("dbo.Produto", t => t.ProdutoId)
                .ForeignKey("dbo.Seguro", t => t.SeguroId)
                .ForeignKey("dbo.Vendedor", t => t.VendedorId)
                .Index(t => t.ClienteId)
                .Index(t => t.VendedorId)
                .Index(t => t.ConcessionariaId)
                .Index(t => t.ProdutoId)
                .Index(t => t.SeguroId);
            
            CreateTable(
                "dbo.Vendedor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Sobrenome = c.String(),
                        NumeroDocumento = c.String(),
                        DataNascimento = c.DateTime(),
                        Telefone = c.String(),
                        Email = c.String(),
                        DataContratacao = c.DateTime(),
                        Salario = c.Decimal(precision: 18, scale: 2),
                        PercentualComissao = c.Decimal(precision: 18, scale: 2),
                        Ativo = c.Boolean(nullable: false),
                        Observacoes = c.String(),
                        TipoDocumentoId = c.Int(nullable: false),
                        EnderecoId = c.Int(),
                        ConcessionariaId = c.Int(nullable: false),
                        TipoDocumento_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Concessionaria", t => t.ConcessionariaId)
                .ForeignKey("dbo.Endereco", t => t.EnderecoId)
                .ForeignKey("dbo.TipoDocumento", t => t.TipoDocumento_Id)
                .ForeignKey("dbo.TipoDocumento", t => t.TipoDocumentoId)
                .Index(t => t.TipoDocumentoId)
                .Index(t => t.EnderecoId)
                .Index(t => t.ConcessionariaId)
                .Index(t => t.TipoDocumento_Id);
            
            CreateTable(
                "dbo.TipoDocumento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        Ativo = c.Boolean(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataModificacao = c.DateTime(),
                        Codigo = c.String(),
                        Validade = c.Int(),
                        Emissor = c.String(),
                        PaisEmissor = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Endereco", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Cliente", "TipoDocumentoId", "dbo.TipoDocumento");
            DropForeignKey("dbo.ClienteConcessionaria", "ConcessionariaId", "dbo.Concessionaria");
            DropForeignKey("dbo.Proposta", "VendedorId", "dbo.Vendedor");
            DropForeignKey("dbo.Proposta", "SeguroId", "dbo.Seguro");
            DropForeignKey("dbo.Proposta", "ProdutoId", "dbo.Produto");
            DropForeignKey("dbo.Vendedor", "TipoDocumentoId", "dbo.TipoDocumento");
            DropForeignKey("dbo.Vendedor", "TipoDocumento_Id", "dbo.TipoDocumento");
            DropForeignKey("dbo.Cliente", "TipoDocumento_Id", "dbo.TipoDocumento");
            DropForeignKey("dbo.Simulacao", "VendedorId", "dbo.Vendedor");
            DropForeignKey("dbo.Seguro", "VendedorId", "dbo.Vendedor");
            DropForeignKey("dbo.Vendedor", "EnderecoId", "dbo.Endereco");
            DropForeignKey("dbo.Vendedor", "ConcessionariaId", "dbo.Concessionaria");
            DropForeignKey("dbo.Simulacao", "SeguroId", "dbo.Seguro");
            DropForeignKey("dbo.Proposta", "SimulacaoId", "dbo.Simulacao");
            DropForeignKey("dbo.Simulacao", "ProdutoId", "dbo.Produto");
            DropForeignKey("dbo.Simulacao", "ConcessionariaId", "dbo.Concessionaria");
            DropForeignKey("dbo.Simulacao", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Seguro", "ProdutoId", "dbo.Produto");
            DropForeignKey("dbo.Seguro", "ConcessionariaId", "dbo.Concessionaria");
            DropForeignKey("dbo.Seguro", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Proposta", "ConcessionariaId", "dbo.Concessionaria");
            DropForeignKey("dbo.Proposta", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Concessionaria", "EnderecoId", "dbo.Endereco");
            DropForeignKey("dbo.ClienteConcessionaria", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Endereco", "CepId", "dbo.Cep");
            DropIndex("dbo.Vendedor", new[] { "TipoDocumento_Id" });
            DropIndex("dbo.Vendedor", new[] { "ConcessionariaId" });
            DropIndex("dbo.Vendedor", new[] { "EnderecoId" });
            DropIndex("dbo.Vendedor", new[] { "TipoDocumentoId" });
            DropIndex("dbo.Simulacao", new[] { "SeguroId" });
            DropIndex("dbo.Simulacao", new[] { "ProdutoId" });
            DropIndex("dbo.Simulacao", new[] { "ConcessionariaId" });
            DropIndex("dbo.Simulacao", new[] { "VendedorId" });
            DropIndex("dbo.Simulacao", new[] { "ClienteId" });
            DropIndex("dbo.Seguro", new[] { "ConcessionariaId" });
            DropIndex("dbo.Seguro", new[] { "VendedorId" });
            DropIndex("dbo.Seguro", new[] { "ProdutoId" });
            DropIndex("dbo.Seguro", new[] { "ClienteId" });
            DropIndex("dbo.Proposta", new[] { "VendedorId" });
            DropIndex("dbo.Proposta", new[] { "SeguroId" });
            DropIndex("dbo.Proposta", new[] { "ConcessionariaId" });
            DropIndex("dbo.Proposta", new[] { "ProdutoId" });
            DropIndex("dbo.Proposta", new[] { "ClienteId" });
            DropIndex("dbo.Proposta", new[] { "SimulacaoId" });
            DropIndex("dbo.Concessionaria", new[] { "EnderecoId" });
            DropIndex("dbo.ClienteConcessionaria", new[] { "ConcessionariaId" });
            DropIndex("dbo.ClienteConcessionaria", new[] { "ClienteId" });
            DropIndex("dbo.Cliente", new[] { "TipoDocumento_Id" });
            DropIndex("dbo.Cliente", new[] { "TipoDocumentoId" });
            DropIndex("dbo.Endereco", new[] { "CepId" });
            DropIndex("dbo.Endereco", new[] { "ClienteId" });
            DropTable("dbo.TipoDocumento");
            DropTable("dbo.Vendedor");
            DropTable("dbo.Simulacao");
            DropTable("dbo.Seguro");
            DropTable("dbo.Produto");
            DropTable("dbo.Proposta");
            DropTable("dbo.Concessionaria");
            DropTable("dbo.ClienteConcessionaria");
            DropTable("dbo.Cliente");
            DropTable("dbo.Endereco");
            DropTable("dbo.Cep");
        }
    }
}
