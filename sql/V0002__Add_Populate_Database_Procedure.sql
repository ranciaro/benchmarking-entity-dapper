-- Stored Procedure para Popular o Banco de Dados com Dados Aleatórios
CREATE PROCEDURE PopulateDatabase
    @NumClientes INT,
    @NumConcessionarias INT,
    @NumVendedores INT,
    @NumProdutos INT,
    @NumSeguros INT,
    @NumSimulacoes INT,
    @NumPropostas INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Declaração de variáveis
    DECLARE @i INT;
    DECLARE @TotalClientes INT;
    DECLARE @TipoDocumentoID INT;
    DECLARE @ClienteID INT;
    DECLARE @ConcessionariaID INT;
    DECLARE @CepID INT;
    DECLARE @ProdutoID INT;
    DECLARE @VendedorID INT;
    DECLARE @SeguroID INT;
    DECLARE @SimulacaoID INT;
    DECLARE @SimulacaoClienteID INT;
    DECLARE @SimulacaoProdutoID INT;
    DECLARE @SimulacaoConcessionariaID INT;
    DECLARE @SimulacaoSeguroID INT;
    DECLARE @SimulacaoVendedorID INT;

    -- 1. Populando TipoDocumento
    IF NOT EXISTS (SELECT 1 FROM TipoDocumento)
    BEGIN
        INSERT INTO TipoDocumento (Nome, Descricao, Ativo, Codigo, Validade, Emissor, PaisEmissor)
        VALUES 
            ('CPF', 'Cadastro de Pessoa Física', 1, 'CPF', NULL, 'Receita Federal', 'Brasil'),
            ('CNH', 'Carteira Nacional de Habilitação', 1, 'CNH', 5, 'DETRAN', 'Brasil'),
            ('RG', 'Registro Geral', 1, 'RG', NULL, 'SSP', 'Brasil'),
            ('Passaporte', 'Passaporte', 1, 'PASS', 10, 'Polícia Federal', 'Brasil');
    END

    -- 2. Populando Cep
    SET @i = 1;
    WHILE @i <= 1000 -- Assumindo 1000 CEPs
    BEGIN
        INSERT INTO Cep (Codigo, Logradouro, Bairro, Cidade, Estado, Pais)
        VALUES (
            RIGHT('00000' + CAST(ABS(CHECKSUM(NEWID())) % 99999 AS VARCHAR(5)),5) + '-' + RIGHT('000' + CAST(ABS(CHECKSUM(NEWID())) % 999 AS VARCHAR(3)),3),
            'Rua ' + CAST(@i AS VARCHAR(10)),
            'Bairro ' + CAST(@i AS VARCHAR(10)),
            'Cidade ' + CAST(@i AS VARCHAR(10)),
            'Estado ' + CHAR(65 + ABS(CHECKSUM(NEWID())) % 26),
            'Brasil'
        );
        SET @i = @i + 1;
    END

    -- 3. Populando Clientes
    SET @i = 1;
    WHILE @i <= @NumClientes
    BEGIN
        SET @TipoDocumentoID = (SELECT TOP 1 Id FROM TipoDocumento ORDER BY NEWID());
        INSERT INTO Cliente (Nome, Sobrenome, DataNascimento, Sexo, TipoDocumentoID, NumeroDocumento, EstadoCivil, Telefone, Email)
        VALUES (
            'ClienteNome' + CAST(@i AS VARCHAR(10)),
            'Sobrenome' + CAST(@i AS VARCHAR(10)),
            DATEADD(YEAR, - (18 + ABS(CHECKSUM(NEWID())) % 50), GETDATE()),
            CASE WHEN ABS(CHECKSUM(NEWID())) % 2 = 0 THEN 'M' ELSE 'F' END,
            @TipoDocumentoID,
            RIGHT('0000000000' + CAST(ABS(CHECKSUM(NEWID())) % 10000000000 AS VARCHAR(10)),10),
            'Solteiro(a)',
            '(11) 9' + RIGHT('00000000' + CAST(ABS(CHECKSUM(NEWID())) % 100000000 AS VARCHAR(8)),8),
            'cliente' + CAST(@i AS VARCHAR(10)) + '@exemplo.com'
        );
        SET @i = @i + 1;
    END

    -- 4. Populando Endereços
    SET @i = 1;
    SET @TotalClientes = (SELECT COUNT(*) FROM Cliente);
    WHILE @i <= @TotalClientes * 2 -- Assumindo 2 endereços por cliente
    BEGIN
        SET @ClienteID = ((@i - 1) % @TotalClientes) + 1;
        SET @CepID = (SELECT TOP 1 Id FROM Cep ORDER BY NEWID());
        INSERT INTO Endereco (TipoEndereco, Numero, ClienteID, CepID, Ativo)
        VALUES (
            CASE WHEN ABS(CHECKSUM(NEWID())) % 2 = 0 THEN 'Residencial' ELSE 'Comercial' END,
            CAST(ABS(CHECKSUM(NEWID())) % 9999 + 1 AS VARCHAR(5)),
            @ClienteID,
            @CepID,
            1
        );
        SET @i = @i + 1;
    END

    -- 5. Populando Concessionárias
    SET @i = 1;
    WHILE @i <= @NumConcessionarias
    BEGIN
        INSERT INTO Concessionaria (Nome, CNPJ, Telefone)
        VALUES (
            'Concessionária ' + CAST(@i AS VARCHAR(10)),
            RIGHT('00000000000000' + CAST(ABS(CHECKSUM(NEWID())) % 100000000000000 AS VARCHAR(14)),14),
            '(11) ' + RIGHT('0000' + CAST(ABS(CHECKSUM(NEWID())) % 10000 AS VARCHAR(4)),4) + '-' + RIGHT('0000' + CAST(ABS(CHECKSUM(NEWID())) % 10000 AS VARCHAR(4)),4)
        );
        SET @i = @i + 1;
    END

    -- 6. Populando ClienteConcessionaria
    SET @i = 1;
    WHILE @i <= @TotalClientes
    BEGIN
        SET @ClienteID = @i;
        SET @ConcessionariaID = ABS(CHECKSUM(NEWID())) % @NumConcessionarias + 1;
        INSERT INTO ClienteConcessionaria (ClienteID, ConcessionariaID, DataInicioRelacionamento)
        VALUES (@ClienteID, @ConcessionariaID, GETDATE());
        SET @i = @i + 1;
    END

    -- 7. Populando Vendedores
    SET @i = 1;
    WHILE @i <= @NumVendedores
    BEGIN
        SET @ConcessionariaID = ABS(CHECKSUM(NEWID())) % @NumConcessionarias + 1;
        SET @TipoDocumentoID = (SELECT TOP 1 Id FROM TipoDocumento ORDER BY NEWID());
        INSERT INTO Vendedor (Nome, Sobrenome, TipoDocumentoID, NumeroDocumento, ConcessionariaID, PercentualComissao, Ativo)
        VALUES (
            'VendedorNome' + CAST(@i AS VARCHAR(10)),
            'Sobrenome' + CAST(@i AS VARCHAR(10)),
            @TipoDocumentoID,
            RIGHT('0000000000' + CAST(ABS(CHECKSUM(NEWID())) % 10000000000 AS VARCHAR(10)),10),
            @ConcessionariaID,
            CAST(ABS(CHECKSUM(NEWID())) % 15 + 1 AS DECIMAL(5,2)),
            1
        );
        SET @i = @i + 1;
    END

    -- 8. Populando Produtos
    SET @i = 1;
    WHILE @i <= @NumProdutos
    BEGIN
        INSERT INTO Produtos (Nome, Descricao, Marca, Modelo, Ano, Preco, Categoria, Estoque, Ativo)
        VALUES (
            'Produto ' + CAST(@i AS VARCHAR(10)),
            'Descrição do produto ' + CAST(@i AS VARCHAR(10)),
            'Marca ' + CAST(ABS(CHECKSUM(NEWID())) % 100 AS VARCHAR(3)),
            'Modelo ' + CAST(ABS(CHECKSUM(NEWID())) % 100 AS VARCHAR(3)),
            2000 + ABS(CHECKSUM(NEWID())) % 23,
            CAST(ABS(CHECKSUM(NEWID())) % 90000 + 10000 AS DECIMAL(18,2)),
            'Categoria ' + CAST(ABS(CHECKSUM(NEWID())) % 10 AS VARCHAR(2)),
            ABS(CHECKSUM(NEWID())) % 100 + 1,
            1
        );
        SET @i = @i + 1;
    END

    -- 9. Populando Seguros
    SET @i = 1;
    WHILE @i <= @NumSeguros
    BEGIN
        SET @ClienteID = ABS(CHECKSUM(NEWID())) % @TotalClientes + 1;
        SET @ProdutoID = ABS(CHECKSUM(NEWID())) % @NumProdutos + 1;
        SET @VendedorID = ABS(CHECKSUM(NEWID())) % @NumVendedores + 1;
        SET @ConcessionariaID = (SELECT ConcessionariaID FROM Vendedor WHERE Id = @VendedorID);
        INSERT INTO Seguros (Nome, Descricao, ValorPremio, Franquia, ClienteID, ProdutoID, VendedorID, ConcessionariaID, Ativo)
        VALUES (
            'Seguro ' + CAST(@i AS VARCHAR(10)),
            'Descrição do seguro ' + CAST(@i AS VARCHAR(10)),
            CAST(ABS(CHECKSUM(NEWID())) % 5000 + 500 AS DECIMAL(18,2)),
            CAST(ABS(CHECKSUM(NEWID())) % 1000 + 100 AS DECIMAL(18,2)),
            @ClienteID,
            @ProdutoID,
            @VendedorID,
            @ConcessionariaID,
            1
        );
        SET @i = @i + 1;
    END

    -- 10. Populando Simulações
    SET @i = 1;
    WHILE @i <= @NumSimulacoes
    BEGIN
        SET @ClienteID = ABS(CHECKSUM(NEWID())) % @TotalClientes + 1;
        SET @VendedorID = ABS(CHECKSUM(NEWID())) % @NumVendedores + 1;
        SET @ConcessionariaID = (SELECT ConcessionariaID FROM Vendedor WHERE Id = @VendedorID);
        SET @ProdutoID = ABS(CHECKSUM(NEWID())) % @NumProdutos + 1;
        SET @SeguroID = ABS(CHECKSUM(NEWID())) % @NumSeguros + 1;
        INSERT INTO Simulacao (DataSimulacao, ClienteID, VendedorID, ConcessionariaID, ProdutoID, SeguroID, ValorVeiculo, Entrada, QuantidadeParcelas, ValorParcela, TaxaJuros)
        VALUES (
            GETDATE(),
            @ClienteID,
            @VendedorID,
            @ConcessionariaID,
            @ProdutoID,
            @SeguroID,
            CAST(ABS(CHECKSUM(NEWID())) % 90000 + 10000 AS DECIMAL(18,2)),
            CAST(ABS(CHECKSUM(NEWID())) % 20000 + 5000 AS DECIMAL(18,2)),
            ABS(CHECKSUM(NEWID())) % 60 + 6,
            CAST(ABS(CHECKSUM(NEWID())) % 2000 + 500 AS DECIMAL(18,2)),
            CAST(ABS(CHECKSUM(NEWID())) % 5 + 1 AS DECIMAL(5,2))
        );
        SET @i = @i + 1;
    END

    -- 11. Populando Propostas
    SET @i = 1;
    WHILE @i <= @NumPropostas
    BEGIN
        SET @SimulacaoID = ABS(CHECKSUM(NEWID())) % @NumSimulacoes + 1;
        SET @SimulacaoClienteID = (SELECT ClienteID FROM Simulacao WHERE Id = @SimulacaoID);
        SET @SimulacaoProdutoID = (SELECT ProdutoID FROM Simulacao WHERE Id = @SimulacaoID);
        SET @SimulacaoConcessionariaID = (SELECT ConcessionariaID FROM Simulacao WHERE Id = @SimulacaoID);
        SET @SimulacaoSeguroID = (SELECT SeguroID FROM Simulacao WHERE Id = @SimulacaoID);
        SET @SimulacaoVendedorID = (SELECT VendedorID FROM Simulacao WHERE Id = @SimulacaoID);
        INSERT INTO Propostas (SimulacaoID, ClienteID, ProdutoID, ConcessionariaID, DataProposta, ValorProposto, ValorEntrada, QuantidadeParcelas, ValorParcela, TaxaJuros, SeguroID, VendedorID)
        VALUES (
            @SimulacaoID,
            @SimulacaoClienteID,
            @SimulacaoProdutoID,
            @SimulacaoConcessionariaID,
            GETDATE(),
            CAST(ABS(CHECKSUM(NEWID())) % 90000 + 10000 AS DECIMAL(18,2)),
            CAST(ABS(CHECKSUM(NEWID())) % 20000 + 5000 AS DECIMAL(18,2)),
            ABS(CHECKSUM(NEWID())) % 60 + 6,
            CAST(ABS(CHECKSUM(NEWID())) % 2000 + 500 AS DECIMAL(18,2)),
            CAST(ABS(CHECKSUM(NEWID())) % 5 + 1 AS DECIMAL(5,2)),
            @SimulacaoSeguroID,
            @SimulacaoVendedorID
        );
        SET @i = @i + 1;
    END

    SET NOCOUNT OFF;
END
