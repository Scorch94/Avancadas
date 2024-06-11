create database Ticket2Help

use Ticket2Help
go

create table usuario(
nome nvarchar (50) primary key,
password nvarchar (30),
tipo nvarchar(30)
)

create table ticket(
id int IDENTITY(1,1) not null primary key,
hora_criacao datetime,
hora_modificacao datetime,
colaborador nvarchar(50) foreign key references usuario(nome),
tipo_servico varchar(30),
estado varchar(50),
descricao varchar(200)
)



