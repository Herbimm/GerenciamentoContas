-- Consultas de testes nas tableas criadas.

USE CertMat;

-- SELECT * FROM Laboratorio;
-- SELECT * FROM Material;
-- SELECT * FROM Certificacao;

SELECT Nome, Contato FROM Laboratorio WHERE Nome IN 
(SELECT Laboratorio_Nome FROM Certificacao WHERE Material_Nome = 'Aço');
