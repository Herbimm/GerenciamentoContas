#
# 8. Plano de Testes de Software

Os requisitos para realização dos testes de software são:

- Site publicado na Internet
- Navegador da Internet - Chrome, Firefox ou Edge
- Conectividade de Internet para acesso às plataformas (APIs)

Os testes funcionais a serem realizados no site são descritos a seguir.

| **Caso de Teste** | **CT-01 – Realizar login no sistema** |
| --- | --- |
| **Requisitos Associados** | RNF-01: Permitir a manutenção do site durante seu ciclo de vida. |
| **Objetivo do Teste** | Verificar se a rotina de login está funcionando corretamente |
| **Passos** | 1) Acessar o Navegador e informar o endereço do Site 2) Visualizar a página principal e selecionar a opção &quot;Login&quot; 3) Digitar e-mail e senha de acesso previamente cadastrados4) Clicar em Login |
| **Critérios de Êxito** | Os mantedores do site devem conseguir ter acesso ao mesmo – login realizado corretamente. |

| **Caso de Teste** | **CT-02 – Realizar cadastro de Laboratório** |
| --- | --- |
| **Requisitos Associados** | RF- 03: O site deve permitir o cadastro de laboratórios de ensaios. |
| **Objetivo do Teste** | Verificar se os dados estão sendo armazenados corretamente no Banco de Dados |
| **Passos** | 1) Acessar o Navegador e informar o endereço do Site 2) Visualizar a página principal e selecionar a opção &quot;Cadastros&quot; 3) Selecionar o tipo e preencher os campos solicitados4) Verificar se os dados foram armazenados no Banco de Dados |
| **Critérios de Êxito** | Dados submetidos devem ser salvos no Banco de Dados |

| **Caso de Teste** | **CT-03 – Localizar entidade Certificadora** |
| --- | --- |
| **Requisitos Associados** | RF- 01: O sistema deve permite encontrar entidades certificadoras para determinado material |
| **Objetivo do Teste** | Verificar se a funcionalidade principal do sistema está sendo atendida. |
| **Passos** | 1) Acessar o Navegador e informar o endereço do Site 2) Visualizar a página principal e selecionar a opção &quot;Certificações&quot; 3) Pesquisa o material >
| **Critérios de Êxito** | Retornada lista de entidades previamente registradas que emitam certificações para aquele tipo de material |
