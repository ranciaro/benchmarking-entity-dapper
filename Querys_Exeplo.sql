
Select * from Cep
Select * from Cliente
Select * from ClienteConcessionaria
Select * from Concessionaria
Select * from Endereco
Select * from Produtos
Select * from Propostas
Select * from Seguros
Select * from Simulacao
Select * from TipoDocumento
Select * from Vendedor


select 
Propostas.DataProposta, Propostas.PropostaID,
Simulacao.SimulacaoID, Simulacao.DataSimulacao,
Cliente.ClienteID, Cliente.Nome, Cliente.Sobrenome,
Produtos.ProdutoID, Produtos.Nome,
Concessionaria.ConcessionariaID, Concessionaria.Nome,
*
from Propostas with (nolock)
inner join Cliente with (nolock) on Propostas.ClienteID = Cliente.ClienteID
inner join Produtos (nolock) on Propostas.ProdutoID = Produtos.ProdutoID
inner join Concessionaria (nolock) on Propostas.ConcessionariaID = Concessionaria.ConcessionariaID
inner join Simulacao with (nolock) on Propostas.SimulacaoID = Simulacao.SimulacaoID
