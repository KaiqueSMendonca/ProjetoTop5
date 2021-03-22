/*Criando o banco de dados */
DROP DATABASE IF EXISTS BDLOJA;
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
	NomeFunc varchar(50) not null,
	TelFunc varchar(20) not null
)default charset utf8;


CREATE TABLE tbCliente(
	CodCli int primary key auto_increment,
	NomeCli varchar(50) not null,
	TelCli varchar(50) not null,
	EmailCli varchar(50) not null
)default charset utf8;


CREATE TABLE tbProduto(
	CodProd int primary key auto_increment,
    LinkImg varchar(200),
	NomeProd varchar(50) not null,
	DescProd varchar(100) not null,
	ValorUnitario decimal(10,2) not null
)default charset utf8;

create table tbPedido(
	CodPed int auto_increment primary key,
    CodFunc int not null,
	foreign key(CodFunc) references tbFuncionario(CodFunc),
    CodCli int not null,
	foreign key(CodCli) references tbCliente(CodCli),
    DataPed date not null,
    ValorPed decimal(7,2)
)default charset utf8;

create table tbItensPedido(
    CodPed int not null,
	foreign key(CodPed) references tbPedido(CodPed),
    CodProd int not null,
	foreign key(CodProd) references tbProduto(CodProd),
    Qtitem int not null,
    ValorItem decimal(7,2),
    primary key (CodPed, CodProd)
)default charset utf8;

create table tbVenda(
	CodVenda int auto_increment primary key,
    CodPed int not null,
	foreign key(CodPed) references tbPedido(CodPed),
	Valor decimal(7,2) not null,
    FormaPag varchar(50)not null,
    DataEntrega date,
    EndEntrega varchar(50)
)default charset utf8;

/*Consultando as tabelas do banco de dados */

select * from tbUsuario;
select * from tbFuncionario;
select * from tbCliente;
select * from tbProduto;
select * from tbPedido;
select * from tbItensPedido;
select * from tbVenda;

/*Inserindo dados nas tables */

insert into tbUsuario(nome_usuario,senha_usuario) values('admin','12345678')
