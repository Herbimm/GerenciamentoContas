# GerenciamentoContas

Utilizado para gerenciar Logins com o IdentityCore para versão .NETCore 6

Tela de Login com Bootstrap, integração com Banco de Dados. Query :

CREATE TABLE [dbo].[Users](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[PasswordHash] [nvarchar](max) NULL,
CONSTRAINT [PK_UdemyIdentityUsers] PRIMARY KEY CLUSTERED (
	[Id] ASC
))
