/*Criando o banco de dados */
CREATE DATABASE BDLOJA
default character set utf8
default collate utf8_general_ci;
/*Usando o banco de dados */
USE BDLOJA;
/*Criando as tabelas do banco de dados */
CREATE TABLE tbUsuario(
	cod_usuario int primary key auto_increment,
	nome_usuario varchar(40) not null,
	senha_usuario varchar(15) not null
)default charset utf8;


CREATE TABLE tbFuncionario(
	CodFunc int primary key auto_increment,
	NomeFunc varchar(50),
	TelFunc varchar(20)
)default charset utf8;


CREATE TABLE tbCliente(
	CodCli int primary key auto_increment,
	NomeCli varchar(50),
	TelCli varchar(50),
	EmailCli varchar(50)
)default charset utf8;


CREATE TABLE tbProduto(
	CodProd int primary key auto_increment,
	NomeProd varchar(50),
	DescProd varchar(100),
	ValorUnitario varchar(20)
)default charset utf8;


CREATE TABLE tbPagamento(
	CodPagto int primary key auto_increment,
	DescPgto varchar(50),
	Quantidade int,
	ValorTotal varchar(20)
)default charset utf8;


/*Consultando as tabelas do banco de dados */

select * from tbUsuario;
select * from tbFuncionario;
select * from tbCliente;
select * from tbProduto;
select * from tbPagamento;

/*Inserindo dados nas tables */

insert into tbUsuario(nome_usuario,senha_usuario) values('admin','12345678')
