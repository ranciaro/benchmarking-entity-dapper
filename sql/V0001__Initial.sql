-- Table: TipoDocumento
CREATE TABLE TipoDocumento (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Descricao VARCHAR(255),
    Ativo BIT NOT NULL DEFAULT 1,
    DataCriacao DATETIME NOT NULL DEFAULT GETDATE(),
    DataModificacao DATETIME,
    Codigo VARCHAR(50),
    Validade INT, -- in years
    Emissor VARCHAR(100),
    PaisEmissor VARCHAR(100)
);

-- Table: Cep
CREATE TABLE Cep (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(20) NOT NULL,
    Logradouro VARCHAR(255),
    Bairro VARCHAR(100),
    Cidade VARCHAR(100),
    Estado VARCHAR(50),
    Pais VARCHAR(100),
    Latitude FLOAT,
    Longitude FLOAT,
    Complemento VARCHAR(255)
);

-- Table: Cliente
CREATE TABLE Cliente (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Sobrenome VARCHAR(100),
    DataNascimento DATETIME,
    Sexo CHAR(1),
    TipoDocumentoID INT NOT NULL,
    NumeroDocumento VARCHAR(50) NOT NULL,
    OrgaoEmissor VARCHAR(100),
    DataEmissao DATETIME,
    EstadoCivil VARCHAR(50),
    Nacionalidade VARCHAR(100),
    Profissao VARCHAR(100),
    RendaMensal DECIMAL(18,2),
    Telefone VARCHAR(20),
    Email VARCHAR(100),
    FOREIGN KEY (TipoDocumentoID) REFERENCES TipoDocumento(Id)
);

-- Table: Endereco
CREATE TABLE Endereco (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TipoEndereco VARCHAR(50),
    Numero VARCHAR(20),
    Complemento VARCHAR(100),
    PontoReferencia VARCHAR(255),
    ClienteID INT NOT NULL,
    CepID INT NOT NULL,
    DataCriacao DATETIME NOT NULL DEFAULT GETDATE(),
    DataModificacao DATETIME,
    Observacoes VARCHAR(255),
    Ativo BIT NOT NULL DEFAULT 1,
    TipoResidencia VARCHAR(50),
    DataMudanca DATETIME,
    Propriedade BIT,
    Zona VARCHAR(50),
    TelefoneResidencial VARCHAR(20),
    TelefoneComercial VARCHAR(20),
    Fax VARCHAR(20),
    Email VARCHAR(100),
    EnderecoCorrespondencia BIT,
    FOREIGN KEY (ClienteID) REFERENCES Cliente(Id),
    FOREIGN KEY (CepID) REFERENCES Cep(Id)
);

-- Table: Concessionaria
CREATE TABLE Concessionaria (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    CNPJ VARCHAR(20),
    Telefone VARCHAR(20),
    EnderecoID INT,
    FOREIGN KEY (EnderecoID) REFERENCES Endereco(Id)
);

-- Table: ClienteConcessionaria (many-to-many between Cliente and Concessionaria)
CREATE TABLE ClienteConcessionaria (
    ClienteID INT NOT NULL,
    ConcessionariaID INT NOT NULL,
    DataInicioRelacionamento DATETIME,
    DataFimRelacionamento DATETIME,
    Observacoes VARCHAR(255),
    PRIMARY KEY (ClienteID, ConcessionariaID),
    FOREIGN KEY (ClienteID) REFERENCES Cliente(Id),
    FOREIGN KEY (ConcessionariaID) REFERENCES Concessionaria(Id)
);

-- Table: Vendedor
CREATE TABLE Vendedor (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Sobrenome VARCHAR(100),
    TipoDocumentoID INT NOT NULL,
    NumeroDocumento VARCHAR(50) NOT NULL,
    DataNascimento DATETIME,
    Telefone VARCHAR(20),
    Email VARCHAR(100),
    EnderecoID INT,
    DataContratacao DATETIME,
    Salario DECIMAL(18,2),
    PercentualComissao DECIMAL(5,2),
    ConcessionariaID INT NOT NULL,
    Ativo BIT NOT NULL DEFAULT 1,
    Observacoes VARCHAR(255),
    FOREIGN KEY (TipoDocumentoID) REFERENCES TipoDocumento(Id),
    FOREIGN KEY (EnderecoID) REFERENCES Endereco(Id),
    FOREIGN KEY (ConcessionariaID) REFERENCES Concessionaria(Id)
);

-- Table: Produtos
CREATE TABLE Produtos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Descricao VARCHAR(255),
    Marca VARCHAR(100),
    Modelo VARCHAR(100),
    Ano INT,
    Preco DECIMAL(18,2),
    Categoria VARCHAR(100),
    Estoque INT,
    Ativo BIT NOT NULL DEFAULT 1
);

