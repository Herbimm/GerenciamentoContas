# 5. Arquitetura da Solução

Nesta seção são apresentados os detalhes técnicos da solução criada pela equipe, tratando dos componentes que fazem parte da solução e do ambiente de hospedagem da solução.

### Diagrama de classes 

![Diagrama de classes](img/uml_class_d.png)
<center>Figura 12 - Diagrama de classe</center>

### Modelo ER e Esquema Relacional

![Modelo ER](img/DiagramaER.png)
<center>Figura 12 - Modelo ER</center>


### Diagrama de Componentes

Os componentes que fazem parte da solução são apresentados na Figura que se segue.

![Diagrama de Componentes](img/componentes.png)
<center>Figura 12 - Arquitetura da Solução</center>


A solução implementada conta com os seguintes módulos:

- **Navegador** - Interface básica do sistema
  - **Páginas Web** - Conjunto de arquivos HTML, CSS, JavaScript e imagens que constituem a interface da aplicação hospedada na Web.
  - **Banco de Dados** - armazenamento local, onde são implementados bancos de dados na linguagem SQL.
- **Heroku** - local na Internet onde as páginas são mantidas e acessadas pelo navegador.

### Hospedagem

O site utiliza a plataforma do Git Pages como ambiente de hospedagem do site do projeto. O site é mantido no ambiente da URL:

https://pages.github.com/

A publicação do site no  Git Pages é feita por meio de uma submissão do projeto (push) via git para o repositório remoto que se encontra no endereço:

https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2021-1-e1-proj-web-t5-time-01-certificacoes-de-materiais/tree/main/src 
