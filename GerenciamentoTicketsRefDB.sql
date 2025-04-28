-- Criação do Banco de Dados
CREATE DATABASE IF NOT EXISTS GerencTicketsRef;

-- Usa o Banco de Dados
USE GerencTicketsRef;

-- Cria a Tabela funcionarios
CREATE TABLE IF NOT EXISTS funcionarios (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(255) NOT NULL,
    cpf VARCHAR(11) NOT NULL UNIQUE,
    situacao CHAR(1) NOT NULL CHECK (situacao IN ('A', 'I')),
    dataAltFuncs DATETIME NOT NULL
);

-- Cria a Tabela valeRefeicao
CREATE TABLE IF NOT EXISTS ticketsRef (
    id INT PRIMARY KEY AUTO_INCREMENT,
    funcionarioId INT NOT NULL,
    quantidade INT NOT NULL,
    situacao CHAR(1) NOT NULL CHECK (situacao IN ('A', 'I')),
    dataAltTr DATETIME NOT NULL,
    FOREIGN KEY (funcionarioId) REFERENCES funcionarios(id)
);

drop schema gerencticketsref;