-- Table: Seguros
CREATE TABLE Seguros (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Descricao VARCHAR(255),
    ValorPremio DECIMAL(18,2),
    Franquia DECIMAL(18,2),
    Cobertura VARCHAR(255),
    TipoSeguro VARCHAR(100),
    Seguradora VARCHAR(100),
    DataInicioVigencia DATETIME,
    DataFimVigencia DATETIME,
    DataCriacao DATETIME NOT NULL DEFAULT GETDATE(),
    DataModificacao DATETIME,
    Ativo BIT NOT NULL DEFAULT 1,
    ApoliceNumero VARCHAR(50),
    ClienteID INT,
    ProdutoID INT,
    VendedorID INT,
    ConcessionariaID INT,
    FormaPagamento VARCHAR(50),
    Parcelas INT,
    ValorParcela DECIMAL(18,2),
    Observacoes VARCHAR(255),
    TipoCobertura VARCHAR(100),
    Assistencia24h BIT,
    CarroReserva BIT,
    ProtecaoVidros BIT,
    DanosTerceiros BIT,
    MorteAcidental BIT,
    InvalidezPermanente BIT,
    AssistenciaFuneral BIT,
    FOREIGN KEY (ClienteID) REFERENCES Cliente(Id),
    FOREIGN KEY (ProdutoID) REFERENCES Produtos(Id),
    FOREIGN KEY (VendedorID) REFERENCES Vendedor(Id),
    FOREIGN KEY (ConcessionariaID) REFERENCES Concessionaria(Id)
);

-- Table: Simulacao
CREATE TABLE Simulacao (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    DataSimulacao DATETIME NOT NULL DEFAULT GETDATE(),
    ClienteID INT NOT NULL,
    VendedorID INT NOT NULL,
    ConcessionariaID INT NOT NULL,
    ProdutoID INT NOT NULL,
    SeguroID INT,
    ValorVeiculo DECIMAL(18,2),
    Entrada DECIMAL(18,2),
    QuantidadeParcelas INT,
    ValorParcela DECIMAL(18,2),
    TaxaJuros DECIMAL(5,2),
    SistemaAmortizacao VARCHAR(50),
    TotalFinanciado DECIMAL(18,2),
    TotalPagar DECIMAL(18,2),
    DataPrimeiraParcela DATETIME,
    Observacoes VARCHAR(255),
    Status VARCHAR(50),
    SeguroIncluso BIT,
    ValorSeguro DECIMAL(18,2),
    Descontos DECIMAL(18,2),
    TaxasAdicionais DECIMAL(18,2),
    IOF DECIMAL(18,2),
    CET DECIMAL(5,2),
    DataValidade DATETIME,
    UsuarioID INT,
    DataCriacao DATETIME NOT NULL DEFAULT GETDATE(),
    DataModificacao DATETIME,
    TipoFinanciamento VARCHAR(50),
    BancoFinanciador VARCHAR(100),
    Aprovado BIT,
    FOREIGN KEY (ClienteID) REFERENCES Cliente(Id),
    FOREIGN KEY (VendedorID) REFERENCES Vendedor(Id),
    FOREIGN KEY (ConcessionariaID) REFERENCES Concessionaria(Id),
    FOREIGN KEY (ProdutoID) REFERENCES Produtos(Id),
    FOREIGN KEY (SeguroID) REFERENCES Seguros(Id)
);

-- Table: Propostas
CREATE TABLE Propostas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    SimulacaoID INT NOT NULL,
    ClienteID INT NOT NULL,
    ProdutoID INT NOT NULL,
    ConcessionariaID INT NOT NULL,
    DataProposta DATETIME NOT NULL DEFAULT GETDATE(),
    ValorProposto DECIMAL(18,2),
    ValorEntrada DECIMAL(18,2),
    QuantidadeParcelas INT,
    ValorParcela DECIMAL(18,2),
    TaxaJuros DECIMAL(5,2),
    TotalFinanciado DECIMAL(18,2),
    TotalPagar DECIMAL(18,2),
    DataPrimeiraParcela DATETIME,
    Status VARCHAR(50),
    Aprovado BIT,
    DataAprovacao DATETIME,
    UsuarioID INT,
    Observacoes VARCHAR(255),
    DataCriacao DATETIME NOT NULL DEFAULT GETDATE(),
    DataModificacao DATETIME,
    SeguroID INT,
    VendedorID INT,
    DocumentosEnviados BIT,
    DataEnvioDocumentos DATETIME,
    DataAnalise DATETIME,
    DataConclusao DATETIME,
    MotivoRecusa VARCHAR(255),
    TipoFinanciamento VARCHAR(50),
    BancoFinanciador VARCHAR(100),
    IOF DECIMAL(18,2),
    CET DECIMAL(5,2),
    Descontos DECIMAL(18,2),
    TaxasAdicionais DECIMAL(18,2),
    SeguroIncluso BIT,
    ValorSeguro DECIMAL(18,2),
    UsuarioAprovacaoID INT,
    ObservacoesInternas VARCHAR(255),
    ScoreCredito INT,
    Garantias VARCHAR(255),
    ContratoGerado BIT,
    FOREIGN KEY (SimulacaoID) REFERENCES Simulacao(Id),
    FOREIGN KEY (ClienteID) REFERENCES Cliente(Id),
    FOREIGN KEY (ProdutoID) REFERENCES Produtos(Id),
    FOREIGN KEY (ConcessionariaID) REFERENCES Concessionaria(Id),
    FOREIGN KEY (SeguroID) REFERENCES Seguros(Id),
    FOREIGN KEY (VendedorID) REFERENCES Vendedor(Id)
);
