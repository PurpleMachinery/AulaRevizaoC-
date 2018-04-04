USE master;
DROP DATABASE registro;
CREATE DATABASE registro;
GO
USE registro;

CREATE TABLE cadastros
(
	pk_idCadastro INT PRIMARY KEY IDENTITY(1,1),
	nome NVARCHAR(40) not null	,
	cargo NVARCHAR(50) not null,
	salario DECIMAL(14,2) not null,
	nascimento date not null,
	cpf NVARCHAR(11) not null
)

SELECT * from cadastros;