CREATE DATABASE OnTheFly


CREATE TABLE Restritos
(	
	Cpf Varchar(11) NOT NULL

	CONSTRAINT PK_Restritos PRIMARY KEY (Cpf),
);

SELECT * FROM CompanhiaAerea
INSERT INTO CompanhiaAerea(Cnpj) Values ('51207470000161');

SELECT *From Restritos WHERE Restritos.Cpf = '18709695028'
DELETE Cpf From Restritos Where Restritos.Cpf

SELECT * FROM Passageiro


CREATE TABLE Passageiro
(
	Cpf Varchar(11) NOT NULL,
	Nome Varchar(50) NULL, 
	Situacao char(1) NULL,
	DataCadastro DATETIME NULL,
	UltimaCompra DATETIME NULL,
	Sexo char(1) NULL, 
	DataNascimento DATETIME NULL,

	CONSTRAINT PK_Passageiro PRIMARY KEY (Cpf),

);

SELECT Passageiro.Cpf, Passageiro.Nome, Passageiro.Situacao, Passageiro.DataCadastro,
Passageiro.UltimaCompra, Passageiro.Sexo, Passageiro.DataNascimento
FROM Passageiro
Where Passageiro.Cpf = '18709695028'

SELECT * FROM Voo

CREATE TABLE Venda 
(
	IdVenda int IDENTITY (1,1) NOT NULL,
	DataVenda Datetime NULL, 
	ValorTotal Float NULL, 
	Cpf Varchar(11) NOT NULL, 

	CONSTRAINT PK_Venda PRIMARY KEY (IdVenda),
	CONSTRAINT FK_Passageiro FOREIGN KEY (Cpf) REFERENCES Passageiro (Cpf), 
); 

insert into Venda(DataVenda, ValorTotal, Cpf) VALUES ('23/01/2020', '5000', '22256777006')

CREATE TABLE ItemVenda 
(
	IdItemVenda int IDENTITY(1,1) NOT NULL,
	IdVenda int NOT NULL,
	ValorUnitario float NULL,
	IdPassagem varchar(6) NOT NULL,

	CONSTRAINT PK_ItemVenda PRIMARY KEY(IdItemVenda),
	CONSTRAINT FK_Passagem FOREIGN KEY(IdPassagem) REFERENCES Passagem (IdPassagem), 
	CONSTRAINT FK_Venda FOREIGN KEY(IdVenda) REFERENCES Venda (IdVenda), 
);

CREATE TABLE Passagem 
(
		IdPassagem varchar(6) NOT NULL,
		Situacao char(1) NULL,
		Valor float NULL,
		DataUltimaOp datetime NULL,
		IdVoo varchar(5) NOT NULL,

		CONSTRAINT PK_Passagem PRIMARY KEY (IdPassagem),
		CONSTRAINT FK_Voo FOREIGN KEY (IdVoo) REFERENCES Voo(IdVoo),
);

SELECT * FROM Voo 

update Voo set AssentosOcupados = AssentosOcupados + 1
where IdVoo = (Select IdVoo from Passagem where IdPassagem = 'PA1000');

Select IdVoo from Passagem where IdPassagem = 'PA1000';

SELECT * FROM Passageiro
SELECT * FROM Passagem

SELECT * FROM Voo
SELECT * FROM Aeronave

CREATE TABLE Aeronave
(
	Inscricao varchar(6) NOT NULL, 
	Capacidade int NULL, 
	UltimaVenda datetime NULL, 
	Situacao char(1) NULL, 
	DataCadastro datetime NULL, 
	Cnpj Varchar(14) NOT NULL, 

	CONSTRAINT PK_Aeronave PRIMARY KEY (Inscricao),
	CONSTRAINT FK_CompanhiaAerea FOREIGN KEY(Cnpj) REFERENCES CompanhiaAerea (Cnpj),
);

	SELECT * FROM Aeronave

CREATE TABLE Voo
(
	IdVoo varchar(5) NOT NULL,
	Situacao char(1) NULL, 
	DataVoo datetime NULL,
	DataCadastro datetime NULL,
	Destino Varchar(50) NULL, 
	AssentosOcupados int NULL,
	Inscricao varchar(6) NOT NULL,

	CONSTRAINT PK_Voo PRIMARY KEY (IdVoo),
	CONSTRAINT FK_Aeronave FOREIGN KEY(Inscricao) REFERENCES Aeronave(Inscricao),
);

SELECT Voo.IdVoo, Voo.Situacao, Voo.DataVoo, Voo.DataCadastro, Voo.Destino, Voo.AssentosOcupados, Voo.Inscricao
FROM Voo
WHERE IdVoo = 'V1000'

CREATE TABLE Companhia_Aerea
(
	Cnpj Varchar(14) NOT NULL, 
	RazaoSocial Varchar(30) NULL, 
	DataAbertura datetime NULL, 
	DataCadastro datetime NULL,
	UltimoVoo datetime NULL, 
	Situacao char(1) NULL,
	
	CONSTRAINT PK_CompanhiaAerea PRIMARY KEY (Cnpj),
);

SELECT * FROM Bloqueados

CREATE TABLE Bloqueados
(
	Cnpj Varchar(14) NOT NULL,

	CONSTRAINT PK_Bloqueados PRIMARY KEY (Cnpj),

);

CREATE TABLE Destino
(
	Sigla varchar(3) NOT NULL,
	Nome varchar(50) NOT NULL,

	CONSTRAINT PK_Destino PRIMARY KEY(Sigla),

);


SELECT * FROM Voo
SELECT * FROM Passageiro 
ORDER BY Cpf --Ordenar de forma crescente 
OFFSET 1 ROWS --Pular a qtd de linhas
FETCH NEXT 1 ROWS ONLY --Pegar apenas uma linha

SELECT COUNT (*) 
FROM Passageiro