-- Começa do zero

DROP DATABASE IF EXISTS CertMat;

-- Cria Base e Tabelas

CREATE DATABASE CertMat;
USE CertMat;

CREATE TABLE Laboratorio (
    Nome varchar(255) NOT NULL, 
    Usuario varchar(30), 
    Senha varchar(30),
    Contato varchar(255),

    PRIMARY KEY (Nome)
);

CREATE TABLE Material (
    Nome varchar(255) NOT NULL, 
    
    PRIMARY KEY(Nome)
);

-- Junction Laboratorio/Material

CREATE TABLE Certificacao (
    Laboratorio_Nome varchar(255),
    Material_Nome varchar(255),

    CONSTRAINT FK_Laboratorio FOREIGN KEY (Laboratorio_Nome) REFERENCES Laboratorio (Nome),
    CONSTRAINT FK_Material FOREIGN KEY (Material_Nome) REFERENCES Material (Nome),

    CONSTRAINT PK_Certificacao PRIMARY KEY (Laboratorio_Nome, Material_Nome)
);

