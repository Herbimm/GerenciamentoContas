-- Popula tabelas com valores para testes.

USE CertMat;

INSERT INTO Laboratorio (Nome, Contato) VALUES ("INMETRO", "Avenida Afonso Pena, Nº 666, Belo Horizonte, MG, CEP: 34800-000");
INSERT INTO Laboratorio (Nome, Contato) VALUES ("LAB-1", "Avenida Brasil, Nº 420, Outro Amarelo, TU, CEP: 10000-000");

INSERT INTO Material (Nome) VALUES ("Aço");
INSERT INTO Material (Nome) VALUES ("Areia");
INSERT INTO Material (Nome) VALUES ("Cimento");
INSERT INTO Material (Nome) VALUES ("Betume");

INSERT INTO Certificacao (Laboratorio_Nome, Material_Nome) VALUES ("INMETRO", "Aço");
INSERT INTO Certificacao (Laboratorio_Nome, Material_Nome) VALUES ("INMETRO", "Areia");
INSERT INTO Certificacao (Laboratorio_Nome, Material_Nome) VALUES ("INMETRO", "Cimento");

INSERT INTO Certificacao (Laboratorio_Nome, Material_Nome) VALUES ("LAB-1", "Aço");
INSERT INTO Certificacao (Laboratorio_Nome, Material_Nome) VALUES ("LAB-1", "Betume");


